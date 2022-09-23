using ApiCsharp.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCsharp.Contexto
{
    public class Contexto : DbContext
    {

        public Contexto(DbContextOptions<Contexto> options)
                : base(options) => Database.EnsureCreated();

        public DbSet<Produto> Produto { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Role> Role { get; set; }


    }
}
