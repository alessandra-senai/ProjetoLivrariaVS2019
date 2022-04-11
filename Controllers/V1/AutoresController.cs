using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjetoLivrariaVS2019.Context;
using ProjetoLivrariaVS2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLivrariaVS2019.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/autores")]
    public class AutoresController : ControllerBase
    {
        private readonly LivrariaContext _livrariaContext;
        private readonly ILogger<AutoresController> _logger;

        public AutoresController(LivrariaContext livrariaContext, ILogger<AutoresController> logger)
        {
            _livrariaContext = livrariaContext;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _livrariaContext.Autors
                    .Include(x => x.LivroAutors)
                    .ToListAsync()
                    .ConfigureAwait(true));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Class:{nameof(AutoresController)}-Method:{nameof(Get)}");
                return StatusCode(500);
            }

        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return Ok(await _livrariaContext.Autors
                    .Include(x => x.LivroAutors)
                    .FirstOrDefaultAsync(x => x.Id == id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Class:{nameof(AutoresController)}-Method:{nameof(GetById)}");
                return StatusCode(500);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Autor autor)
        {
            try
            {
                _livrariaContext.Autors.Add(autor);

                await _livrariaContext.SaveChangesAsync();

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Class:{nameof(AutoresController)}-Method:{nameof(Post)}");
                return StatusCode(500);
            }

        }

        // PUT api/<AutoresController>/5
        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] Autor autor)
        {
            try
            {
                _livrariaContext.Entry(autor).State = EntityState.Modified;
                await _livrariaContext.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Class:{nameof(AutoresController)}-Method:{nameof(Put)}");
                return StatusCode(500);
            }

        }

        // DELETE api/<AutoresController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var autorDelete = await _livrariaContext.Autors.FindAsync(id);

                if (autorDelete is null)
                {
                    return NotFound();
                }

                _livrariaContext.Autors.Remove(autorDelete);

                await _livrariaContext.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Class:{nameof(AutoresController)}-Method:{nameof(Delete)}");
                return StatusCode(500);
            }

        }
    }
}
