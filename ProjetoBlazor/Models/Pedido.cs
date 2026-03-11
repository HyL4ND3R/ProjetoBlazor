using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace ProjetoBlazor.Models
{
    public class Pedido
    {
        [Key]
        public Int64 Controle { get; set; }
        public int Codigo { get; set; }
        public int ClienteCodigo { get; set; }
        public DateTime Data { get; set; }
        public decimal? QtdeTotal { get; set; } = 0;
        public decimal? ValorTotal { get; set; } = 0;
        public List<PedidoItem> Itens { get; set; } = new List<PedidoItem>();
    }
}