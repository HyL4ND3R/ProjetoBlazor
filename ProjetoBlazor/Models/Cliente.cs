using ProjetoBlazor.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProjetoBlazor.Models
{
    public class Cliente
    {
        [Key]
        public int Codigo { get; set; }
        public string Nome { get; set; } = "";
        public TipoDocumento TipoDocumento { get; set; }
        public string Documento { get; set; } = "";
        public string Telefone { get; set; } = "";
        public byte Inativo { get; set; }
    }
}