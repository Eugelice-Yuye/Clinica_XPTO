using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClinicAPI.DTO
{
    public class LoginDto
    {
        public String Email { get; set; }
        public String Senha { get; set; }
        public int TipoUtilizador { get; set; }
    }
}
