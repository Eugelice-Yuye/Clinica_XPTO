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
    public class TipoServicoClinicoRepository : ITipoServicoClinicoRepository
    {
        private readonly ClinicAPIDbContext context;
        public TipoServicoClinicoRepository(ClinicAPIDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<TipoServicoClinico> ObterTodos()
        {
            return context.TiposServicosClinicos
                .AsNoTracking()
                .ToList();
        }
        public TipoServicoClinico ObterPorId(int id)
        {
            return context.TiposServicosClinicos.Find(id);
        }

        public void Adicionar(TipoServicoClinico tipoServicoClinico)
        {
            context.TiposServicosClinicos.Add(tipoServicoClinico);
        }
        public void Actualizar(TipoServicoClinico tipoServicoClinico)
        {
            context.TiposServicosClinicos.Update(tipoServicoClinico);
        }
        public bool Salvar()
        {
            return (context.SaveChanges() > 0);
        }
    }
}
