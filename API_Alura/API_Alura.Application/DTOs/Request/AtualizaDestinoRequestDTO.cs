using System.ComponentModel.DataAnnotations;

namespace API_Alura.Application.DTOs.Request
{
    public class AtualizaDestinoRequestDTO
    {
        [Required]
        public int Id { get; set; }
        public string Foto { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }
}
