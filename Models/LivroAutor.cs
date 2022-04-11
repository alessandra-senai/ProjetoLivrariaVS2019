using System;
using System.Collections.Generic;

#nullable disable

namespace ProjetoLivrariaVS2019.Models
{
    public partial class LivroAutor
    {
        public int Id { get; set; }
        public int IdLivro { get; set; }
        public int IdAutor { get; set; }

        public virtual Autor IdAutorNavigation { get; set; }
        public virtual Livro IdLivroNavigation { get; set; }
    }
}
