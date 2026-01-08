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
    public class SubsistemaSaudeServices : ISubsistemaSaudeServices
    {
        private readonly ISubsistemaSaudeRepository subsistemaSaudeRepository;

        public SubsistemaSaudeServices(ISubsistemaSaudeRepository subsistemaSaudeRepository)
        {
            this.subsistemaSaudeRepository = subsistemaSaudeRepository;
        }

        public IEnumerable<SubsistemaSaudeDto> Listar()
        {
            var todos = subsistemaSaudeRepository.ObterTodos();
            return todos.Select(u => new SubsistemaSaudeDto
            {
                Id = u.Id,
                Nome = u.Nome,
                Descricao = u.Descricao
            })
            .ToList();
        }
        public SubsistemaSaudeDto Obter(int id)
        {
            var u = subsistemaSaudeRepository.ObterPorId(id)
                ?? throw new Exception("Subsistema não encontrado");
            return new SubsistemaSaudeDto
            {
                Id = u.Id,
                Nome = u.Nome,
                Descricao = u.Descricao
            };
        }

        public SubsistemaSaudeDto Criar(SubsistemaSaudeDto dto)
        {
            var t = new SubsistemaSaude
            {
                Nome = dto.Nome,
                Descricao = dto.Descricao,
            };

            subsistemaSaudeRepository.Adicionar(t);
            subsistemaSaudeRepository.Salvar();
            return Obter(t.Id);
        }
    }
}
