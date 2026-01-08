using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicAPI.DTO;
using ClinicAPI.Interfaces.Repositories;
using ClinicAPI.Interfaces.Services;
using ClinicAPI.Model;
using ClinicAPI.Model.enuns;

namespace ClinicAPI.Services
{
    public class ProfissionalServices : IProfissionalServices
    {
        private readonly IProfissionalRepository profissionalRepository;
        private readonly IUtilizadorServices utilizadorServices;

        public ProfissionalServices(IProfissionalRepository profissionalRepository, IUtilizadorServices utilizadorServices)
        {
            this.profissionalRepository = profissionalRepository;
            this.utilizadorServices = utilizadorServices;
        }
        public IEnumerable<ProfissionalDto> Listar()
        {
            var todos = profissionalRepository.ObterTodos();
            return todos.Select(u => new ProfissionalDto
            {
                Id = u.Id,
                Nome = u.Nome,
                Especialidade = u.Especialidade
            })
            .ToList();
        }
        public ProfissionalDto Obter(int id)
        {
            var u = profissionalRepository.ObterPorId(id)
                ?? throw new Exception("Profissional não encontrado");
            return new ProfissionalDto
            {
                Id = u.Id,
                Nome = u.Nome,
                Especialidade = u.Especialidade
            };
        }

        //obter profissional novo (Exame)
        public NovoProfissionalDto ObterProf(int id)
        {
            var u = profissionalRepository.ObterPorId(id)
                ?? throw new Exception("Profissional não encontrado");
            return new NovoProfissionalDto
            {
                Id = u.Id,
                Nome = u.Nome,
                Especialidade = u.Especialidade
            };
        }
        public ProfissionalDto Criar(ProfissionalDto dto)
        {
            var t = new Profissional
            {
                Nome = dto.Nome,
                Especialidade = dto.Especialidade
            };

            profissionalRepository.Adicionar(t);
            profissionalRepository.Salvar();

            return Obter(t.Id);
        }

        //Criar profissional assossiando a um utilizador
        public NovoProfissionalDto CriarP(NovoProfissionalDto dto)
        {
            var t = new Profissional
            {
                Nome = dto.Nome,
                Especialidade = dto.Especialidade,
            };

          profissionalRepository.Adicionar(t);
          profissionalRepository.Salvar();

            var novovUtilziador = utilizadorServices.CriarUtilizador(new CriarUtilizadorDto
            {
                Email = dto.Email,
                Senha = dto.Senha,
                TipoUtilizador = TipoUtilizador.Profissional
            });
            t.UtilizadorId = novovUtilziador.Id;
            profissionalRepository.Actualizar(t);
            profissionalRepository.Salvar();
            return ObterProf(t.Id);
        }

        public ProfissionalDto Actualizar(int id, ProfissionalDto dto)
        {
            var t = profissionalRepository.ObterPorId(id)
                ?? throw new Exception("Não encontrado");
            t.Nome = dto.Nome;
            t.Especialidade = dto.Especialidade;
            profissionalRepository.Actualizar(t);
            profissionalRepository.Salvar();
            return Obter(id);
        }

        //obter profissional por utilizador
        public NovoProfissionalDto ProfissionalPorUtilizador(int utilizadorId)
        {
            var profissional = profissionalRepository.ObterTodos()
                          .FirstOrDefault(u => u.UtilizadorId == utilizadorId);

            if (profissional == null)
                throw new Exception("profissional não encontrado");

            return new NovoProfissionalDto
            {
                Id = profissional.Id,
                Nome = profissional.Nome,
                Especialidade = profissional.Especialidade,
               // Email = profissional.Utilizador.Email
            };
        }
    }
}
