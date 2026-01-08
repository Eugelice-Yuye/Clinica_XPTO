using ClinicAPI.DAL;
using ClinicAPI.DAL.Repositories;
using ClinicAPI.Interfaces.Repositories;
using ClinicAPI.Interfaces.Services;
using ClinicAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//política de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularClient", builder =>
    {
        builder
        .WithOrigins("http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials();
    });
});

// Add services to the container.
builder.Services.AddDbContext<ClinicAPIDbContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUtilizadorRepository,UtilizadorRepository>();
builder.Services.AddScoped<IUtenteRepository, UtenteRepository>();
builder.Services.AddScoped<ITipoServicoClinicoRepository, TipoServicoClinicoRepository>();
builder.Services.AddScoped<ISubsistemaSaudeRepository, SubsistemaSaudeRepository>();
builder.Services.AddScoped<IPedidoMarcacaoRepository, PedidoMarcacaoRepository>();
builder.Services.AddScoped<IActoClinicoRepository, ActoClinicoRepository>();
builder.Services.AddScoped<IProfissionalRepository, ProfissionalRepository>();

builder.Services.AddScoped<IUtilizadorServices, UtilizadorServices>();
builder.Services.AddScoped<IUtenteServices, UtenteServices>();
builder.Services.AddScoped<ITipoServicoClinicoServices, TipoServicoClinicoServices>();
builder.Services.AddScoped<ISubsistemaSaudeServices, SubsistemaSaudeServices>();
builder.Services.AddScoped<IPedidoMarcacaoServices, PedidoMarcacaoServices>();
builder.Services.AddScoped<IActoClinicoServices, ActoClinicoServices>();
builder.Services.AddScoped<IProfissionalServices, ProfissionalServices>();

builder.Services.AddScoped<IEmailServices, EmailServices>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAngularClient");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
