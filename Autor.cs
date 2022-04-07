using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetoLivrariaVS2019
{
    public class Autor
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Favor preencher o campo Nome")]
        [StringLength(200)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Favor preencher o campo Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Ator Status")]
        public bool Ativo { get; set; }
    }
}
