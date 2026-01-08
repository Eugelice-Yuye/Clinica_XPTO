using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicAPI.Model;

namespace ClinicAPI.Interfaces.Repositories
{
    public interface IProfissionalRepository
    {
        IEnumerable<Profissional> ObterTodos();
        Profissional ObterPorId(int id);
        void Adicionar(Profissional p);
        void Actualizar(Profissional p);
        bool Salvar();
    }
}
