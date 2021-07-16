using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaMantencion.Data;
using SistemaMantencion.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaMantencion.Utils;

namespace SistemaMantencion.Pages.Mantenciones
{
    public class CreateModel : PageModel
    {
        private readonly DataContext _context;

        [BindProperty]
        public Mantencion Mantencion { get; set; }

        public Vehiculo Vehiculo { get; set; }
        public SelectList Tecnicos { get; set; }
        public SelectList Materiales { get; set; }
        public SelectList Vehiculos { get; set; }
        public List<Tecnico> ListaTecnicos { get; set; }
        public List<Material> ListaMateriales { get; set; }
        public List<MantencionTecnico> MantencionTecnicos { get; set; }
        public List<MantencionMaterial> MantencionMateriales { get; set; }

        public CreateModel(DataContext context)
        {
            _context = context;
            ListaTecnicos = new List<Tecnico>();
            ListaMateriales = new List<Material>();
            MantencionTecnicos = new List<MantencionTecnico>();
            MantencionMateriales = new List<MantencionMaterial>();
        }

        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null)
            {
                // Traer tablas desde la base de datos.
                List<Material> listaMateriales = await _context.Materiales.ToListAsync();
                List<Tecnico> listaTecnicos = await _context.Tecnicos.OrderBy(e => e.Rut).ToListAsync();
                List<Vehiculo> listaVehiculos = await _context.Vehiculos.ToListAsync();

                // Selects para el formulario
                Materiales = new SelectList(listaMateriales, nameof(Material.Id), nameof(Material.Nombre));
                Tecnicos = new SelectList(listaTecnicos.Select(e => new { Rut = e.Rut, Nombre = e.Rut + " - " + e.Nombre }), "Rut", "Nombre");
                Vehiculos = new SelectList(listaVehiculos, nameof(Vehiculo.Id), nameof(Vehiculo.Patente));

                return Page();
            }
            else
            {
                // La mantencion debe ser buscada dentro de la base de datos.

                Mantencion mantencion = await _context.Mantenciones
                                                    .Include(m => m.Vehiculo)
                                                    .FirstOrDefaultAsync(m => m.Id == id);
                Mantencion = mantencion;

                ListaTecnicos = await _context.Tecnicos
                                                    .Include(t => t.MantencionesTecnico)
                                                    .Where(t => t.MantencionesTecnico.Any(m => m.MantencionId == id))
                                                    .ToListAsync();

                ListaMateriales = await _context.Materiales
                                                    .Include(t => t.MantencionesMateriales)
                                                    .Where(t => t.MantencionesMateriales.Any(m => m.MantencionId == id))
                                                    .ToListAsync();

                // Traer las tablas de relaciones N a N
                MantencionTecnicos = await _context.MantencionTecnicos
                                                    .Where(m => m.MantencionId == id) // Debe coincidir la id.
                                                    .Include(m => m.Tecnico) // Traer tambi�n a la entidad Tecnico, para poder desplegar la info.
                                                    .ToListAsync(); // Convertir a lista.

                MantencionMateriales = await _context.MantencionMateriales
                                                    .Where(m => m.MantencionId == id)
                                                    .Include(m => m.Material)
                                                    .ToListAsync();

                // Cargar la lista de tecnicos y materiales, pero filtrando aquellos que ya poseen una tabla N a N relacionada al id de la mantencion actual.
                List<Tecnico> listaTecnicos = await _context.Tecnicos
                                                    .Include(t => t.MantencionesTecnico)
                                                    .Where(t => !t.MantencionesTecnico.Any(m => m.MantencionId == id))
                                                    .ToListAsync();

                List<Material> listaMateriales = await _context.Materiales
                                                    .Include(t => t.MantencionesMateriales)
                                                    .Where(t => !t.MantencionesMateriales.Any(m => m.MantencionId == id))
                                                    .ToListAsync();

                // Cargar los selectlist para materiales y tecnicos.
                Tecnicos = new SelectList(listaTecnicos.Select(e => new { Rut = e.Rut, Nombre = e.Rut + " - " + e.Nombre }), "Rut", "Nombre");
                Materiales = new SelectList(listaMateriales, nameof(Material.Id), nameof(Material.Nombre));

                return Page();
            }
        }

        public async Task<IActionResult> OnPost(DateTime fecha, 
                                                string observaciones, 
                                                string rutEmpleado,
                                                int idVehiculo, 
                                                int horas, 
                                                int idMaterial, 
                                                int cantidad)
        {
            DateTime fechaMantencion = fecha;

            // Crear una nueva mantencion y asignar los atributos.
            Mantencion mantencion = new Mantencion();
            mantencion.Fecha = fechaMantencion;
            mantencion.IdVehiculo = idVehiculo;
            mantencion.Observaciones = observaciones;

            // Asignar la referencia del vehiculo.
            Vehiculo vehiculo = _context.Vehiculos
                .FirstOrDefault(v => v.Id == idVehiculo);
            Material material = _context.Materiales
                .FirstOrDefault(m => m.Id == idMaterial);
            Tecnico tecnico = _context.Tecnicos
                .FirstOrDefault(t => t.Rut == rutEmpleado);

            ListaMateriales.Add(material);
            ListaTecnicos.Add(tecnico);

            // Verificar si el vehiculo/material no se ha encontrado en la DB
            if (vehiculo != null) 
            {
                mantencion.Vehiculo = vehiculo;
                Vehiculo = vehiculo;
            }

            // Insertar la mantencion.
            _context.Mantenciones.Add(mantencion);
            await _context.SaveChangesAsync();

            Mantencion = mantencion;

            // Se crea la tabla intermedia.
            MantencionTecnico mantencionTecnico = new MantencionTecnico();
            mantencionTecnico.Horas = horas;
            mantencionTecnico.MantencionId = mantencion.Id;
            mantencionTecnico.TecnicoRut = rutEmpleado;
            mantencionTecnico.Tecnico = tecnico;

            // Insertar la tabla intermedia.
            _context.MantencionTecnicos.Add(mantencionTecnico);
            await _context.SaveChangesAsync();

            // Publicar la informacion de la tabla intermedia para el sistema RRHH.
            MessageProducer.PublicarMensajeRRHH(mantencionTecnico, fechaMantencion);

            MantencionMaterial mantencionMaterial = new MantencionMaterial();
            mantencionMaterial.Cantidad = cantidad;
            mantencionMaterial.MantencionId = mantencion.Id;
            mantencionMaterial.MaterialId = idMaterial;
            mantencionMaterial.Material = material;

            // Se guarda la relacion
            _context.MantencionMateriales.Add(mantencionMaterial);
            await _context.SaveChangesAsync();

            MessageProducer.PublicarMensajeBodega(mantencionMaterial, fechaMantencion);

            MantencionMateriales.Add(mantencionMaterial);
            MantencionTecnicos.Add(mantencionTecnico);

            // Actualizar los select list. Filtrar tecnicos
            List<Tecnico> listaTecnicos = await _context.Tecnicos.ToListAsync();
            listaTecnicos = listaTecnicos.Where(t => t.Rut != rutEmpleado).ToList();
            Tecnicos = new SelectList(listaTecnicos.Select(e => new { Rut = e.Rut, Nombre = e.Rut + " - " + e.Nombre }), "Rut", "Nombre");

            List<Material> listaMateriales = await _context.Materiales.ToListAsync();
            listaMateriales = listaMateriales.Where(t => t.Id != idMaterial).ToList();
            Materiales = new SelectList(listaMateriales, nameof(Material.Id), nameof(Material.Nombre));

            return Page();
        }

        public async Task<IActionResult> OnPostTecnicos(string rutTecnico, int horas, int idMantencion, DateTime fecha)
        {
            Tecnico tecnico = _context.Tecnicos.FirstOrDefault(t => t.Rut == rutTecnico);
            Mantencion mantencion = _context.Mantenciones.FirstOrDefault(t => t.Id == idMantencion);

            MantencionTecnico mantencionTecnico = new MantencionTecnico();
            mantencionTecnico.Horas = horas;
            mantencionTecnico.MantencionId = idMantencion;
            mantencionTecnico.TecnicoRut = rutTecnico;
            mantencionTecnico.Tecnico = tecnico;
            mantencionTecnico.Mantencion = mantencion;

            _context.MantencionTecnicos.Add(mantencionTecnico);
            await _context.SaveChangesAsync();

            MessageProducer.PublicarMensajeRRHH(mantencionTecnico, fecha);

            return RedirectToPage("./Create", new { id = idMantencion });
        }

        public async Task<IActionResult> OnPostMateriales(int idMaterial, int cantidad, int idMantencion, DateTime fecha)
        {
            Material material = _context.Materiales.FirstOrDefault(t => t.Id == idMaterial);
            Mantencion mantencion = _context.Mantenciones.FirstOrDefault(t => t.Id == idMantencion);

            MantencionMaterial mantencionMaterial = new MantencionMaterial();
            mantencionMaterial.Cantidad = cantidad;
            mantencionMaterial.MantencionId = idMantencion;
            mantencionMaterial.MaterialId = idMaterial;
            mantencionMaterial.Mantencion = mantencion;
            mantencionMaterial.Material = material;

            _context.MantencionMateriales.Add(mantencionMaterial);
            await _context.SaveChangesAsync();

            MessageProducer.PublicarMensajeBodega(mantencionMaterial, fecha);

            return RedirectToPage("./Create", new { id = idMantencion });
        }
    }
}