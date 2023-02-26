using Livraria.Models;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Data
{
    public class ContextoBanco : DbContext
    {
         public ContextoBanco(DbContextOptions<ContextoBanco> options) : base(options)
        {

        }
        public DbSet<Livro> Livros { get; set; }
       
    }
    
}