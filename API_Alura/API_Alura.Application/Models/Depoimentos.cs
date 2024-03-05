using System.ComponentModel.DataAnnotations;

namespace API_Alura.Application.Models
{
    public class Depoimentos
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public byte[] Foto { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Depoimento { get; set; }
    }
}
