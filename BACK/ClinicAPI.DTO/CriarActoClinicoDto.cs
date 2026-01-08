using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAPI.DTO
{
    public class CriarActoClinicoDto
    {
        [Required] 
        public int TipoServicoClinicoId { get; set; }
        [Required] 
        public int SubsistemaSaudeId { get; set; }
        public int? ProfissionalId { get; set; }
        public DateTime DataAgendada { get; set; }
    }
}
