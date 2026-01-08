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
    public class SubsistemaSaudeRepository : ISubsistemaSaudeRepository
    {
        private readonly ClinicAPIDbContext context;
        public SubsistemaSaudeRepository(ClinicAPIDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<SubsistemaSaude> ObterTodos()
        {
            return context.SubsistemasSaude
                .AsNoTracking()
                .ToList();
        }
        public SubsistemaSaude ObterPorId(int id)
        {
            return context.SubsistemasSaude.Find(id);
        }

        public void Adicionar(SubsistemaSaude subsistemaSaude)
        {
            context.SubsistemasSaude.Add(subsistemaSaude);
        }
        public bool Salvar()
        {
            return (context.SaveChanges() > 0);
        }
    }
}
