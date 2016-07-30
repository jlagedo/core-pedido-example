using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pedido.Service.Contracts;
using Pedido.Model.Services;
using Pedido.Model.Commands;
using System.Diagnostics;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Pedido.Service.Controllers
{
    [Route("api/[controller]")]
    public class PedidoController : Controller
    {
        private readonly IPedidoCadastroService pedidoService;

        public PedidoController(IPedidoCadastroService pedidoService)
        {
            this.pedidoService = pedidoService;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
