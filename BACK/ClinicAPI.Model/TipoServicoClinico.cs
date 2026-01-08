using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAPI.Model
{
    [Table("TiposServicosClinicos")]
    public class TipoServicoClinico
    {
        [Key]
        public int Id { get; set; }
        public String Nome { get; set; }
        public String Descricao { get; set; }
        public bool EExame { get; set; }
        public ICollection<ActoClinico> ActosClinicos { get; set; }
    }
}
