namespace Livraria.Data.Contratos
{
    public interface IGeralPersistencia
    {
        void Adicionar<Dados>(Dados entidade) where Dados : class;
        void Atualizar<Dados>(Dados entidade) where Dados : class;
        void Deletar<Dados>(Dados entidade) where Dados : class;
        void DeletarVarios<Dados>(Dados[] entidade) where Dados : class;
        Task<bool> SalvarAlteracoes();

    }
}