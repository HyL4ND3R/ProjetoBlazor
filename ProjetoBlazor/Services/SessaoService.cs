using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.EntityFrameworkCore;
using ProjetoBlazor.Data;
using ProjetoBlazor.Models;

namespace ProjetoBlazor.Services
{
    public class SessaoService
    {
        private readonly ProtectedSessionStorage _sessionStorage;
        private readonly IDbContextFactory<DataBaseContext> _dbFactory;

        public SessaoService(ProtectedSessionStorage sessionStorage, IDbContextFactory<DataBaseContext> dbFactory)
        {
            _sessionStorage = sessionStorage;
            _dbFactory = dbFactory;
        }

        public async Task<Operador?> GetOperadorLogadoAsync()
        {
            try
            {
                // 1. Pega o nome do operador que salvamos no Login
                var result = await _sessionStorage.GetAsync<string>("OperadorLogado");

                if (result.Success && !string.IsNullOrEmpty(result.Value))
                {
                    string nomeOperador = result.Value;

                    // 2. Busca o objeto completo no banco de dados para você ter acesso ao ID, Admin, etc.
                    using var context = _dbFactory.CreateDbContext();
                    return await context.Operador.FirstOrDefaultAsync(x => x.Nome == nomeOperador && x.Inativo == 0);
                }
            }
            catch
            {
                // Retorna nulo se tentar rodar no pré-render (onde o JS não está pronto)
                return null;
            }

            return null;
        }
    }
}
