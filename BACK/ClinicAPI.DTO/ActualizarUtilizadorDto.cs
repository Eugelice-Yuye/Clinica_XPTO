using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicAPI.Model.enuns;

namespace ClinicAPI.DTO
{
    public class ActualizarUtilizadorDto
    {
        public String Email { get; set; }
        public String Senha { get; set; }
        public TipoUtilizador TipoUtilizador { get; set; }
        public bool Activo { get; set; }
    }
}
