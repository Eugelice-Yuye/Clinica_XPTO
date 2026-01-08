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
    public class PedidoMarcacaoRepository : IPedidoMarcacaoRepository
    {
        private readonly ClinicAPIDbContext context;
        public PedidoMarcacaoRepository(ClinicAPIDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<PedidoMarcacao> ObterTodos()
        {
            return context.PedidoMarcacoes
                .Include(p => p.ActosClinicos)
                .Include(p => p.Utente)
                .ThenInclude(u => u.Utilizador)
                .AsNoTracking()
                .ToList();
        }
        /*public PedidoMarcacao ObterPorId(int id)
        {
            return context.PedidoMarcacoes
                .Include(p => p.ActosClinicos)
                    .ThenInclude(a=>a.Profissional)
                .Include(p=>p.ActosClinicos)
                    .ThenInclude(a=>a.SubsistemaSaude)
                .Include(p => p.ActosClinicos)
                    .ThenInclude(a => a.TipoServicoClinico)
                .Include(p => p.Utente)
                .ThenInclude(u => u.Utilizador)
                .FirstOrDefault(p => p.Id == id);
        }*/
        public PedidoMarcacao ObterPorId(int id)
        {
            return context.PedidoMarcacoes
                .Include(p => p.ActosClinicos)
                    .ThenInclude(a => a.Profissional)
                .Include(p => p.ActosClinicos)
                    .ThenInclude(a => a.TipoServicoClinico)
                .Include(p => p.ActosClinicos)
                    .ThenInclude(a => a.SubsistemaSaude)
                .Include(p => p.Utente)
                    .ThenInclude(u => u.Utilizador)
                .FirstOrDefault(p => p.Id == id);
        }

        public void Adicionar(PedidoMarcacao pedido)
        {
            context.PedidoMarcacoes.Add(pedido);
        }
        public void Actualizar(PedidoMarcacao pedido)
        {
            context.PedidoMarcacoes.Update(pedido);
        }
        public bool Salvar()
        {
            return (context.SaveChanges() > 0);
        }
    }
}
