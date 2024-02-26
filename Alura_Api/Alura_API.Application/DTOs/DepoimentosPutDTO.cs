namespace Alura_API.Application.DTOs
{
    public class DepoimentosPutDTO
    {
        public int Id { get; set; }
        public byte[] Foto { get; set; }
        public string Nome { get; set; }
        public string Depoimento { get; set; }
    }
}
