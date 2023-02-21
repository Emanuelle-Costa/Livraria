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

    }
}
