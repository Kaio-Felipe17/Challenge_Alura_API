using System.ComponentModel.DataAnnotations;

namespace API_Alura.Application.Models
{
    public class Depoimentos
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public byte[] Foto { get; set; }

        [Required(ErrorMessage = "O parâmetro nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O parâmetro depoimento é obrigatório")]
        public string Depoimento { get; set; }
    }
}
