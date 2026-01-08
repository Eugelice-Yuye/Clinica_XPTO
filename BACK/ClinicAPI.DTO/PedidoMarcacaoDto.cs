using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicAPI.Model.enuns;

namespace ClinicAPI.DTO
{
    public class PedidoMarcacaoDto
    {
        public int Id { get; set; }
        public int UtenteId { get; set; }
        public DateTime DataInicioPreferencial { get; set; }
        public DateTime DataFimPreferencial { get; set; }
        public DateTime HorarioPreferencial { get; set; }
        public string NotasAdicionais { get; set; }
        public EstadoPedido Estado { get; set; }
        public List<ActoClinicoDto> ActosClinicos { get; set; }
    }
}
