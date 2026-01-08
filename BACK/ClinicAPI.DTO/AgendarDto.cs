using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAPI.DTO
{
    public class AgendarDto
    {
        [Required] 
        public DateTime DataAgendada { get; set; }
        public int ProfissionalId { get; set; }
    }
}
