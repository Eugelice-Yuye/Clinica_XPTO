using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicAPI.DAL.Repositories;
using ClinicAPI.DTO;
using ClinicAPI.Interfaces.Repositories;
using ClinicAPI.Interfaces.Services;
using ClinicAPI.Model.enuns;

namespace ClinicAPI.Services
{
    public class UtenteServices : IUtenteServices
    {
        public readonly IUtenteRepository utenteRepository;
        public UtenteServices(IUtenteRepository utenteRepository)
        {
            this.utenteRepository = utenteRepository;
        }
        public IEnumerable<UtenteDto> ListarUtentes()
        {
            var todos = utenteRepository.ObterTodos();
            return todos.Select(u => new UtenteDto
            {
                Id = u.Id,
                NomeCompleto = u.NomeCompleto,
                Email = u.Email,
                Telemovel = u.Telemovel,
                UrlFoto = u.UrlFoto,
                DataDeNascimento = u.DataDeNascimento,
                Morada = u.Morada
            })
            .ToList();
        }
        public UtenteDto ObterUtente(int id)
        {
            var u = utenteRepository.ObterPorId(id)
                ?? throw new Exception("Utente não encontrado");
            return new UtenteDto
            {
                Id = u.Id,
                NomeCompleto = u.NomeCompleto,
                Email = u.Email,
                Telemovel = u.Telemovel,
                UrlFoto = u.UrlFoto,
                Morada = u.Morada,
                DataDeNascimento = u.DataDeNascimento
            };
        }
        public UtenteCompletoDto UtentePorUtilizador(int utilizadorId)
        {
            var utente = utenteRepository.ObterTodos()
                          .FirstOrDefault(u => u.UtilizadorId == utilizadorId);

            if (utente == null)
                throw new Exception("Utente não encontrado");

            return new UtenteCompletoDto
            {
                Id = utente.Id,
                NumeroUtente = utente.NumeroUtente,
                NomeCompleto = utente.NomeCompleto,
                Email = utente.Email,
                Telemovel = utente.Telemovel,
                UrlFoto = utente.UrlFoto,
                Morada = utente.Morada,
                DataDeNascimento = utente.DataDeNascimento,
                Genero = utente.Genero
            };
        }

        public UtenteDto ActualizarUtente(int id, UtenteDto dto)
        {
            var u = utenteRepository.ObterPorId(id)
                    ?? throw new Exception("Utente não encontrado");
            
            u.NomeCompleto = dto.NomeCompleto;
            u.Email = dto.Email;
            u.Telemovel = dto.Telemovel;
            u.Morada = dto.Morada;
            u.DataDeNascimento = dto.DataDeNascimento;
            u.UrlFoto = dto.UrlFoto;
            utenteRepository.Actualizar(u);
            utenteRepository.Salvar();
            return new UtenteDto
            {
                Id = u.Id,
                NomeCompleto = u.NomeCompleto,
                Email = u.Email,
                Telemovel = u.Telemovel,
                Morada = u.Morada,
                DataDeNascimento = u.DataDeNascimento,
                UrlFoto = u.UrlFoto
            };
        }
    }
}
