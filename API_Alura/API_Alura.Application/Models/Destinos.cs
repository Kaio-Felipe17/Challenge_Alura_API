using System.ComponentModel.DataAnnotations;

namespace API_Alura.Application.Models
{
    public class Destinos
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo foto é obrigatório")]
        public byte[] Foto { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo preco é obrigatório")]
        public double Preco { get; set; }
    }
}
