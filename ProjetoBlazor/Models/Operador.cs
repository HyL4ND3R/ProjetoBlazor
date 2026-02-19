using System.ComponentModel.DataAnnotations;

namespace ProjetoBlazor.Models
{
    public class Operador
    {
        [Key]
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public byte Admin { get; set; }
        public byte Inativo { get; set; }
    }
}
