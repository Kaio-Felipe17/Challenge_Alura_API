using System.ComponentModel.DataAnnotations;

namespace API_Alura.Application.DTOs.Request
{
    public class InsereDestinoRequestDTO
    {
        [Required]
        public string Foto { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public decimal Preco { get; set; }
    }
}
