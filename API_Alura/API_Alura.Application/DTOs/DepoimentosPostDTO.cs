using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace API_Alura.Application.DTOs
{
    public class DepoimentosPostDTO
    {
        public string Foto { get; set; }

        [Required(ErrorMessage = "O parâmetro nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O parâmetro depoimento é obrigatório")]
        public string Depoimento { get; set; }
    }
}
