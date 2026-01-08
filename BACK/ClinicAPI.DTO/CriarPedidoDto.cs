using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicAPI.Model.enuns;

namespace ClinicAPI.DTO
{
    public class CriarPedidoDto
    {
        public int? UtenteId { get; set; }
        public string NumeroUtente { get; set; }
        public string UrlFoto { get; set; }
        public string NomeCompleto { get; set; }
        public String? DataDeNascimento { get; set; }
        public Genero Genero { get; set; }
        public string Telemovel { get; set; }
        public string Email { get; set; }
        public string Morada { get; set; }

        public DateTime DataInicioPreferencial { get; set; }
        public DateTime DataFimPreferencial { get; set; }
        public DateTime HorarioPreferencial { get; set; }
        public string NotasAdicionais { get; set; }

        public List<CriarActoClinicoDto> ActosClinicos{ get; set;}
    }
}
