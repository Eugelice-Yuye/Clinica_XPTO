using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicAPI.DTO;

namespace ClinicAPI.Interfaces.Services
{
    public interface IActoClinicoServices
    {
        IEnumerable<ActoClinicoDto> Listar();
        ActoClinicoDto Obter(int id);
        ActoClinicoDto Criar(CriarActoClinicoDto dto);
        ActoClinicoDto Actualizar(int id, ActualizarActoClinicoDto dto);
    }
}
