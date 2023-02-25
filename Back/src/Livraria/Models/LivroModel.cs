using Livraria.Data.Contratos;
using Livraria.Models.Contratos;

namespace Livraria.Models
{
    public class LivroModel : ILivroModel
    {
        private readonly IGeralPersistencia _geralPersistencia;
        private readonly ILivroPersistencia _livroPersistencia;

        public LivroModel(IGeralPersistencia geralPersistencia, ILivroPersistencia livroPersistencia)
        {
            _livroPersistencia = livroPersistencia;
            _geralPersistencia = geralPersistencia;
            
        }

        public async Task<Livro> AdicionarLivro(Livro model)
        {
            try
            {
                _geralPersistencia.Adicionar<Livro>(model);
                if(await _geralPersistencia.SalvarAlteracoes())
                {
                    return await _livroPersistencia.PegarLivroPeloId(model.Id);
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
                var livro = await _livroPersistencia.PegarLivroPeloId(livroId);
                if (livro == null) return null;

                model.Id = livro.Id;

                _geralPersistencia.Atualizar(model);
                if (await _geralPersistencia.SalvarAlteracoes())
                {
                    return await _livroPersistencia.PegarLivroPeloId(model.Id);
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
                var livro = await _livroPersistencia.PegarLivroPeloId(livroId);
                if (livro == null) throw new Exception("Livro não encontrado!");

                _geralPersistencia.Deletar<Livro>(livro);
                return await _geralPersistencia.SalvarAlteracoes();
            }
            catch (Exception erro)
            {
                
                throw new Exception(erro.Message);
            }
        }

        public async Task<Livro[]> PegarTodosLivros()
        {
           try
           {
                var livros = await _livroPersistencia.PegarTodosLivros();
                if(PegarTodosLivros == null) return null;

                return livros;
           }
           catch (Exception erro)
           {
            
                throw new Exception(erro.Message);
           }
        }

        public async Task<Livro[]> PegarTodosLivrosPeloTitulo(string titulo)
        {
            try
           {
                var livros = await _livroPersistencia.PegarTodosLivrosPeloTitulo(titulo);
                if(PegarTodosLivros == null) return null;

                return livros;
           }
           catch (Exception erro)
           {
            
                throw new Exception(erro.Message);
           }
        }

        public async Task<Livro[]> PegarTodosLivrosPelaEditora(string editora)
        {
            try
           {
                var livros = await _livroPersistencia.PegarTodosLivrosPelaEditora(editora);
                if(PegarTodosLivros == null) return null;

                return livros;
           }
           catch (Exception erro)
           {
            
                throw new Exception(erro.Message);
           }
        }

        public async Task<Livro[]> PegarTodosLivrosPelaEdicao(int edicao)
        {
            try
           {
                var livros = await _livroPersistencia.PegarTodosLivrosPelaEdicao(edicao);
                if(PegarTodosLivros == null) return null;

                return livros;
           }
           catch (Exception erro)
           {
            
                throw new Exception(erro.Message);
           }
        }

        

        public async Task<Livro> PegarLivroPeloId(int livroId)
        {
           try
           {
                var livros = await _livroPersistencia.PegarLivroPeloId(livroId);
                if(PegarTodosLivros == null) return null;

                return livros;
           }
           catch (Exception erro)
           {
            
                throw new Exception(erro.Message);
           }
        }

    }
}
