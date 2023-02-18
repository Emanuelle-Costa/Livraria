using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Domain
{
    public class AutorLivro
    {
        public int AutorId { get; set; }
        public Autor Autor { get; set; }
        public int LivroId { get; set; }
        public Livro Livro { get; set; }

    }
}