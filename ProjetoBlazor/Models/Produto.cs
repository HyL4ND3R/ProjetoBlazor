using System.ComponentModel.DataAnnotations;

namespace ProjetoBlazor.Models
{
    public class Produto
    {
        [Key]
        public int Codigo { get; set; }
        public string Nome { get; set; } = "";
        public decimal Valor { get; set; } = 0;
        public byte Inativo { get; set; }
    }
}
