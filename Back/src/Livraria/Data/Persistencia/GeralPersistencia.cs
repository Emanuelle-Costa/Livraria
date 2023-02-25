using Livraria.Data.Contratos;

namespace Livraria.Data
{
    public class GeralPersistencia : IGeralPersistencia
    {
        private readonly ContextoBanco _context;

        public GeralPersistencia(ContextoBanco context)
        {
            _context = context;

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