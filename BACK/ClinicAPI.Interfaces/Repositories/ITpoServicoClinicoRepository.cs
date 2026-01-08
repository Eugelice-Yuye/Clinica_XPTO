using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicAPI.Model;

namespace ClinicAPI.Interfaces.Repositories
{
    public interface ITipoServicoClinicoRepository
    {
        IEnumerable<TipoServicoClinico> ObterTodos();
        TipoServicoClinico ObterPorId(int id);
        void Adicionar(TipoServicoClinico tipoServicoClinico);
        void Actualizar(TipoServicoClinico tipoServicoClinico);
        bool Salvar();
    }
}
