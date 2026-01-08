using ClinicAPI.DTO;
using ClinicAPI.Interfaces.Services;
using ClinicAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
/*
     listar profissionais - get
     obter profissional especifico - get
     criar novo profissional (admin) - post
     actualizar prof (admin) - put
     */
namespace ClinicAPI.Controllers
{
    [ApiController]
    public class ProfissionaisController : ControllerBase
    {
        private readonly IProfissionalServices profissionalServices;
        public ProfissionaisController(IProfissionalServices profissionalServices)
        {
            this.profissionalServices = profissionalServices;
        }

        //listar profissionais
        [HttpGet, Route("ListarProfissionais")]
        public IActionResult ListarProfissionais()
        {
            var lista = profissionalServices.Listar();
            return Ok(lista);
        }

        //busca singular
        [HttpGet, Route("ObterProfissional")]
        public IActionResult ObterProfissional(int id)
        {
            var todos = profissionalServices.Listar();
            var user = todos.FirstOrDefault(u => u.Id == id);
            if (user == null)
                return NotFound(new { message = "Profissional não encontrado." });
            return Ok(user);
        }

        //criar profissional
        [HttpPost, Route("CriarProfissional")]
        public IActionResult CriarProfissional(ProfissionalDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return CreatedAtAction(nameof(ObterProfissional), new { id = profissionalServices.Criar(dto).Id }, null);
        }

        //criar novo profissional (Exame)

        [HttpPost, Route("CriarNovoProf")]
        public IActionResult CriarNovoProf(NovoProfissionalDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return CreatedAtAction(nameof(ObterProfissional), new { id = profissionalServices.CriarP(dto) }, null);
            }

        // actualizar profissional
        [HttpPut, Route("ActualizarProfissional")]
        public IActionResult ActualizarProfissional(int id, ProfissionalDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(profissionalServices.Actualizar(id, dto));
        }

        //obter profissional pelo id do utilizador
        [HttpGet("ProfissionalPorUtilizador")]
        public ActionResult<NovoProfissionalDto> ProfissionalPorUtilizador(int utilizadorId)
        {
            try
            {
                var p = profissionalServices.ProfissionalPorUtilizador(utilizadorId);
                return Ok(p);
            }
            catch (Exception ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
        }
    }
}
