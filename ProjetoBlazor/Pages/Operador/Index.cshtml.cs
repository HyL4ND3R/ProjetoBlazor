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
    public class IndexModel : PageModel
    {
        private readonly DataBaseContext _context;

        public IndexModel(DataBaseContext context)
        {
            _context = context;
        }

        public IList<Operador> Operador { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Operador = await _context.Operador.ToListAsync();
        }
    }
}
