using Livraria.Data.Contratos;
using Livraria.Models;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Data
{
    public class LivroPersistencia : ILivroPersistencia
    {
        private readonly ContextoBanco _context;

        public LivroPersistencia(ContextoBanco context)
        {
            _context = context;

        }
        public async Task<Livro[]> PegarTodosLivros()
        {
            IQueryable<Livro> consulta = _context.Livros;

            consulta = consulta.AsNoTracking().OrderBy(l => l.Titulo);

            return await consulta.ToArrayAsync();
        }

        public async Task<Livro[]> PegarTodosLivrosPeloTitulo(string titulo)
        {
            IQueryable<Livro> consulta = _context.Livros;

            consulta = consulta.AsNoTracking().OrderBy(l => l.Titulo)
                               .Where(l => l.Titulo.ToLower().Contains(titulo.ToLower()));

            return await consulta.ToArrayAsync();
        }

        public async Task<Livro[]> PegarTodosLivrosPeloAutor(string autor)
        {
            IQueryable<Livro> consulta = _context.Livros;

            consulta = consulta.AsNoTracking().OrderBy(l => l.Titulo)
                               .Where(l => l.Autor.ToLower().Contains(autor.ToLower()));

            return await consulta.ToArrayAsync();
        }

        public async Task<Livro[]> PegarTodosLivrosPelaEditora(string editora)
        {
            IQueryable<Livro> consulta = _context.Livros;

            consulta = consulta.AsNoTracking().OrderBy(l => l.Titulo)
                               .Where(l => l.Editora.ToLower().Contains(editora.ToLower()));

            return await consulta.ToArrayAsync();
        }

        public async Task<Livro[]> PegarTodosLivrosPelaEdicao(int edicao)
        {
            IQueryable<Livro> consulta = _context.Livros;

            consulta = consulta.AsNoTracking().OrderBy(l => l.Titulo)
                               .Where(l => l.Edicao == edicao);

            return await consulta.ToArrayAsync();
        }


        public async Task<Livro> PegarLivroPeloId(int livroId)
        {
            IQueryable<Livro> consulta = _context.Livros;
            
            consulta = consulta.AsNoTracking().OrderBy(l => l.Id)
                               .Where(l => l.Id == livroId);

            return await consulta.FirstOrDefaultAsync();
        }

        
    }
}