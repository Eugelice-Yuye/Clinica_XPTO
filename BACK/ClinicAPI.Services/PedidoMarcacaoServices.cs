using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using ClinicAPI.DTO;
using ClinicAPI.Interfaces.Repositories;
using ClinicAPI.Interfaces.Services;
using ClinicAPI.Model.enuns;
using ClinicAPI.Model;
using System.Reflection.Metadata;
using QuestPDF.Helpers;

namespace ClinicAPI.Services
{
    public class PedidoMarcacaoServices : IPedidoMarcacaoServices
    {
        private readonly IPedidoMarcacaoRepository pedidoMarcacaoRepository;
        private readonly IUtenteRepository utenteRepository;
        private readonly IActoClinicoServices actoClinicoServices;
        private readonly IUtilizadorServices utilizadorServices;
        private readonly IEmailServices email;
        public PedidoMarcacaoServices(
        IPedidoMarcacaoRepository pedidoMarcacaoRepository,
        IActoClinicoServices actoClinicoServices,
        IUtilizadorServices utilizadorServices,
        IEmailServices email,
        IUtenteRepository utenteRepository)
        {
            this.pedidoMarcacaoRepository = pedidoMarcacaoRepository;
            this.utenteRepository = utenteRepository;
            this.actoClinicoServices = actoClinicoServices;
            this.utilizadorServices = utilizadorServices;
            this.email = email;
        }
        public PedidoMarcacaoDto CriarPedido(CriarPedidoDto dto)
        {
            int utenteId;
            if (dto.UtenteId.HasValue && dto.UtenteId.Value > 0)
            {
                utenteId = dto.UtenteId.Value;
            }
            else
            {
                var novoUtente = new Utente
                {
                    NumeroUtente = dto.NumeroUtente,
                    UrlFoto = dto.UrlFoto,
                    NomeCompleto = dto.NomeCompleto,
                    DataDeNascimento = dto.DataDeNascimento,
                    Genero = dto.Genero,
                    Telemovel = dto.Telemovel,
                    Email = dto.Email,
                    Morada = dto.Morada,
                    UtilizadorId = null
                };
                utenteRepository.AdicionarUtente(novoUtente);
                utenteRepository.Salvar();
                Console.WriteLine($"Novo utente criado com ID: {novoUtente.Id}");
                utenteId = novoUtente.Id;
            }
            var entidade = new PedidoMarcacao
            {
                UtenteId = utenteId,
                DataInicioPreferencial = dto.DataInicioPreferencial,
                DataFimPreferencial = dto.DataFimPreferencial,
                HorarioPreferencial = dto.HorarioPreferencial,
                NotasAdicionais = dto.NotasAdicionais,
                Estado = EstadoPedido.Pedido,
                ActosClinicos = dto.ActosClinicos
                   .Select(c => new ActoClinico
                   {
                       TipoServicoClinicoId = c.TipoServicoClinicoId,
                       SubsistemaSaudeId = c.SubsistemaSaudeId,
                       ProfissionalId = c.ProfissionalId ?? 0,
                   })
                   .ToList()
            };
            pedidoMarcacaoRepository.Adicionar(entidade);
            pedidoMarcacaoRepository.Salvar();
            return Map(entidade);
        }

        public IEnumerable<PedidoMarcacaoDto> ListarTodos() =>
            pedidoMarcacaoRepository.ObterTodos()
                 .Select(Map);

        public PedidoMarcacaoDto ObterPorId(int id)
        {
            var p = pedidoMarcacaoRepository.ObterPorId(id) ?? throw new Exception("Pedido não encontrado");
            return Map(p);
        }

        public IEnumerable<PedidoMarcacaoDto> ObterPorUtente(int utenteId) =>
            pedidoMarcacaoRepository.ObterTodos()
                 .Where(p => p.UtenteId == utenteId)
                 .Select(Map);

