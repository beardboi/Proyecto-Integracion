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
        public SelectList Tecnicos { get; set; }
        public SelectList Materiales { get; set; }
        public SelectList Vehiculos { get; set; }
        public List<MantencionTecnico> MantencionTecnicos { get; set; }
        public List<MantencionMaterial> MantencionMateriales { get; set; }

        public CreateModel(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGet()
        {
            // Traer tablas desde la base de datos.
            List<Material> listaMateriales = await _context.Materiales.ToListAsync();
            List<Vehiculo> listaVehiculos = await _context.Vehiculos.ToListAsync();
            List<Tecnico> listaTecnicos = await _context.Tecnicos.OrderBy(e => e.Rut).ToListAsync();

            // Selects para el formulario
            Materiales = new SelectList(listaMateriales, nameof(Material.Id), nameof(Material.Nombre));
            Vehiculos = new SelectList(listaVehiculos, nameof(Vehiculo.Id), nameof(Vehiculo.Patente));
            Tecnicos = new SelectList(listaTecnicos.Select(e => new { Rut = e.Rut, Nombre = e.Rut + " - " + e.Nombre }), "Rut", "Nombre");

            return Page();
        }

        public async Task<IActionResult> OnPost(DateTime fecha, 
                                                string observaciones, 
                                                string rutEmpleado, 
                                                int horas, 
                                                int idProducto, 
                                                int cantidad, 
                                                int idVehiculo)
        {
            // Crear una nueva mantencion y asignar los atributos.
            Mantencion mantencion = new Mantencion();
            mantencion.IdVehiculo = idVehiculo;
            mantencion.Fecha = fecha;
            mantencion.Observaciones = observaciones;

            // Asignar la referencia del vehiculo.
            Vehiculo vehiculo = _context.Vehiculos.Find(idVehiculo);
            if (vehiculo != null) {
                mantencion.Vehiculo = vehiculo;
            }

            // Insertar la mantencion.
            _context.Mantenciones.Add(mantencion);
            await _context.SaveChangesAsync();

            // Se crea la tabla intermedia.
            MantencionTecnico mantencionTecnico = new MantencionTecnico();
            mantencionTecnico.Horas = horas;
            mantencionTecnico.TecnicoRut = rutEmpleado;
            mantencionTecnico.MantencionId = mantencion.Id;

            // Insertar la tabla intermedia.
            _context.MantencionTecnicos.Add(mantencionTecnico);
            await _context.SaveChangesAsync();

            // Publicar la informacion de la tabla intermedia para el sistema RRHH.
            MessageProducer.PublicarMantencion(fecha, mantencionTecnico);

            MantencionMaterial mantencionMaterial = new MantencionMaterial();
            mantencionMaterial.MantencionId = mantencion.Id;
            mantencionMaterial.MaterialId = idProducto;
            mantencionMaterial.Cantidad = cantidad;

            // Se guarda la relacion
            _context.MantencionMateriales.Add(mantencionMaterial);
            await _context.SaveChangesAsync();

            // Enviar mensaje a RRHH??

            // Retornar a la misma pagina con el ID de la mantencion.
            return Page();
            // return RedirectToPage("./create", new { id = mantencion.Id });
        }

        // TODO: Implementar estos metodos
        // public async Task<IActionResult> OnPostTecnicos()
        // {
        //     return Page();
        // }

        // public async Task<IActionResult> OnPostMateriales()
        // {
        //     return Page();
        // }
    }
}