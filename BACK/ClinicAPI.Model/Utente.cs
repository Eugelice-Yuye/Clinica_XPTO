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
    [Table("Utentes")]
    public class Utente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string NumeroUtente { get; set; }
        public String UrlFoto { get; set; }
        public String NomeCompleto { get; set; }
        public String? DataDeNascimento { get; set; }
        public Genero Genero{get;set;}
        public String Telemovel { get; set; }
        public String Email { get; set; }
        public String Morada { get; set; }

        [ForeignKey("Utilizador")]
        public int? UtilizadorId { get; set; }
        public Utilizador? Utilizador { get; set; }
        public ICollection<PedidoMarcacao> PedidoMarcacao { get; set; }
    }
}
