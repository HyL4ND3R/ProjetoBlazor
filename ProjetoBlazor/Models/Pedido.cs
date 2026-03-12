using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace ProjetoBlazor.Models
{
    public class Pedido
    {
        [Key]
        public Int64 Controle { get; set; }
        public int Codigo { get; set; }
        public int ClienteCodigo { get; set; }
        [NotMapped]
        public string? ClienteNome { get; set; } = "";
        public DateTime Data { get; set; }
        public decimal? QtdeTotal { get; set; } = 0;
        public decimal? ValorTotal { get; set; } = 0;
    }
}