using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pedido.Service.Contracts;
using Pedido.Model.Services;
using Pedido.Model.Commands;
using System.Diagnostics;
using Pedido.Model;
using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Pedido.Service.Controllers
{
    [Route("api/[controller]")]
    public class PedidoController : Controller
    {
        private readonly IPedidoCadastroService pedidoService;
        private readonly IMemoryCache cache;
        private readonly ILogger<PedidoController> logger;

        public PedidoController(
            IPedidoCadastroService pedidoService,
            ILogger<PedidoController> logger,
            IMemoryCache memoryCache)
        {
            this.pedidoService = pedidoService;
            this.cache = memoryCache;
            this.logger = logger;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            string cacheKey = "pedido_" + id;
            PedidoCadastroDTO dto = null;

            try
            {
                if (!cache.TryGetValue(cacheKey, out dto))
                {
                    PedidoCadastro pedido = await pedidoService.PesquisarAsync(id);
                    dto = Mapper.Map<PedidoCadastroDTO>(pedido);

                    cache.Set(cacheKey, dto,
                          new MemoryCacheEntryOptions()
                          .SetAbsoluteExpiration(TimeSpan.FromMinutes(10)));
                    logger.LogInformation("Colocou objeto no cache key", cacheKey);

                }
                return Ok(dto);
            }
            catch (Exception ex)
            {
                Debug.Write(ex.ToString());
                return BadRequest();
            }

        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RegistroPedidoCadastroDTO value)
        {
            try
            {
                var command = new RegistroPedidoCadastroCommand
                {
                    IdPessoa = value.IdPessoa
                };
                await pedidoService.RegistrarAsync(command);

                return Ok();
            }
            catch (Exception ex)
            {
                Debug.Write(ex.ToString());
                return BadRequest();
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
