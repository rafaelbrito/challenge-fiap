using Contatos.Application.DTOs;
using Contatos.Application.UseCases.Contatos;
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
        public ContatosController(
            CreateContato createContato,
            GetContato getContato,
            UpdateContato updateContato,
            DeleteContato deleteContato)
        {
            _createContato = createContato;
            _getContato = getContato;
            _updateContato = updateContato;
            _deleteContato = deleteContato;
        }

        // POST: api/v1/contatos
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ContatoInputDto input)
        {
            var contato = await _createContato.CreateAsync(input);
            return CreatedAtAction(nameof(GetById), new { id = contato.Id }, contato);
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

        // PUT: api/v1/contatos/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ContatoInputDto input)
        {
            try
            {
                var contato = await _updateContato.UpdateContatoAsync(id, input);
                return Ok(contato);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // DELETE: api/v1/contatos/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _deleteContato.DeleteContatoAsync(id);
            if (result)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
