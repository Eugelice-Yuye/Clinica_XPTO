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
    public class ProfissionalRepository : IProfissionalRepository
    {
        private readonly ClinicAPIDbContext context;
        public ProfissionalRepository(ClinicAPIDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Profissional> ObterTodos()
        {
            return context.Profissionais
                .AsNoTracking()
                .ToList();
        }
        public Profissional ObterPorId(int id)
        {
            return context.Profissionais.Find(id);
        }

        public void Adicionar(Profissional profissional)
        {
            context.Profissionais.Add(profissional);
        }
        public void Actualizar(Profissional profissional)
        {
            context.Profissionais.Update(profissional);
        }
        public bool Salvar()
        {
            return (context.SaveChanges() > 0);
        }
    }
}
