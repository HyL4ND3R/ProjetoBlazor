using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetoBlazor.Data;
using ProjetoBlazor.Models;

namespace ProjetoBlazor.Pages.Operador
{
    public class DetailsModel : PageModel
    {
        private readonly DataBaseContext _context;

        public DetailsModel(DataBaseContext context)
        {
            _context = context;
        }

        public Operador Operador { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operador = await _context.Operador.FirstOrDefaultAsync(m => m.Codigo == id);

            if (operador is not null)
            {
                Operador = operador;

                return Page();
            }

            return NotFound();
        }
    }
}
