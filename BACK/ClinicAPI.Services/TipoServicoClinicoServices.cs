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
    public class TipoServicoClinicoServices : ITipoServicoClinicoServices
    {
        private readonly ITipoServicoClinicoRepository tipoServicoClinicoRepository;

        public TipoServicoClinicoServices(ITipoServicoClinicoRepository tipoServicoClinicoRepository)
        {
            this.tipoServicoClinicoRepository = tipoServicoClinicoRepository;
        }

        public IEnumerable<TipoServicoClinicoDto> Listar()
        {
            var todos = tipoServicoClinicoRepository.ObterTodos();
            return todos.Select(u => new TipoServicoClinicoDto
            {
                Id = u.Id,
                Nome = u.Nome,
                Descricao = u.Descricao,
                EExame = u.EExame
            })
            .ToList();
        }
        public TipoServicoClinicoDto Obter(int id)
        {
            var u = tipoServicoClinicoRepository.ObterPorId(id)
                ?? throw new Exception("Tipo de serviço não encontrado");
            return new TipoServicoClinicoDto
            {
                Id = u.Id,
                Nome = u.Nome,
                Descricao = u.Descricao,
                EExame = u.EExame
            };
        }

        public TipoServicoClinicoDto Criar(TipoServicoClinicoDto dto)
        {
            var t = new TipoServicoClinico
            {
                Nome = dto.Nome,
                Descricao = dto.Descricao,
                EExame = dto.EExame
            };

            tipoServicoClinicoRepository.Adicionar(t);
            tipoServicoClinicoRepository.Salvar();
            return Obter(t.Id);
        }

        public TipoServicoClinicoDto Actualizar(int id, TipoServicoClinicoDto dto)
        {
            var t = tipoServicoClinicoRepository.ObterPorId(id)
                ?? throw new Exception("Não encontrado");
            t.Nome = dto.Nome;
            t.Descricao = dto.Descricao;
            t.EExame = dto.EExame;
            tipoServicoClinicoRepository.Actualizar(t);
            tipoServicoClinicoRepository.Salvar();
            return Obter(id);
        }
    }
}
