using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicAPI.Model;

namespace ClinicAPI.Interfaces.Repositories
{
    public interface IPedidoMarcacaoRepository
    {
        IEnumerable<PedidoMarcacao> ObterTodos();
        PedidoMarcacao ObterPorId(int id);
        void Adicionar(PedidoMarcacao pedido);
        void Actualizar(PedidoMarcacao pedido);
        bool Salvar();
    }
}
