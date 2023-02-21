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

        Task<Livro> PegarLivroPeloId(int livroId);
        Task<Livro[]> PegarTodosLivros();
        Task<Livro[]> PegarTodosLivrosPeloTitulo(string titulo);
        Task<Livro[]> PegarTodosLivrosPeloAutor(string autor);
        Task<Livro[]> PegarTodosLivrosPelaEditora(string editora);
        Task<Livro[]> PegarTodosLivrosPelaEdicao(int edicao);

        Task<bool> SalvarAlteracoes();

        

    }
}