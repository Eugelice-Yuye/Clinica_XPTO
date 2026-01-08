using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAPI.Model
{
    [Table("ActosClinicos")]
    public class ActoClinico
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("PedidoMarcacao")]
        public int PedidoMarcacaoId { get; set; }
        public PedidoMarcacao PedidoMarcacao { get; set; }

        [ForeignKey("TipoServicoClinico")]
        public int TipoServicoClinicoId { get; set; }
        public TipoServicoClinico TipoServicoClinico { get; set; }

        [ForeignKey("SubsistemaSaude")]
        public int SubsistemaSaudeId { get; set; }
        public SubsistemaSaude SubsistemaSaude { get; set; }

        [ForeignKey("Profissional")]
        public int ProfissionalId { get; set; }
        public Profissional Profissional{get;set;}
        public DateTime DataAgendada { get; set; }
        public DateTime DataRealizada { get; set; }
    }
}
