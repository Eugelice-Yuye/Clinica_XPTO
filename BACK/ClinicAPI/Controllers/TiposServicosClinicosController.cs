using ClinicAPI.DTO;
using ClinicAPI.Interfaces.Services;
using ClinicAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
/*
     listar consultas e exames - get
     obter específico - get
     criar novo acto clinico (admin) - post
     actualizar (admin) - put
     */
namespace ClinicAPI.Controllers
{
    [ApiController]
    public class TiposServicosClinicosController : ControllerBase
    {
        private readonly ITipoServicoClinicoServices tipoServicoClinicoServices;
        public TiposServicosClinicosController(ITipoServicoClinicoServices tipoServicoClinicoServices)
        {
            this.tipoServicoClinicoServices = tipoServicoClinicoServices;
        }

        //listar consultas e exames
        [HttpGet, Route("ListarServicosClinicos")]
        public IActionResult ListarServicosClinicos()
        {
            var lista = tipoServicoClinicoServices.Listar();
            return Ok(lista);
        }

        //busca singular
        [HttpGet,Route("ObterServico")]
        public IActionResult ObterServico(int id)
        {
            var todos = tipoServicoClinicoServices.Listar();
            var user = todos.FirstOrDefault(u => u.Id == id);
            if (user == null)
                return NotFound(new { message = "Serviço não encontrado." });
            return Ok(user);
        }

        //criar serviço
        [HttpPost, Route("CriarServico")]
        public IActionResult CriarServico(TipoServicoClinicoDto dto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            return CreatedAtAction(nameof(ObterServico), new {id = tipoServicoClinicoServices.Criar(dto).Id},null);
        }

        // actualizar serviço
        [HttpPut, Route("ActualizarServico")]
        public IActionResult ActualizarServico(int id, TipoServicoClinicoDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(tipoServicoClinicoServices.Actualizar(id,dto));
        }
    }
}
