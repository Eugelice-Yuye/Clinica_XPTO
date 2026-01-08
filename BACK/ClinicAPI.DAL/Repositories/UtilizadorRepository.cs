using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace ClinicAPI.DAL.Repositories
{
    public class UtilizadorRepository : IUtilizadorRepository
    {
        private readonly ClinicAPIDbContext context;
        public UtilizadorRepository(ClinicAPIDbContext context)
        {
            this.context = context;
        }
        public void Adicionar (Utilizador utilizador)
        {
            context.Utilizadores.Add(utilizador);
        }
        public bool Remover(int id)
        {
            var user = context.Utilizadores.Find(id);
            if (user == null)
                return false;
            context.Utilizadores.Remove(user);
            return true;
        }
        public Utilizador ObterPorId(int id)
        {
            return context.Utilizadores.Find(id);
        }
        public Utilizador ObterPorEmail(String email)
        {
            return context.Utilizadores
                .AsNoTracking()
                .FirstOrDefault(u => u.Email.ToLower() == email.ToLower());
        }
        public IEnumerable<Utilizador> ObterTodos()
        {
            return context.Utilizadores
                .AsNoTracking()
                .ToList();
        }
        public void Actualizar(Utilizador utilizador)
        {
            context.Utilizadores.Update(utilizador);
        }
        public bool SalvarMudancas()
        {
            return (context.SaveChanges()  > 0);
        }
    }
}
