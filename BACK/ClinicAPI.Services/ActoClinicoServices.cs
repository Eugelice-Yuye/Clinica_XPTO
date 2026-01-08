using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicAPI.DTO;
using ClinicAPI.Interfaces.Repositories;
using ClinicAPI.Interfaces.Services;
using ClinicAPI.Model;

namespace ClinicAPI.Services
{
    public class ActoClinicoServices : IActoClinicoServices
    {
        private readonly IActoClinicoRepository actoClinicoRepository;

        public ActoClinicoServices(IActoClinicoRepository actoClinicoRepository)
        {
            this.actoClinicoRepository = actoClinicoRepository;
        }
        public IEnumerable<ActoClinicoDto> Listar()
        {
            var todos = actoClinicoRepository.ObterTodos();
            return todos.Select(a => new ActoClinicoDto
            {
                Id = a.Id,
                PedidoMarcacaoId = a.PedidoMarcacaoId,
                TipoServicoClinicoId = a.TipoServicoClinicoId,
                SubsistemaSaudeId = a.SubsistemaSaudeId,
                ProfissionalId = a.ProfissionalId,
                DataAgendada = a.DataAgendada,
                DataRealizada = a.DataRealizada
            })
            .ToList();
        }
        public ActoClinicoDto Obter(int id)
        {
            var a = actoClinicoRepository.ObterPorId(id)
                ?? throw new Exception("Acto clinico não encontrado");
            return new ActoClinicoDto
            {
                Id = a.Id,
                PedidoMarcacaoId = a.PedidoMarcacaoId,
                TipoServicoClinicoId = a.TipoServicoClinicoId,
                SubsistemaSaudeId = a.SubsistemaSaudeId,
                ProfissionalId = a.ProfissionalId,
                DataAgendada = a.DataAgendada,
                DataRealizada = a.DataRealizada
            };
        }

        public ActoClinicoDto Criar(CriarActoClinicoDto dto)
        {
            var a = new ActoClinico
            {
                TipoServicoClinicoId = dto.TipoServicoClinicoId,
                SubsistemaSaudeId = dto.SubsistemaSaudeId,
                ProfissionalId = dto.ProfissionalId ?? 0,
                DataAgendada = dto.DataAgendada
            };

            actoClinicoRepository.Adicionar(a);
            actoClinicoRepository.Salvar();
            return Obter(a.Id);
        }

        public ActoClinicoDto Actualizar(int id, ActualizarActoClinicoDto dto)
        {
            var a = actoClinicoRepository.ObterPorId(id)
                ?? throw new Exception("Acto clinico não encontrado");

            a.TipoServicoClinicoId = dto.TipoServicoClinicoId;
            a.SubsistemaSaudeId = dto.SubsistemaSaudeId;
            a.ProfissionalId = dto.ProfissionalId ?? a.ProfissionalId;
            a.DataAgendada = dto.DataAgendada;
            a.DataRealizada = dto.DataRealizada;

            actoClinicoRepository.Actualizar(a);
            actoClinicoRepository.Salvar();
            return Obter(id);
        }
    }
}
