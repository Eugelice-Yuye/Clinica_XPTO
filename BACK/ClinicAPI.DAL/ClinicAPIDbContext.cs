using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ClinicAPI.Model;

namespace ClinicAPI.DAL
{
    public class ClinicAPIDbContext : DbContext
    {
        public ClinicAPIDbContext(DbContextOptions<ClinicAPIDbContext> options) : base(options)
        {
        }

        public DbSet<Utilizador> Utilizadores { get; set; }
        public DbSet<Utente> Utentes { get; set; } 
        public DbSet<TipoServicoClinico> TiposServicosClinicos { get; set; }
        public DbSet<SubsistemaSaude> SubsistemasSaude { get; set; }
        public DbSet<Profissional> Profissionais {  get; set; }
        public DbSet<PedidoMarcacao> PedidoMarcacoes { get; set; }
        public DbSet<ActoClinico> ActosClinicos { get; set; }
    }
}
