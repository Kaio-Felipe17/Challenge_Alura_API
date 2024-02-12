namespace Depoimentos_API.DTOs
{
    public interface IDepoimentosGetDTO
    {
        int Id { get; set; }
        IFormFile Foto { get; set; }
        string Nome { get; set; }
        string Depoimento { get; set; }
    }

    public class DepoimentosGetDTO
    {
        public int Id { get; set; }
        public required IFormFile Foto { get; set; }
        public required string Nome { get; set; }
        public required string Depoimento { get; set; }
    }
}
