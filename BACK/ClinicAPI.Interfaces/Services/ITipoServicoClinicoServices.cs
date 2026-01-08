using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicAPI.DTO;
using ClinicAPI.Model;

namespace ClinicAPI.Interfaces.Services
{
    public interface ITipoServicoClinicoServices
    {
        IEnumerable<TipoServicoClinicoDto> Listar();
        TipoServicoClinicoDto Obter(int id);
        TipoServicoClinicoDto Criar(TipoServicoClinicoDto dto);
        TipoServicoClinicoDto Actualizar(int id, TipoServicoClinicoDto dto);
    }
}
