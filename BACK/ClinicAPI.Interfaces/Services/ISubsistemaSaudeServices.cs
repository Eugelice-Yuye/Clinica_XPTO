using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicAPI.DTO;

namespace ClinicAPI.Interfaces.Services
{
    public interface ISubsistemaSaudeServices
    {
        IEnumerable<SubsistemaSaudeDto> Listar();
        SubsistemaSaudeDto Obter(int id);
        SubsistemaSaudeDto Criar(SubsistemaSaudeDto dto);
    }
}
