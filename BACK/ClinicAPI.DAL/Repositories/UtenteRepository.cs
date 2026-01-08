using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicAPI.Interfaces.Repositories;
using ClinicAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace ClinicAPI.DAL.Repositories
{
    public class UtenteRepository : IUtenteRepository
    {
        private readonly ClinicAPIDbContext context;
        public UtenteRepository(ClinicAPIDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Utente> ObterTodos()
        {
            return context.Utentes
                .AsNoTracking()
                .ToList();
        }
        public Utente ObterPorId(int id)
        {
            return context.Utentes.Find(id);
        }
        public Utente UtentePorUtilizador(int utilizadorId)
        {
            return context.Utentes.FirstOrDefault(u => u.UtilizadorId == utilizadorId);
        }

        public void Actualizar(Utente utente)
        {
            context.Utentes.Update(utente);
        }
        public void AdicionarUtente(Utente utente)
        {
            context.Utentes.Add(utente);
        }
        public bool Salvar()
        {
            return (context.SaveChanges() > 0);
        }
    }
}
