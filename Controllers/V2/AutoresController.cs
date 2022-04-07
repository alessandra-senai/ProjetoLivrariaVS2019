using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ProjetoLivrariaVS2019.Controllers.V2
{
    [ApiController]
    [Route("api/autores")]
    [ApiVersion("2.0")]
    public class AutoresController : ControllerBase
    {
        [MapToApiVersion("2.0")]
        [HttpGet]
        public IEnumerable<Autor> Get()
        {
            return new List<Autor>()
            {
                new Autor { Ativo = true, DataNascimento = new DateTime(1980, 05, 24), Id = 1, Nome = "Maria" },
                new Autor { Ativo = false, DataNascimento = new DateTime(1970, 01, 10), Id = 2, Nome = "Paulo" }
            };
        }



    }
}
