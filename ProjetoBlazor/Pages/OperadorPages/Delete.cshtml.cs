using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetoBlazor.Data;
using ProjetoBlazor.Models;

namespace ProjetoBlazor.Pages.OperadorPages
{
    public class DeleteModel : PageModel
    {
        private readonly DataBaseContext _context;

        public DeleteModel(DataBaseContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operador = await _context.Operador.FindAsync(id);
            if (operador != null)
            {
                Operador = operador;
                _context.Operador.Remove(Operador);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
