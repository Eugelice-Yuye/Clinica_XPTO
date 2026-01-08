using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicAPI.Model.enuns;

namespace ClinicAPI.DTO
{
    public class NovoProfissionalDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public String Especialidade { get; set; }
        public String Email { get; set; }
        public String Senha { get; set; }
        public TipoUtilizador TipoUtilizador { get; set; }
    }
}
