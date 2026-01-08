using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicAPI.DTO;

namespace ClinicAPI.Interfaces.Services
{
    public interface IUtilizadorServices
    {
        UtilizadorDto Login(LoginDto loginDto);
        UtilizadorDto CriarUtilizador(CriarUtilizadorDto criarUtilizadorDto);
        IEnumerable<UtilizadorDto> ListarUtilizadores();
        UtilizadorDto ActualizarUtilizador(int id, ActualizarUtilizadorDto actualizarUtilizadorDto);
        UtilizadorDto ActivarUtilizador(int id);
    }
}
