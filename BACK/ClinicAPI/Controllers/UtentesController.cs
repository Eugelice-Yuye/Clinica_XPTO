using ClinicAPI.DAL.Repositories;
using ClinicAPI.DTO;
using ClinicAPI.Interfaces.Services;
using ClinicAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
/*
         obter todos os utentes (admin,administrativo) - get
         obter utente específico - get
         actualizar dados de utente (proprio utente) - put
         */
namespace ClinicAPI.Controllers
{
    [ApiController]
    public class UtentesController : ControllerBase
    {
        private readonly IUtenteServices utenteServices;

        public UtentesController(IUtenteServices utenteServices)
        {
            this.utenteServices = utenteServices;
        }

        // Listar utentes
        [HttpGet, Route("ListarUtentes")]
        public IActionResult ListarUtentes()
        {
            var lista = utenteServices.ListarUtentes();
            return Ok(lista);
        }

        //Obter Utente específico
        [HttpGet, Route("ObterUtente")]
        public IActionResult ObterUtente(int id)
        {
            var todos = utenteServices.ListarUtentes();
            var user = todos.FirstOrDefault(u => u.Id == id);
            if (user == null)
                return NotFound(new { message = "Utente não encontrado." });
            return Ok(user);
        }

        // Actualizar dados do utente
        [HttpPut, Route("ActualizarUtente")]
        public IActionResult ActualizarUtente(int id, UtenteDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(utenteServices.ActualizarUtente(id,dto));
        }

        //obter utente pelo id do utilizador
        [HttpGet("UtentePorUtilizador")]
        public ActionResult<UtenteCompletoDto> UtentePorUtilizador(int utilizadorId)
        {
            try
            {
                var utente = utenteServices.UtentePorUtilizador(utilizadorId);
                return Ok(utente);
            }
            catch (Exception ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
        }

    }
}
