
namespace Livraria.Domain
{
    public class Autor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public IEnumerable<AutorLivro> LivrosAutor { get; set; }
        
        public Autor(int id, string nome)
        {
            this.Id = id;
            this.Nome = nome;
        }

        public Autor()
        {
            
        }
    }
}
