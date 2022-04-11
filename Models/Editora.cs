using System;
using System.Collections.Generic;

#nullable disable

namespace ProjetoLivrariaVS2019.Models
{
    public partial class Editora
    {
        public Editora()
        {
            Livros = new HashSet<Livro>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public bool? Ativo { get; set; }

        public virtual ICollection<Livro> Livros { get; set; }
    }
}
