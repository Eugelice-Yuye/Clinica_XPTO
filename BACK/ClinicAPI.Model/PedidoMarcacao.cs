using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicAPI.Model.enuns;

namespace ClinicAPI.Model
{
    [Table("PedidoMarcacoes")]
    public class PedidoMarcacao
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Utente")]
        public int UtenteId { get; set; }
        public Utente Utente { get; set; }
        public DateTime DataInicioPreferencial { get; set; }
        public DateTime DataFimPreferencial { get; set; }
        public DateTime HorarioPreferencial { get; set; }
        public String NotasAdicionais { get; set; }  
        public EstadoPedido Estado{get;set;} = EstadoPedido.Pedido;
        public ICollection<ActoClinico> ActosClinicos { get; set; }
    }
}
