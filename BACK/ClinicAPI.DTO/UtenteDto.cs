using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAPI.DTO
{
    public class UtenteDto
    {
        public int Id { get; set; }
        public String NomeCompleto { get; set; }
        public String Email { get; set; }
        public String Telemovel { get; set; }
        public String Morada { get; set; }
        public String UrlFoto { get; set; }
        public String DataDeNascimento { get; set; }
    }
}
