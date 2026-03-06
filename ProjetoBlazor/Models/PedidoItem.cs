using System.ComponentModel.DataAnnotations;

namespace ProjetoBlazor.Models
{
    public class PedidoItem
    {
        [Key]
        public int Controle { get; set; }
        public int ControlePedido { get; set; }
        public int Item { get; set; }
        public int ProdutoCodigo { get; set; }
        public string Descricao { get; set; } = "";
        public decimal Quantidade { get; set; }
        public decimal ValorUn { get; set; }
        public decimal ValorTotal { get; set;}
    }
}
