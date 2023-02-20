using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Livraria.Domain;

namespace Livraria.Application
{
    public interface ILivroService
    {
        Task<Livro> AdicionarLivro(Livro model);
        Task<Livro> AtualizarLivro(int livroId, Livro model);
        Task<bool> DeletarLivro(int livroId);
        
        Task<Livro> PegarLivroPeloId(int livroId, bool includeAutor = false);
        Task<Livro[]> PegarTodosLivros(bool includeAutor = false);
        Task<Livro[]> PegarTodosLivrosPeloTitulo(string titulo, bool includeAutor = false);
        Task<Livro[]> PegarTodosLivrosPeloAutor(AutorLivro autor, bool includeAutor = false);
        Task<Livro[]> PegarTodosLivrosPelaEditora(Editora editora, bool includeAutor = false);
        Task<Livro[]> PegarTodosLivrosPelaEdicao(int edicao, bool includeAutor = false);
    }
}