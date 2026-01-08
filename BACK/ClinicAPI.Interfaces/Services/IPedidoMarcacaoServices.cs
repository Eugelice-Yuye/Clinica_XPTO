using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicAPI.DTO;

namespace ClinicAPI.Interfaces.Services
{
    public interface IPedidoMarcacaoServices
    {
        PedidoMarcacaoDto CriarPedido(CriarPedidoDto dto);
        IEnumerable<PedidoMarcacaoDto> ListarTodos();
        PedidoMarcacaoDto ObterPorId(int id);
        IEnumerable<PedidoMarcacaoDto> ObterPorUtente(int utenteId);
        PedidoMarcacaoDto Agendar(int id, AgendarDto dto);
        PedidoMarcacaoDto MarcarRealizado(int id);
        public PedidoMarcacaoDto MarcarCancelado(int id);
        byte[] ExportarPdf(int id);
    }
}
