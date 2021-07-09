using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SistemaMantencion.Data;
using SistemaMantencion.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaMantencion.Pages.Mantenciones
{
    /// <summary>
    /// Modelo de la vista Index de mantenciones 
    /// </summary>
    public class IndexModel : PageModel
    {
        private readonly DataContext _context;
        public List<Mantencion> Mantenciones { get; set; }

        public IndexModel(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGet()
        {
            Mantenciones = await _context.Mantenciones
                .Include(m => m.Vehiculo)
                .OrderByDescending(m => m.Fecha).ToListAsync();

            return Page();
        }
    }
}