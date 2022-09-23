namespace ApiCsharp.Models.ModelDTO
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Telefone { get; set; }
        public int Idade { get; set; }
        public DateTime DataNascimento { get; set; }
        public int IdRole { get; set; }

        public UsuarioDTO()
        {
        }

        public UsuarioDTO(int id, string nomeCompleto, string telefone, int idade, DateTime dataNascimento, int idRole)
        {
            Id = id;
            NomeCompleto = nomeCompleto;
            Telefone = telefone;
            Idade = idade;
            DataNascimento = dataNascimento;
            IdRole = idRole;
        }
        public UsuarioDTO(string nomeCompleto, string telefone, int idade, DateTime dataNascimento, int idRole)
        {
            NomeCompleto = nomeCompleto;
            Telefone = telefone;
            Idade = idade;
            DataNascimento = dataNascimento;
            IdRole = idRole;
        }

    }
}
