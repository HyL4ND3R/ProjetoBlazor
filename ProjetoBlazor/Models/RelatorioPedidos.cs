namespace ProjetoBlazor.Models
{
    public class RelatorioPedidos
    {
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public int? CodCliente { get; set; }
        public int? CodProduto { get; set; }
    }
}
