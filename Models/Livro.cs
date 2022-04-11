using System;
using System.Collections.Generic;

#nullable disable

namespace ProjetoLivrariaVS2019.Models
{
    public partial class Livro
    {
        public Livro()
        {
            LivroAutors = new HashSet<LivroAutor>();
        }

        public int Id { get; set; }
        public int NumPagina { get; set; }
        public string Nome { get; set; }
        public DateTime DataPublicacao { get; set; }
        public string Genero { get; set; }
        public bool? Ativo { get; set; }
        public int? IdEditora { get; set; }

        public virtual Editora IdEditoraNavigation { get; set; }
        public virtual ICollection<LivroAutor> LivroAutors { get; set; }
    }
}
