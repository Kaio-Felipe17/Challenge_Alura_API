using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace API_Alura.Application.DTOs.Request
{
    public class InsereDestinoRequestDTO
    {
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
