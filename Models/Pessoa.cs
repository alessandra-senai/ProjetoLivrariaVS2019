using System;
using System.Collections.Generic;

#nullable disable

namespace ProjetoLivrariaVS2019.Models
{
    public partial class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string EstadoCivil { get; set; }
    }
}
