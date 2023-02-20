using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Livraria.Application;
using Livraria.Domain;
using Livraria.Persistence;

namespace Livraria.Application
{
    public class LivroService : ILivroService
    {

        private readonly ILivroPersistence _livroPersistence;
        public LivroService(ILivroPersistence livroPersistence)
        {
            _livroPersistence = livroPersistence;
        }

        public async Task<Livro> AdicionarLivro(Livro model)
        {
            try
            {
                _livroPersistence.Adicionar<Livro>(model);
                if(await _livroPersistence.SalvarAlteracoes())
                {
                    return await _livroPersistence.PegarLivroPeloId(model.Id, false);
                }
                return null;
            }
            catch (Exception erro)
            {
                
                throw new Exception(erro.Message);
            }
        }

        public async Task<Livro> AtualizarLivro(int livroId, Livro model)
        {
            try
            {
                var livro = await _livroPersistence.PegarLivroPeloId(livroId, false);
                if (livro == null) return null;

                model.Id = livro.Id;

                _livroPersistence.Atualizar(model);
                if (await _livroPersistence.SalvarAlteracoes())
                {
                    return await _livroPersistence.PegarLivroPeloId(model.Id, false);
                }
                return null;
            }
            catch (Exception erro)
            {
                
                throw new Exception(erro.Message);
            }
        }

        public async Task<bool> DeletarLivro(int livroId)
        {
            try
            {
                var livro = await _livroPersistence.PegarLivroPeloId(livroId, false);
                if (livro == null) throw new Exception("Livro não encontrado!");

                _livroPersistence.Deletar<Livro>(livro);
                return await _livroPersistence.SalvarAlteracoes();
            }
            catch (Exception erro)
            {
                
                throw new Exception(erro.Message);
            }
        }

        public async Task<Livro> PegarLivroPeloId(int livroId, bool includeAutor = false)
        {
            try
           {
                var livro = await _livroPersistence.PegarLivroPeloId(livroId, includeAutor);
                if(livro == null) return null;

                return livro;
           }
           catch (Exception erro)
           {
            
                throw new Exception(erro.Message);
           }
        }

        public async Task<Livro[]> PegarTodosLivros(bool includeAutor = false)
        {
            try
           {
                var livros = await _livroPersistence.PegarTodosLivros(includeAutor);
                if(livros == null) return null;

                return livros;
           }
           catch (Exception erro)
           {
            
                throw new Exception(erro.Message);
           }
        }

        public async Task<Livro[]> PegarTodosLivrosPelaEdicao(int edicao, bool includeAutor = false)
        {
            try
           {
                var livros = await _livroPersistence.PegarTodosLivrosPelaEdicao(edicao, includeAutor);
                if(livros == null) return null;

                return livros;
           }
           catch (Exception erro)
           {
            
                throw new Exception(erro.Message);
           }
        }

        public async Task<Livro[]> PegarTodosLivrosPelaEditora(Editora editora, bool includeAutor = false)
        {
            try
           {
                var livros = await _livroPersistence.PegarTodosLivrosPelaEditora(editora, includeAutor);
                if(livros == null) return null;

                return livros;
           }
           catch (Exception erro)
           {
            
                throw new Exception(erro.Message);
           }
        }

        public async Task<Livro[]> PegarTodosLivrosPeloAutor(AutorLivro autor, bool includeAutor = false)
        {
            try
           {
                var livros = await _livroPersistence.PegarTodosLivrosPeloAutor(autor, includeAutor);
                if(livros == null) return null;

                return livros;
           }
           catch (Exception erro)
           {
            
                throw new Exception(erro.Message);
           }
        }

        public async Task<Livro[]> PegarTodosLivrosPeloTitulo(string titulo, bool includeAutor = false)
        {
            try
           {
                var livros = await _livroPersistence.PegarTodosLivrosPeloTitulo(titulo, includeAutor);
                if(livros == null) return null;

                return livros;
           }
           catch (Exception erro)
           {
            
                throw new Exception(erro.Message);
           }
        }
    }
}