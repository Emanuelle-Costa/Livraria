namespace Livraria.Models
{
    public class Livro
    {
        public string ImagemURL { get; set; } 
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string? Subtitulo { get; set; }
        public string? Resumo { get; set; }
        public int QntPaginas { get; set; }
        public DateTime DataPublicacao { get; set; }
        public int? Edicao { get; set; }
        public string Editora { get; set; }
        public double Preco { get; set; }
        public int QntLivroEmEstoque { get; set; }
        public string Autor { get; set; }

    }
}