using System.ComponentModel.DataAnnotations;

namespace API_Alura.Application.DTOs.Request
{
    public class AtualizaDepoimentoRequestDTO
    {
        [Required]
        public int Id { get; set; }
        public string Foto { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
    }
}
