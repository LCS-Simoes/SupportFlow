using Microsoft.AspNetCore.Mvc;
using SupportFlow.Application.DTOs;
using SupportFlow.Application.UseCases.Usuarios;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SupportFlow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly CriarUsuarioUseCase _criarUsuario;
        private readonly ListarUsuarioUseCase _listarUsuario;
        private readonly BuscarUsuarioIdUseCase _buscarUsuario;
        private readonly AtualizarUsuarioUseCase _atualizarUsuario;
        private readonly DeletarUsuarioUseCase _deletarUsuario;

        public UsuarioController(CriarUsuarioUseCase criar, ListarUsuarioUseCase listar, BuscarUsuarioIdUseCase buscar,
            AtualizarUsuarioUseCase atualizar, DeletarUsuarioUseCase deletar) 
        {
            _criarUsuario = criar;
            _listarUsuario = listar;
            _buscarUsuario = buscar;
            _atualizarUsuario= atualizar;
            _deletarUsuario = deletar;
        }

        [HttpGet]
        public async Task<ActionResult> TodosUsuarios()
        {
            var usuarios = await _listarUsuario.Handle();
            return Ok(usuarios);
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> BuscarId(int id)
        {
            var usuario = await _buscarUsuario.Handle(id);
            return Ok(usuario);
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public async Task<ActionResult> Cadastrar([FromBody] CriarUsuarioRequest request)
        {
            var usuario = await _criarUsuario.ExecuteAsync(request);
            return Ok(usuario);
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Atualizar(int id, [FromBody] AtualizarUsuarioRequest request)
        {
            var usuario = await _atualizarUsuario.Handle(id, request);
            return Ok(usuario);
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var resultado = await _deletarUsuario.Handle(id);

            if (resultado)
                return NoContent();

            return NotFound();
        }
    }
}
