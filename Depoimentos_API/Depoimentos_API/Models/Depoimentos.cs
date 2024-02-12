using System.ComponentModel.DataAnnotations;

namespace Depoimentos_API.Models
{
    public class Depoimentos
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public IFormFile Foto { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Depoimento { get; set; }
    }
}