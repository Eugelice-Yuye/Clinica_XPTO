using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicAPI.DTO;

namespace ClinicAPI.Interfaces.Services
{
    public interface IUtenteServices
    {
        IEnumerable<UtenteDto> ListarUtentes();
        UtenteDto ObterUtente(int id);
        UtenteDto ActualizarUtente(int id, UtenteDto dto);
        UtenteCompletoDto UtentePorUtilizador(int utilizadorId);
    }
}
