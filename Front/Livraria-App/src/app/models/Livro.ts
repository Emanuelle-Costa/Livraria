export interface Livro {
  id: number;
  titulo: string;
  subtitulo?: string;
  resumo?: string;
  qntPaginas: number;
  dataPublicacao: Date;
  edicao?: number;
  editora: string;
  autor: string;
  preco: number;
  qntLivroEmEstoque: number;
}
