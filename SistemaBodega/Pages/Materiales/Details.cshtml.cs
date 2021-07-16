using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaBodega.Data;
using SistemaBodega.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SistemaBodega.Pages.Materiales 
{
    public class DetailsModel : PageModel 
    {
        private readonly DataContext _context;

        [BindProperty]
        public Material MaterialActual { get; set; }
        public List<MovimientoMaterial> ListaMovimientos { get; set; }

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

            Material MaterialActual = _context.Materiales.FirstOrDefault(p => p.Id == id);

            if (MaterialActual == null) 
            {
                return NotFound();
            }

            ListaMovimientos = _context.Movimientos_Materiales
                .Where(ht => ht.IdMaterial == id)
                .OrderByDescending(ht => ht.Fecha)
                .ToList();

            return Page();
        }
    }
}