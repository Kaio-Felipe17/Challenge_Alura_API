using System.ComponentModel.DataAnnotations;

namespace API_Alura.Application.DTOs.Request
{
    public class InsereDepoimentoRequestDTO
    {
        [Required(ErrorMessage = "O parâmetro {0} é obrigatório")]
        public string Foto { get; set; }

        [Required(ErrorMessage = "O parâmetro {0} é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O parâmetro {0} é obrigatório")]
        public string Depoimento { get; set; }
    }
}
