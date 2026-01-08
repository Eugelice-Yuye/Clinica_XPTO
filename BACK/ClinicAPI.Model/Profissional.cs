using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAPI.Model
{
    [Table("Profissionais")]
    public class Profissional
    {
        [Key]
        public int Id { get; set; }
        public String Nome { get; set; }
        public String Especialidade { get; set; }
        public int? UtilizadorId { get; set; }
        public Utilizador? Utilizador { get; set; }
        public ICollection<ActoClinico> ActosClinicos { get; set; }
    }
}
