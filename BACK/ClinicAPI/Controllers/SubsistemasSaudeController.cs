using ClinicAPI.DTO;
using ClinicAPI.Interfaces.Services;
using ClinicAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
/*
    listar susbsistemas - get
    sistema especifico - get

    */
namespace ClinicAPI.Controllers
{
    [ApiController]
    public class SubsistemasSaudeController : ControllerBase
    {
        private readonly ISubsistemaSaudeServices subsistemaSaudeServices;
        public SubsistemasSaudeController(ISubsistemaSaudeServices subsistemaSaudeServices)
        {
            this.subsistemaSaudeServices = subsistemaSaudeServices;
        }

        //listar susbsistema
        [HttpGet, Route("ListarSubsistemas")]
        public IActionResult ListarSubsistemas()
        {
            var lista = subsistemaSaudeServices.Listar();
            return Ok(lista);
        }

        //busca singular
        [HttpGet, Route("ObterSubsistema")]
        public IActionResult ObterSubsistema(int id)
        {
            var todos = subsistemaSaudeServices.Listar();
            var user = todos.FirstOrDefault(u => u.Id == id);
            if (user == null)
                return NotFound(new { message = "Subsistema não encontrado." });
            return Ok(user);
        }

        //criar susbsistema
        [HttpPost, Route("CriarSubsistema")]
        public IActionResult CriarSubsistema(SubsistemaSaudeDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return CreatedAtAction(nameof(ObterSubsistema), new { id = subsistemaSaudeServices.Criar(dto).Id }, null);
        }
    }
}
