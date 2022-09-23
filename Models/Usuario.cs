namespace ApiCsharp.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Telefone { get; set; }
        public int Idade { get; set; }
        public DateTime DataNascimento { get; set; }
        public Role Role { get; set; }

    }
}
