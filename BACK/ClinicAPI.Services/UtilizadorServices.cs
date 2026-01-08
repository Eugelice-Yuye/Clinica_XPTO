using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicAPI.DAL.Repositories;
using ClinicAPI.DTO;
using ClinicAPI.Interfaces.Services;
using ClinicAPI.Model;
using ClinicAPI.Model.enuns;

namespace ClinicAPI.Services
{
    public class UtilizadorServices : IUtilizadorServices
    {
        public readonly IUtilizadorRepository utilizadorRepository;
        private readonly IEmailServices email;
        public UtilizadorServices(IUtilizadorRepository utilizadorRepository,
            IEmailServices email)
        {
            this.utilizadorRepository = utilizadorRepository;
            this.email = email;
        }
        public UtilizadorDto Login(LoginDto loginDto)
        {
            var user = utilizadorRepository.ObterPorEmail(loginDto.Email);
            if (user == null)
                throw new Exception("Email ou senha inválidos");
            if (user.Senha != loginDto.Senha)
                throw new Exception("Email ou senha inválidos");
            if (!user.Activo)
                throw new Exception("Utilizador Inexistente");
            return new UtilizadorDto
            {
                Id = user.Id,
                Email = user.Email,
                TipoUtilizador = user.TipoUtilizador,
                Activo = user.Activo
            };
        }
        public UtilizadorDto CriarUtilizador(CriarUtilizadorDto criarUtilizadorDto)
        {
            var jaExiste = utilizadorRepository.ObterPorEmail(criarUtilizadorDto.Email);
            if (jaExiste != null)
                throw new Exception("Já existe um utilizador com esse email");
            var novo = new Utilizador
            {
                Email = criarUtilizadorDto.Email,
                Senha = criarUtilizadorDto.Senha,
                TipoUtilizador = criarUtilizadorDto.TipoUtilizador,
                Activo = false
            };

            utilizadorRepository.Adicionar(novo);
            var sucesso = utilizadorRepository.SalvarMudancas();
            if (!sucesso)
                throw new Exception("Erro ao criar utilizador");
            return new UtilizadorDto
            {
                Id = novo.Id,
                Email = novo.Email,
                TipoUtilizador = novo.TipoUtilizador,
                Activo = novo.Activo
            };
        }
        public IEnumerable<UtilizadorDto> ListarUtilizadores()
        {
            var todos = utilizadorRepository.ObterTodos();
            return todos.Select(u => new UtilizadorDto
            {
                Id = u.Id,
                Email = u.Email,
                TipoUtilizador = u.TipoUtilizador,
                Activo = u.Activo
            })
            .ToList();
        }
        public UtilizadorDto ActualizarUtilizador(int id, ActualizarUtilizadorDto actualizarUtilizadorDto)
        {
            var user = utilizadorRepository.ObterPorId(id);
            if (user == null)
                throw new Exception("Utilizador não encontrado");
            if (string.Equals(user.Email, actualizarUtilizadorDto.Email, StringComparison.OrdinalIgnoreCase))
            {
                var outro = utilizadorRepository.ObterPorEmail(actualizarUtilizadorDto.Email);
                if (outro != null && outro.Id != id)
                    throw new Exception("Email já em uso, escolha outro");
            }
            user.Email = actualizarUtilizadorDto.Email;
            if (!String.IsNullOrWhiteSpace(actualizarUtilizadorDto.Senha))
            {
                user.Senha = actualizarUtilizadorDto.Senha;
            }
            user.TipoUtilizador = actualizarUtilizadorDto.TipoUtilizador;
            user.Activo = actualizarUtilizadorDto.Activo;
            utilizadorRepository.Actualizar(user);
            var sucesso = utilizadorRepository.SalvarMudancas();
            if (!sucesso)
                throw new Exception("Falha ao actualizar");
            return new UtilizadorDto
            {
                Id = user.Id,
                Email = user.Email,
                TipoUtilizador = user.TipoUtilizador,
                Activo = user.Activo
            };
        }

        public UtilizadorDto ActivarUtilizador(int id)
        {
            var user = utilizadorRepository.ObterPorId(id);
            if (user == null)
                throw new Exception("Utilizador não encontrado");

            if (!user.Activo)
            {
                user.Activo = true;
                utilizadorRepository.Actualizar(user);
                utilizadorRepository.SalvarMudancas();

                email.Enviar(user.Email,
                "Clínica XPTO",
                $"Seja muito bem-vindo (a) à família da clínica XPTO!\n" +
                $"O seu acesso à plataforma foi criado com sucesso. A partir de agora,\n" +
                $"poderá gerir as suas marcações e consultar as suas informações com mais facilidade.\n" +
                $"\n📧 Email de acesso : {user.Email}\n🔐 Senha: {user.Senha}\n" +
                $"\nRecomendamos que altere a senha assim que fizer o primeiro login para garantir a segurança da sua conta.\n" +
                $"\nCom carinho,\n" +
                $"Equipa Clínica XPTO\n");
            }
            return new UtilizadorDto
            {
                Id = user.Id,
                Email = user.Email,
                TipoUtilizador = user.TipoUtilizador,
                Activo = user.Activo
            };
        }
    }
}
