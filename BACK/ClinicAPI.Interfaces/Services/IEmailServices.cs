using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAPI.Interfaces.Services
{
    public interface IEmailServices
    {
        void Enviar(string para, string assunto, string corpo);
    }
}
