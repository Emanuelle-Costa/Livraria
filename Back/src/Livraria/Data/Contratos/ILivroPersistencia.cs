using Livraria.Models;

namespace Livraria.Data.Contratos
{
    public interface ILivroPersistencia
    {
        Task<Livro[]> PegarTodosLivrosPeloTitulo(string titulo);
         Task<Livro[]> PegarTodosLivrosPeloAutor(string autor);
        Task<Livro[]> PegarTodosLivros();
        Task<Livro> PegarLivroPeloId(int livroId);
    	Task<Livro[]> PegarTodosLivrosPelaEditora(string editora);
        Task<Livro[]> PegarTodosLivrosPelaEdicao(int edicao);
    }
}