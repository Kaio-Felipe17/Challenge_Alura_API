using System.ComponentModel.DataAnnotations;

namespace API_Alura.Application.DTOs.Request
{
    public class AtualizaDestinoRequestDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Foto1 { get; set; }

        [Required]
        public string Foto2 { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [MaxLength(160, ErrorMessage = "O conteúdo não pode ultrapassar 160 caracteres.")]
        public string Meta { get; set; }

        public string TextoDescritivo { get; set; }

        [Required]
        public decimal Preco { get; set; }
    }
}
