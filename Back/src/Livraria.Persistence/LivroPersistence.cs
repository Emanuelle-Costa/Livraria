using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Livraria.Domain;
using Microsoft.EntityFrameworkCore;
using Livraria.Persistence.Contexto;

namespace Livraria.Persistence
{
    public class LivroPersistence : ILivroPersistence
    {

        private readonly LivrariaContexto _context;

        public LivroPersistence(LivrariaContexto context)
        {
            _context = context;
           
            
        }

        public async Task<Livro> PegarLivroPeloId(int livroId, bool includeAutor = false)
        {
            IQueryable<Livro> consulta = _context.Livros;

            consulta = consulta.AsNoTracking().OrderBy(l => l.Id)
                               .Where(l => l.Id == livroId);

            return await consulta.FirstOrDefaultAsync();
        }       
         public async Task<Livro[]> PegarTodosLivros(bool includeAutor = false)
        {
            IQueryable<Livro> consulta = _context.Livros;
            
            consulta = consulta.AsNoTracking().OrderBy(l => l.Titulo);

            return await consulta.ToArrayAsync();
        }

        public async Task<Livro[]> PegarTodosLivrosPeloTitulo(string titulo, bool includeAutor = false)
        {
            IQueryable<Livro> consulta = _context.Livros;
            
            consulta = consulta.AsNoTracking().OrderBy(l => l.Titulo)
                               .Where(l => l.Titulo.ToLower().Contains(titulo.ToLower()));

            return await consulta.ToArrayAsync();
        }
        public async Task<Livro[]> PegarTodosLivrosPeloAutor(AutorLivro autor, bool includeAutor = false)
        {
            IQueryable<Livro> consulta = _context.Livros;
            
            consulta = consulta.AsNoTracking().OrderBy(l => l.AutoresLivro);

            return await consulta.ToArrayAsync();
        }

        public async Task<Livro[]> PegarTodosLivrosPelaEditora(Editora editora, bool includeAutor = false)
        {
            IQueryable<Livro> consulta = _context.Livros;
            
            consulta = consulta.AsNoTracking().OrderBy(l => l.Editora);

            return await consulta.ToArrayAsync();
        }

        public async Task<Livro[]> PegarTodosLivrosPelaEdicao(int edicao, bool includeAutor = false)
        {
            IQueryable<Livro> consulta = _context.Livros;
            
            consulta = consulta.AsNoTracking().OrderBy(l => l.Edicao);
                              
            return await consulta.ToArrayAsync();
        }

        public void Adicionar<Dados>(Dados entidade) where Dados : class
        {
            _context.Add(entidade);
        }

        public void Atualizar<Dados>(Dados entidade) where Dados : class
        {
            _context.Update(entidade);
        }

        public void Deletar<Dados>(Dados entidade) where Dados : class
        {
            _context.Remove(entidade);
        }

        public void DeletarVarios<Dados>(Dados[] entidadeLista) where Dados : class
        {
            _context.RemoveRange(entidadeLista);
        }

        public async Task<bool> SalvarAlteracoes()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}