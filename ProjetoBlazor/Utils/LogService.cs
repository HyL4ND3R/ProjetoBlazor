using System;
using System.IO;
using System.Threading;

namespace ProjetoBlazor.Utils
{
    public static class LogService
    {
        // Define a pasta onde os logs serão salvos (Ex: C:\MeusLogs ou na raiz do app)
        private static readonly string CaminhoLog = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
        private static readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

        public static async Task GravarLog(string mensagem, string stackTrace = "")
        {
            // Garante que a pasta exista
            if (!Directory.Exists(CaminhoLog))
                Directory.CreateDirectory(CaminhoLog);

            // Nomeia o arquivo por data (um arquivo por dia)
            string nomeArquivo = $"Log_{DateTime.Now:yyyyMMdd}.txt";
            string caminhoCompleto = Path.Combine(CaminhoLog, nomeArquivo);

            // Formata a mensagem
            string logEntrada = $"------------------------------------------------------------------\n" +
                                $"HORA: {DateTime.Now:HH:mm:ss}\n" +
                                $"MENSAGEM: {mensagem}\n" +
                                (string.IsNullOrEmpty(stackTrace) ? "" : $"DETALHES: {stackTrace}\n");

            // Semaphore impede que duas threads tentem escrever no arquivo ao mesmo tempo
            await _semaphore.WaitAsync();
            try
            {
                await File.AppendAllTextAsync(caminhoCompleto, logEntrada);
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }
}