using Livraria.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Persistence
{
    public interface ILivroPersistence
    {

        void Adicionar<Dados>(Dados entidade) where Dados : class;
        void Atualizar<Dados>(Dados entidade) where Dados : class;
        void Deletar<Dados>(Dados entidade) where Dados : class;
        void DeletarVarios<Dados>(Dados[] entidade) where Dados : class;

        Task<Livro> PegarLivroPeloId(int livroId, bool includeAutor = false);
        Task<Livro[]> PegarTodosLivros(bool includeAutor = false);
        Task<Livro[]> PegarTodosLivrosPeloTitulo(string titulo, bool includeAutor = false);
        Task<Livro[]> PegarTodosLivrosPeloAutor(AutorLivro autor, bool includeAutor = false);
        Task<Livro[]> PegarTodosLivrosPelaEditora(Editora editora, bool includeAutor = false);
        Task<Livro[]> PegarTodosLivrosPelaEdicao(int edicao, bool includeAutor = false);

        Task<bool> SalvarAlteracoes();

        

    }
}