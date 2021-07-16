using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaRRHH.Data;
using SistemaRRHH.Data.Entities;
using System.Collections.Generic;
using System.Linq;
namespace SistemaRRHH.Pages.Empleados 
{
    public class DetailsModel : PageModel 
    {
        private readonly DataContext _context;

        [BindProperty]
        public Persona Empleado { get; set; }
        public List<HorasTrabajadas> ListaHorasTrabajadas { get; set; }

        public DetailsModel(DataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Persona empleado = _context.Personas.FirstOrDefault(p => p.Id == id);

            if (empleado == null) 
            {
                return NotFound();
            }

            ListaHorasTrabajadas = _context.HorasTrabajadas
                .Where(ht => ht.IdPersona == id)
                .OrderByDescending(ht => ht.Fecha)
                .ToList();

            return Page();
        }
    }
}