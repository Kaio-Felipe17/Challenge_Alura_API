namespace API_Alura.Application.DTOs
{
    public class DepoimentosPostDTO
    {
        public required byte[] Foto { get; set; }
        public required string Nome { get; set; }
        public required string Depoimento { get; set; }
    }
}
