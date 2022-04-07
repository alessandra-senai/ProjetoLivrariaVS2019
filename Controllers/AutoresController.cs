using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoLivrariaVS2019.Controllers
{
    [ApiController]
    [ApiVersion("1.0", Deprecated = true)]
    [Route("api/autores")]
    public class AutoresController : ControllerBase
    {

        [HttpGet]
        public IEnumerable<Autor> Get()
        {
            return  new List<Autor>()
            {
                new Autor { Ativo = true, DataNascimento = new DateTime(1980, 05, 24), Id = 1, Nome = "Maria" }
            };
        }


        [HttpGet("{id}")]
        public Autor Get(int id)
        {
            List<Autor> autores = new()
            {
                new Autor { Ativo = true, DataNascimento = new DateTime(1980, 05, 24), Id = 1, Nome = "Maria" },
                new Autor { Ativo = false, DataNascimento = new DateTime(1970, 01, 10), Id = 2, Nome = "Paulo" }
            };

            return autores.FirstOrDefault(_ => _.Id == id) ?? new Autor();
        }


        [HttpPost]
        public void Post([FromBody] Autor autor)
        {
            List<Autor> autores = new()
            {
                new Autor { Ativo = true, DataNascimento = new DateTime(1980, 05, 24), Id = 1, Nome = "Maria" },
                new Autor { Ativo = false, DataNascimento = new DateTime(1970, 01, 10), Id = 2, Nome = "Paulo" }
            };

            autores.Add(autor);

        }

        // PUT api/<AutoresController>/5
        [HttpPut("{id}")]
        public Autor Put(int id, [FromBody] Autor autor)
        {
            List<Autor> autores = new()
            {
                new Autor { Ativo = true, DataNascimento = new DateTime(1980, 05, 24), Id = 1, Nome = "Maria" },
                new Autor { Ativo = false, DataNascimento = new DateTime(1970, 01, 10), Id = 2, Nome = "Paulo" }
            };

            var autorAlterar = autores.Where(x => x.Id == id)
                                         .Select(x =>
                                            new Autor
                                            {
                                                Id = x.Id,
                                                Nome = autor.Nome,
                                                Ativo = autor.Ativo,
                                                DataNascimento = autor.DataNascimento
                                            })
                                         .FirstOrDefault();

            return autorAlterar;

        }

        // DELETE api/<AutoresController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            List<Autor> autores = new()
            {
                new Autor { Ativo = true, DataNascimento = new DateTime(1980, 05, 24), Id = 1, Nome = "Maria" },
                new Autor { Ativo = false, DataNascimento = new DateTime(1970, 01, 10), Id = 2, Nome = "Paulo" }
            };



            autores.Remove(autores.Single(x => x.Id == id));

            autores.RemoveAll(x => x.Id == id);

        }
    }
}
