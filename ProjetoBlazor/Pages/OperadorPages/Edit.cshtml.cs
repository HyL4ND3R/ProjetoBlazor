using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoBlazor.Data;
using ProjetoBlazor.Models;

namespace ProjetoBlazor.Pages.OperadorPages
{
    public class EditModel : PageModel
    {
        private readonly DataBaseContext _context;

        public EditModel(DataBaseContext context)
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

            var operador =  await _context.Operador.FirstOrDefaultAsync(m => m.Codigo == id);
            if (operador == null)
            {
                return NotFound();
            }
            Operador = operador;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Operador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OperadorExists(Operador.Codigo))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool OperadorExists(int id)
        {
            return _context.Operador.Any(e => e.Codigo == id);
        }
    }
}
