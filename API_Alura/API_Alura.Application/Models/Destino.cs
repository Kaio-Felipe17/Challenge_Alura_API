namespace API_Alura.Application.Models
{
    public class Destino
    {
        public int Id { get; set; }
        public byte[] Foto1 { get; set; }
        public byte[] Foto2 { get; set; }
        public string Nome { get; set; }
        public string Meta { get; set; }
        public string TextoDescritivo { get; set; }
        public double Preco { get; set; }
    }
}
