using ClinicAPI.DTO;
using ClinicAPI.Interfaces.Services;
using ClinicAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
/*
    listar todos os actos clinicos - get
    obter acto clinico especifico - get
    criar novo acto clinico - post
    actualizar acto clinico - put
    */
namespace ClinicAPI.Controllers
{
    [ApiController]
    public class ActosClinicosController : ControllerBase
    {
        private readonly IActoClinicoServices actoClinicoServices;
        public ActosClinicosController(IActoClinicoServices actoClinicoServices)
        {
            this.actoClinicoServices = actoClinicoServices;
        }

        //listar actos clínicos
        [HttpGet, Route("ListarActos")]
        public IActionResult ListarActos()
        {
            var lista = actoClinicoServices.Listar();
            return Ok(lista);
        }

        //busca singular
        [HttpGet, Route("ObterActo")]
        public IActionResult ObterActo(int id)
        {
            var todos = actoClinicoServices.Listar();
            var user = todos.FirstOrDefault(u => u.Id == id);
            if (user == null)
                return NotFound(new { message = "Acto não encontrado." });
            return Ok(user);
        }

        //criar acto clinico
        [HttpPost, Route("CriarActo")]
        public IActionResult CriarActo(CriarActoClinicoDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var criado = actoClinicoServices.Criar(dto);
            return CreatedAtAction(nameof(ObterActo), new { id = actoClinicoServices.Criar(dto).Id }, criado);
        }

        // actualizar acto clinico
        [HttpPut, Route("ActualizarActo")]
        public IActionResult ActualizarActo(int id, ActualizarActoClinicoDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(actoClinicoServices.Actualizar(id, dto));
        }
    }
}