        public PedidoMarcacaoDto Agendar(int id, AgendarDto dto)
        {
            var p = pedidoMarcacaoRepository.ObterPorId(id) ?? throw new Exception("Pedido não existe");
            if (p.Estado != EstadoPedido.Pedido)
                throw new Exception("Somente pedidos podem ser agendados");

            p.Estado = EstadoPedido.Agendado;
            p.DataInicioPreferencial = dto.DataAgendada;

            foreach (var a in p.ActosClinicos)
                a.DataAgendada = dto.DataAgendada;

            pedidoMarcacaoRepository.Actualizar(p);
            pedidoMarcacaoRepository.Salvar();

            //utente sem login, cria um
            if (p.Utente.Utilizador == null)
            {
                var senha = "xpto123";
                var novovUtilziador = utilizadorServices.CriarUtilizador(new CriarUtilizadorDto
                {
                    Email = p.Utente.Email,
                    Senha = senha,
                    TipoUtilizador = TipoUtilizador.Utente
                });
                p.Utente.UtilizadorId = novovUtilziador.Id;
                utenteRepository.Actualizar(p.Utente);
                utenteRepository.Salvar();

                /* email.Enviar(p.Utente.Email,
                 "Clínica XPTO",
                 $"Olá {p.Utente.NomeCompleto},\n" +
                 $"Seja muito bem-vindo (a) à família da clínica XPTO!,\n" +
                 $"O seu acesso à plataforma foi criado com sucesso. A partir de agora,\n" +
                 $"poderá gerir as suas marcações e consultar as suas informações com mais facilidade.\n" +
                 $"\n📧 Email de acesso : {p.Utente.Email}\n 🔐 Senha: {senha}\n" +
                 $"\nRecomendamos que altere a senha assim que fizer o primeiro login para garantir a segurança da sua conta.\n" +
                 $"Com carinho,\n" +
                 $"Equipa Clínica XPTO\n" );*/
            }

            //email de confirmação
            var assunto = "Marcação agendada na Clínica XPTO";
            var corpo = $"Olá {p.Utente.NomeCompleto},\n" +
                        $"\nA sua marcação foi confirmada com sucesso!\n" +
                        $"📌 Número do pedido #{p.Id}\n" +
                        $"📅 Data agendada {dto.DataAgendada}\n" +
                        $"\nAgradecemos a confiança!,\n" +
                        $"\nAtenciosamente,\n" +
                        $"Equipa Clínica XPTO\n";
            email.Enviar(p.Utente.Email, assunto, corpo);

            return Map(p);
        }

        public PedidoMarcacaoDto MarcarRealizado(int id)
        {
            var p = pedidoMarcacaoRepository.ObterPorId(id) ?? throw new Exception("Pedido não existe");
            p.Estado = EstadoPedido.Realizado;
            foreach (var a in p.ActosClinicos)
                a.DataRealizada = DateTime.Now;

            pedidoMarcacaoRepository.Actualizar(p);
            pedidoMarcacaoRepository.Salvar();
            return Map(p);
        }

        public PedidoMarcacaoDto MarcarCancelado(int id)
        {
            var p = pedidoMarcacaoRepository.ObterPorId(id) ?? throw new Exception("Pedido não existe");
            p.Estado = EstadoPedido.Cancelado;
            foreach (var a in p.ActosClinicos)
                a.DataRealizada = DateTime.Now;

            pedidoMarcacaoRepository.Actualizar(p);
            pedidoMarcacaoRepository.Salvar();
            return Map(p);
        }


        /*public byte[] ExportarPdf(int id)
        {
            var p = pedidoMarcacaoRepository.ObterPorId(id) ?? throw new Exception("Pedido não existe");

            using (var ms = new MemoryStream())
            {
                iTextSharp.text.Document document = new iTextSharp.text.Document();
                PdfWriter.GetInstance(document, ms);

                document.Open();

                // Adicionar conteúdo
                document.Add(new Paragraph($"Pedido #{p.Id}"));
                document.Add(new Paragraph($"Utente: {p.Utente.NomeCompleto}"));
                document.Add(new Paragraph($"Estado: {p.Estado}"));

                foreach (var a in p.ActosClinicos)
                {
                    document.Add(new Paragraph($" - Acto {a.Id}: serviço {a.TipoServicoClinicoId} agendada {a.DataAgendada}"));
                }

                document.Close();
                return ms.ToArray();
            }
        }*/

