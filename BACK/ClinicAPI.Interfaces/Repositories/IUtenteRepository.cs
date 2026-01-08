using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicAPI.Model;

namespace ClinicAPI.Interfaces.Repositories
{
    public interface IUtenteRepository
    {
        IEnumerable<Utente> ObterTodos();
        Utente ObterPorId(int id);
        Utente UtentePorUtilizador(int utilizadorId);
        void Actualizar(Utente utente);
        void AdicionarUtente(Utente utente);
        bool Salvar();
    }
}
