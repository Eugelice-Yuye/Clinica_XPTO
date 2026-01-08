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
    [Table("Utilizadores")]
    public class Utilizador
    {
        [Key]
        public int Id { get; set; }

        public String Email { get; set; }

        public String Senha { get; set; }
        [Required]
        public TipoUtilizador TipoUtilizador{get;set;}
        public bool Activo {  get; set; }
    }
}
