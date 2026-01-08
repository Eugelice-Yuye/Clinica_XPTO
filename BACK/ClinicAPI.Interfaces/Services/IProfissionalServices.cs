using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicAPI.DTO;

namespace ClinicAPI.Interfaces.Services
{
    public interface IProfissionalServices
    {
        IEnumerable<ProfissionalDto> Listar();
        ProfissionalDto Obter(int id);
        public NovoProfissionalDto ObterProf(int id);
        public NovoProfissionalDto ProfissionalPorUtilizador(int utilizadorId);
        ProfissionalDto Criar(ProfissionalDto dto);
        public NovoProfissionalDto CriarP(NovoProfissionalDto dto);
        ProfissionalDto Actualizar(int id, ProfissionalDto dto);
    }
}
