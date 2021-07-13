using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaRRHH.Data;
using SistemaRRHH.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SistemaRRHH.Pages.Empleados
{
    public class IndexModel : PageModel
    {
        private readonly DataContext _context;
        public List<Persona> Empleados { get; set; }

        public IndexModel(DataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            Empleados = _context.Personas.ToList();

            return Page();
        }
    }
}
