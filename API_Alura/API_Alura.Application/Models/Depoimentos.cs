using System.ComponentModel.DataAnnotations;

namespace API_Alura.Application.Models
{
    public class Depoimentos
    {
        public int Id { get; set; }
        public byte[] Foto { get; set; }
        public string Nome { get; set; }
        public string Depoimento { get; set; }
    }
}
