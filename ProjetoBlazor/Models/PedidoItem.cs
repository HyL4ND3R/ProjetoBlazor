using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace ProjetoBlazor.Models
{
    public class PedidoItem
    {
        [Key]
        public Int64 Controle { get; set; }
        public Int64 ControlePedido { get; set; }
        public int Item { get; set; }
        public int ProdutoCodigo { get; set; }
        public string Descricao { get; set; } = "";
        public decimal Quantidade { get; set; }
        public decimal ValorUn { get; set; }
        public decimal ValorTotal { get; set;}
    }
}
