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
        
        Task<Livro> PegarLivroPeloId(int livroId);
        Task<Livro[]> PegarTodosLivros();
        Task<Livro[]> PegarTodosLivrosPeloTitulo(string titulo);
        Task<Livro[]> PegarTodosLivrosPeloAutor(string autor);
        Task<Livro[]> PegarTodosLivrosPelaEditora(string editora);
        Task<Livro[]> PegarTodosLivrosPelaEdicao(int edicao);
    }
}