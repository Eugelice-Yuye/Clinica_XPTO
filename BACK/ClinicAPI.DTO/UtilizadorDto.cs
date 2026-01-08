using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicAPI.Model.enuns;

namespace ClinicAPI.DTO
{
    public class UtilizadorDto
    {
        public int Id { get; set; }
        public String Email { get; set; }
        public TipoUtilizador TipoUtilizador { get; set; }
        public bool Activo { get; set; }
    }
}
