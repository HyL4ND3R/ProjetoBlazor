using System.ComponentModel.DataAnnotations;

namespace ProjetoBlazor.Models
{
    public class Pedido
    {
        [Key]
        public int Controle { get; set; }
        public int Codigo { get; set; }
        public int ClienteCodigo { get; set; }
        public DateTime Data { get; set; }
        public decimal QtdeTotal { get; set; }
        public decimal ValorTotal { get; set; }

    }
}
