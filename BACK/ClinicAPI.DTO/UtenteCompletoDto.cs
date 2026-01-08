using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicAPI.Model.enuns;

namespace ClinicAPI.DTO
{
    public class UtenteCompletoDto
    {
        public int Id { get; set; }
        public string NumeroUtente { get; set; }
        public string UrlFoto { get; set; }
        public string NomeCompleto { get; set; }
        public string DataDeNascimento { get; set; }
        public Genero Genero { get; set; }
        public string Telemovel { get; set; }
        public string Email { get; set; }
        public string Morada { get; set; }
    }
}
