
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAPI.DTO
{
    public class ActoClinicoDto
    {
        public int Id { get; set; }
        public int PedidoMarcacaoId { get; set; }
        public int TipoServicoClinicoId { get; set; }
        public int SubsistemaSaudeId { get; set; }
        public int? ProfissionalId { get; set; }
        public DateTime? DataAgendada { get; set; }
        public DateTime? DataRealizada { get; set; }
    }
}
