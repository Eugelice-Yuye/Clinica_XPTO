using ClinicAPI.DTO;
using ClinicAPI.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
/*
     listar todos os pedidos (admin, adminstrativo) - get
     obter pedido específico - get
     obter pedido do utente - get
     criar novo pedido
     agendar (administrativo) - put
     marcar como realizado (administrativo) - put
     exportar detalhes marcação - get
     */
namespace ClinicAPI.Controllers
{
    [ApiController]
    public class PedidosMarcacoesController : ControllerBase
    {
        private readonly IPedidoMarcacaoServices pedidoMarcacaoServices;
        //private readonly IEmailServices _email;

        /*public PedidosMarcacoesController(IEmailServices email)
        {
            _email = email;
        }*/

        public PedidosMarcacoesController(IPedidoMarcacaoServices pedidoService)
        {
            pedidoMarcacaoServices = pedidoService;

        }
        // Listar todos os pedidos
        [HttpGet, Route("ListarTodos")]
        public IActionResult ListarTodos()
        {
            var pedidos = pedidoMarcacaoServices.ListarTodos();
            return Ok(pedidos);
        }

        // Obter um pedido específico pelo ID
        [HttpGet, Route("ObterPedido")]
        public ActionResult<PedidoMarcacaoDto> ObterPedido(int id)
        {
            try
            {
                var pedido = pedidoMarcacaoServices.ObterPorId(id);
                return Ok(pedido);
            }
            catch (Exception ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
        }

        // Obter pedidos de um utente específico
        [HttpGet, Route("ObterPorUtente")]
        public IActionResult ObterPorUtente(int utenteId)
        {
            var pedidos = pedidoMarcacaoServices.ObterPorUtente(utenteId);
            return Ok(pedidos);
        }

        // Criar novo pedido
        [HttpPost, Route("CriarPedido")]
        public ActionResult<PedidoMarcacaoDto> CriarPedido([FromBody] CriarPedidoDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var pedido = pedidoMarcacaoServices.CriarPedido(dto);
                return CreatedAtAction(nameof(ObterPedido), new { id = pedido.Id }, pedido);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        // Agendar pedido
        [HttpPut, Route("Agendar")]
        public IActionResult Agendar(int id, [FromBody] AgendarDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var pedido = pedidoMarcacaoServices.Agendar(id, dto);
                return Ok(pedido);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        /// Marcar pedido como realizado
        [HttpPut, Route("MarcarRealizado")]
        public IActionResult MarcarRealizado(int id)
        {
            try
            {
                var pedido = pedidoMarcacaoServices.MarcarRealizado(id);
                return Ok(pedido);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
        /// Marcar pedido como cacnelado
        [HttpPut, Route("MarcarCancelado")]
        public IActionResult MarcarCancelado(int id)
        {
            try
            {
                var pedido = pedidoMarcacaoServices.MarcarCancelado(id);
                return Ok(pedido);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        // Exportar os detalhes da marcação em PDF
        [HttpGet, Route("ExportarPdf")]
        public IActionResult ExportarPdf(int id)
        {
            try
            {
                var pdf = pedidoMarcacaoServices.ExportarPdf(id);
                return File(pdf, "application/pdf", $"Pedido_{id}.pdf");
            }
            catch (Exception ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
        }
        /*[HttpGet, Route("EnviarEmailTeste")]
        public IActionResult EnviarEmailTeste(string para)
        {
            try
            {
                var assunto = "Tem que FUNCIONAR";
                var corpo = "funcionu waweeeeee";

                _email.Enviar(para, assunto, corpo);
                return Ok(new { mensagem = "Email enviado com sucesso para " + para });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro ao enviar email", erro = ex.Message });
            }
        }*/
    }
}

