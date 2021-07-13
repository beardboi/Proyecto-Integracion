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
    public class DetailsModel : PageModel
    {
        private readonly DataContext _context;

        [BindProperty]
        public Mantencion Mantencion { get; set; }
        public List<MantencionTecnico> ListaMantencionTecnicos { get; set; }
        public List<MantencionMaterial> ListaMantencionMateriales { get; set; }

        public DetailsModel(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Mantencion = await _context.Mantenciones
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Mantencion == null)
            {
                return NotFound();
            }

            ListaMantencionTecnicos = await _context.MantencionTecnicos
                .Where(me => me.MantencionId == id)
                .Include(me => me.Tecnico).ToListAsync();

            ListaMantencionMateriales = await _context.MantencionMateriales
                .Where(mp => mp.MantencionId == id)
                .Include(mp => mp.Material).ToListAsync();

            return Page();
        }
    }
}