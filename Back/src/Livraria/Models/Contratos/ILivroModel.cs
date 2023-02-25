namespace Livraria.Models.Contratos
{
    public interface ILivroModel
    {
        Task<Livro> AdicionarLivro(Livro model);
        Task<Livro> AtualizarLivro(int livroId, Livro model);
        Task<bool> DeletarLivro(int livroId);


        Task<Livro[]> PegarTodosLivros();
        Task<Livro[]> PegarTodosLivrosPeloTitulo(string titulo); 
        Task<Livro[]> PegarTodosLivrosPelaEditora(string editora);
        Task<Livro[]> PegarTodosLivrosPelaEdicao(int edicao);
        Task<Livro> PegarLivroPeloId(int LivroId);

    }
}