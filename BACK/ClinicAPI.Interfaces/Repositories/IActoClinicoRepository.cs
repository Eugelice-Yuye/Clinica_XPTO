using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicAPI.Model;

namespace ClinicAPI.Interfaces.Repositories
{
    public interface IActoClinicoRepository
    {
        IEnumerable<ActoClinico> ObterTodos();
        ActoClinico ObterPorId(int id);
        void Adicionar(ActoClinico acto);
        void Actualizar(ActoClinico acto);
        bool Salvar();
    }
}
