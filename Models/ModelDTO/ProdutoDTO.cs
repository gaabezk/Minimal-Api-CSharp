namespace ApiCsharp.Models.ModelDTO
{
    public class ProdutoDTO
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public ProdutoDTO()
        {
        }

        public ProdutoDTO(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public ProdutoDTO(string nome)
        {
            Nome = nome;
        }
    }
}
