using ClinicAPI.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using ClinicAPI.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
/*
    login (utilizadores registados) - post
    registo/efectivarMarcacao (pelo administrativo) - post/put
    listar utilizadores (admin) - get
    criar utilizador (admin) - post
    */
namespace ClinicAPI.Controllers
{
    [ApiController]
    public class UtilizadoresController : ControllerBase
    {
        private readonly IUtilizadorServices utilizadorServices;

        public UtilizadoresController(IUtilizadorServices utilizadorServices)
        {
            this.utilizadorServices = utilizadorServices;
        }

        // listar utlizadores
        [HttpGet, Route("ListarUtilizadores")]
        public IActionResult ListarUtilizadores()
        {
            var lista = utilizadorServices.ListarUtilizadores();
                return Ok(lista);
        }

        // login
        [HttpPost, Route("Login")]
        public IActionResult login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var resultado = utilizadorServices.Login(loginDto);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }

        // criar utilizador
        [HttpPost, Route("CriarUtilizador")]
        public IActionResult CriarUtilizador(CriarUtilizadorDto criarUtilizadorDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var novo = utilizadorServices.CriarUtilizador(criarUtilizadorDto);
                return CreatedAtAction(nameof(ObterUtilizador), new { id = novo.Id }, novo);
            }
            catch (Exception ex)
            {
                return BadRequest(new {message = ex.Message});
            }
        }

        // buscar user singular
        [HttpGet,Route("ObterUtilizador")]
        public IActionResult ObterUtilizador(int id)
        {
            var todos = utilizadorServices.ListarUtilizadores();
            var user = todos.FirstOrDefault(u=> u.Id == id);
            if (user == null)
                return NotFound(new { message = "Utilizador não encontrado." });
            return Ok(user);
        }

        // ActualizarUtilizador
        [HttpPut, Route("ActualizarUtilizador")]
        public IActionResult ActualizarUtilizador(int id, ActualizarUtilizadorDto actualizarUtilizadorDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var atualizado = utilizadorServices.ActualizarUtilizador(id, actualizarUtilizadorDto);
                return Ok(actualizarUtilizadorDto);
            }
            catch(Exception ex) 
            {
                return BadRequest(new {message = ex.Message});
            }
        }

        //activar utilizador
        [HttpPut, Route("ActivarUtilizador")]
        public IActionResult ActivarUtilizador(int id)
        {
            try
            {
                var utlizador = utilizadorServices.ActivarUtilizador(id);
                return Ok(utlizador);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
