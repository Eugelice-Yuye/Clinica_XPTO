using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicAPI.Model;

namespace ClinicAPI.Interfaces.Repositories
{
    public interface ISubsistemaSaudeRepository
    {
        IEnumerable<SubsistemaSaude> ObterTodos();
        SubsistemaSaude ObterPorId(int id);
        void Adicionar(SubsistemaSaude subsistemaSaude);
        bool Salvar();
    }
}
