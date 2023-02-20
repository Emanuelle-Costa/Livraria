using Livraria.Domain;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Persistence.Contexto
{
    public class LivrariaContexto : DbContext
    {
        public LivrariaContexto(DbContextOptions<LivrariaContexto> options) : base(options)
        {
        }
        public DbSet<Livro> Livros { get; set; }

        public DbSet<Editora> Editoras { get; set; }

        public DbSet<Autor> Autores { get; set; }
        public DbSet<AutorLivro> AutoresLivros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AutorLivro>()
                .HasKey(AL => new {AL.AutorId, AL.LivroId});
        }
    }
}
