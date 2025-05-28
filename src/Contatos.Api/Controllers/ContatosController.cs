using Contatos.Application.UseCases.Contatos;
using Contatos.Message.Messages;
using MassTransit;
using MassTransit.Transports;
using Microsoft.AspNetCore.Mvc;

namespace Contatos.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ContatosController : ControllerBase
    {
        private readonly CreateContato _createContato;
        private readonly GetContato _getContato;
        private readonly UpdateContato _updateContato;
        private readonly DeleteContato _deleteContato;
        private readonly ISendEndpointProvider _publishEndpoint;
        public ContatosController(
            CreateContato createContato,
            GetContato getContato,
            UpdateContato updateContato,
            DeleteContato deleteContato,
                    ISendEndpointProvider publishEndpoint)
        {
            _createContato = createContato;
            _getContato = getContato;
            _updateContato = updateContato;
            _deleteContato = deleteContato;
            _publishEndpoint = publishEndpoint;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateContatoMessage input)
        {
            var endpoint = await _publishEndpoint.GetSendEndpoint(new Uri("queue:CreateContato"));
            await endpoint.Send(input);
            return Accepted();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateContatoMessage input)
        {
            var endpoint = await _publishEndpoint.GetSendEndpoint(new Uri("queue:UpdateContato"));
            await endpoint.Send(input);
            return Accepted();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteContatoMessage input)
        {
            var endpoint = await _publishEndpoint.GetSendEndpoint(new Uri("queue:DeleteContato"));
            await endpoint.Send(input);
            return Accepted();
        }

        // GET: api/v1/contatos
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var contatos = await _getContato.GetAllContatosAsync();
            return Ok(contatos);
        }

        // GET: api/v1/contatos/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var contato = await _getContato.GetContatoByIdAsync(id);
            if (contato == null)
            {
                return NotFound();
            }

            return Ok(contato);
        }

        // GET: api/v1/contatos/ddd/{ddd}
        [HttpGet("ddd/{ddd}")]
        public async Task<IActionResult> GetByDdd(string ddd)
        {
            var contatos = await _getContato.GetContatosByDddAsync(ddd);
            return Ok(contatos);
        }

        // GET: api/v1/contatos/nome/{nome}
        [HttpGet("nome/{nome}")]
        public async Task<IActionResult> GetByNome(string nome)
        {
            var contatos = await _getContato.GetContatosByNomeAsync(nome);
            return Ok(contatos);
        }

        // GET: api/v1/contatos/email/{email}
        [HttpGet("email/{email}")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            var contatos = await _getContato.GetContatosByEmailAsync(email);
            return Ok(contatos);
        }

        // GET: api/v1/contatos/telefone/{telefone}
        [HttpGet("telefone/{telefone}")]
        public async Task<IActionResult> GetByTelefone(string telefone)
        {
            var contatos = await _getContato.GetContatosByTelefoneAsync(telefone);
            return Ok(contatos);
        }
    }
}
