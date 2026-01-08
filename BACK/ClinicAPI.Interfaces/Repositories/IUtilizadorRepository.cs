using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicAPI.Model;

namespace ClinicAPI.DAL.Repositories
{
    public interface IUtilizadorRepository
    {
        Utilizador ObterPorId(int id);
        Utilizador ObterPorEmail(String email);
        IEnumerable<Utilizador> ObterTodos();
        void Adicionar(Utilizador utilizador);
        void Actualizar(Utilizador utilizador);
        bool Remover(int id);
        bool SalvarMudancas();

    }
}
