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
    public class ActoClinicoRepository : IActoClinicoRepository
    {
        private readonly ClinicAPIDbContext context;
        public ActoClinicoRepository(ClinicAPIDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<ActoClinico> ObterTodos()
        {
            return context.ActosClinicos
                .AsNoTracking()
                .ToList();
        }
        public ActoClinico ObterPorId(int id)
        {
            return context.ActosClinicos.Find(id);
        }

        public void Adicionar(ActoClinico acto)
        {
            context.ActosClinicos.Add(acto);
        }
        public void Actualizar(ActoClinico acto)
        {
            context.ActosClinicos.Update(acto);
        }
        public bool Salvar()
        {
            return (context.SaveChanges() > 0);
        }
    }
}
