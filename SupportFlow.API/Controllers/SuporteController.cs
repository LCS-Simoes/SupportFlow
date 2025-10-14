using Microsoft.AspNetCore.Mvc;
using SupportFlow.Application.DTOs.SuporteDTOs;
using SupportFlow.Application.UseCases.Suportes;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SupportFlow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuporteController : ControllerBase
    {
        private readonly AtualizarSuporteUseCase _atualizar;
        private readonly ListarSuporteUseCase _listarTodos;
        private readonly BuscarSuporteIdUseCase _buscarID;
        private readonly DeletarSuporteUseCase _deletar;
        private readonly CriarSuporteUseCase _criar;


        public SuporteController(AtualizarSuporteUseCase atualizar, ListarSuporteUseCase listar, BuscarSuporteIdUseCase buscar,
            DeletarSuporteUseCase deletar, CriarSuporteUseCase criar)
        {
            _atualizar = atualizar;
            _listarTodos = listar;
            _buscarID = buscar;
            _deletar = deletar;
            _criar = criar;
        }

        //Chamada para Listar todas as tarefas
        [HttpGet]
        public async Task<ActionResult> TodosChamados()
        {
            var suportes = await _listarTodos.Handle();
            return Ok(suportes);
        }

        //Chamado para buscar por ID
        [HttpGet("{id}")]
        public async Task<ActionResult> BuscarID(int id)
        {
            var suportes = await _buscarID.Handle(id);
            return Ok(suportes);
        }

        //Chamada para criar
        [HttpPost]
        public async Task<ActionResult> Cadastrar([FromBody] CriarSuporteResquest request)
        {
            var suporte = await _criar.ExecuteAsync(request);
            return Ok(suporte);
        }

        //Chamada para atualizar
        [HttpPut("{id}")]
        public async Task<ActionResult> Atualizar(int id, [FromBody] AtualizarSuporteRequest request)
        {

            var suporte = await _atualizar.Handle(id, request);
            return Ok(suporte);
        }

        //Chamada para o delete
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var resultado = await _deletar.Handle(id);

            if (resultado)
                return NoContent();

            return NotFound();
        }
    }
}
