using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaBodega.Data;
using SistemaBodega.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SistemaBodega.Pages.Materiales
{
    public class IndexModel : PageModel
    {
        private readonly DataContext _context;
        public List<Material> Materiales { get; set; }

        public IndexModel(DataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            Materiales = _context.Materiales.ToList();

            return Page();
        }
    }
}