        public byte[] ExportarPdf(int id)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            var p = pedidoMarcacaoRepository.ObterPorId(id) ?? throw new Exception("Pedido não existe");

            string logoBase64 = "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";


            var document = QuestPDF.Fluent.Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(40);
                    page.DefaultTextStyle(x => x.FontSize(11).FontFamily("Helvetica"));

                    // Converter para byte
                    byte[] logoBytes = Convert.FromBase64String(logoBase64);

                    // Cabeçalho
                    page.Header()
                        .MinHeight(100)
                        .Background("#2c3e50")
                        .Column(col =>
                        {
                            col.Item().Row(row =>
                            {

                                row.ConstantItem(80).PaddingTop(10).Image(logoBytes, ImageScaling.FitWidth);

                                row.RelativeItem().Column(c =>
                                {
                                    c.Item().PaddingTop(30).Text("Clínica XPTO")
                                        .Bold().FontSize(20).FontColor(Colors.White);
                                    c.Item().Text("Excelência em cuidados de saúde")
                                        .FontSize(12).FontColor("#ecf0f1");
                                });
                            });

                            
                            col.Item().PaddingTop(5).BorderBottom(1).BorderColor("#3498db");
                        });

                    // contxudooo principal
                    page.Content()
                        .PaddingVertical(10)
                        .Column(col =>
                        {
                            col.Item().AlignCenter().Text($"DETALHES DA MARCAÇÃO #{p.Id}")
                                .Bold().FontSize(16).FontColor("#2c3e50");

                            col.Item().PaddingTop(10).Text($"Nome: {p.Utente.NomeCompleto}");
                            col.Item().PaddingTop(10).Text($"Telemóvel: {p.Utente.Telemovel}");
                            col.Item().PaddingTop(10).Text($"Estado do pedido: {p.Estado}");
                            col.Item().PaddingTop(10).Border(1).BorderColor("#bdc3c7").Padding(5).Column(actoCol =>
                            {
                                foreach (var acto in p.ActosClinicos)
                                {
                                    actoCol.Item().Text($"Acto Clínico nº: {acto.Id}");
                                    actoCol.Item().Text($" - Especialidade: {acto.TipoServicoClinico.Nome}");
                                    actoCol.Item().Text($" - Tipo de Serviço clínico: {(acto.TipoServicoClinico.EExame ? "Exame" : "Consulta")}");
                                    actoCol.Item().Text($" - Profissional: {acto.Profissional.Nome}");
                                    actoCol.Item().Text($" - Subsistema de saúde: {acto.SubsistemaSaude.Nome}");
                                    actoCol.Item().Text($" - Agendado: {acto.DataAgendada:dd/MM/yyyy HH:mm}");
                                }
                            });

                        });

                    // Rodapé 
                    page.Footer()
                        .AlignCenter()
                        .Text(text =>
                        {
                            text.Span("Email: clinicaxpto2025@gmail.com").Underline().FontColor("#3498db");
                            text.Span(" | Página ");
                            text.CurrentPageNumber().FontColor("#3498db");
                        });
                });
            });

            return document.GeneratePdf();
        }

        private PedidoMarcacaoDto Map(PedidoMarcacao p) =>
                    new PedidoMarcacaoDto
                    {
                        Id = p.Id,
                        UtenteId = p.UtenteId,
                        DataInicioPreferencial = p.DataInicioPreferencial,
                        DataFimPreferencial = p.DataFimPreferencial,
                        HorarioPreferencial = p.HorarioPreferencial,
                        NotasAdicionais = p.NotasAdicionais,
                        Estado = p.Estado,
                        ActosClinicos = p.ActosClinicos
                                           .Select(a => new ActoClinicoDto
                                           {
                                               Id = a.Id,
                                               PedidoMarcacaoId = a.PedidoMarcacaoId,
                                               TipoServicoClinicoId = a.TipoServicoClinicoId,
                                               SubsistemaSaudeId = a.SubsistemaSaudeId,
                                               ProfissionalId = a.ProfissionalId,
                                               DataAgendada = a.DataAgendada,
                                               DataRealizada = a.DataRealizada
                                           })
                                           .ToList()
                    };
    }
}
