namespace ApiCsharp.Models.ModelDTO
{
    public class RoleDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public RoleDTO()
        {
        }

        public RoleDTO(string nome, string descricao, string idUsuario)
        {
            Nome = nome;
            Descricao = descricao;
        }
        public RoleDTO(int id, string nome, string descricao, string idUsuario)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
        }
    }
}
