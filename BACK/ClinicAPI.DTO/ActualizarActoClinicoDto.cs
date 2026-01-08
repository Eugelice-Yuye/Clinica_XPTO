using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAPI.DTO
{
    public class ActualizarActoClinicoDto : CriarActoClinicoDto
    {
        public DateTime DataRealizada { get; set; }
    }
}
