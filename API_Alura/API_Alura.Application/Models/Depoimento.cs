namespace API_Alura.Application.Models
{
    public class Depoimento
    {
        public int Id { get; set; }
        public byte[] Foto { get; set; }
        public string Nome { get; set; }
        public string DepoimentoUsuario { get; set; }
    }
}
