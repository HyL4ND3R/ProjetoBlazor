using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoBlazor.Data;
using ProjetoBlazor.Models;

namespace ProjetoBlazor.Pages.Operador
{
    public class CreateModel : PageModel
    {
        private readonly DataBaseContext _context;

        public CreateModel(DataBaseContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Operador Operador { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Operador.Add(Operador);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
