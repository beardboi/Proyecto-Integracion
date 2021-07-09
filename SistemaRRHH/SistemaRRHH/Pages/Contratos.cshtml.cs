using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SistemaRRHH.Data;
using SistemaRRHH.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaRRHH.Pages
{
    public class ContratosModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly DataContext _context;
        public List<Contrato> contratos;
        public List<Persona> personas;

        public ContratosModel(ILogger<IndexModel> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
            contratos = _context.Contratos.ToList();
            personas = _context.Personas.ToList();
        }
    }
}
