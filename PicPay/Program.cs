using Microsoft.EntityFrameworkCore;
using PicPay.Infra;
using PicPay.Repositories;
using PicPay.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var serverVersion = new MySqlServerVersion(new Version(8, 0, 32));
builder.Services.AddDbContext<ApplicationDbContext>(options => options
    .UseMySql(builder.Configuration.GetConnectionString("defaultConnection"), serverVersion));

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<ICarteiraRepository, CarteiraRepository>();

builder.Services.AddScoped<IUsuarioService, UsuarioService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
}

app.UseHttpsRedirection();

app.UseRouting();

app.MapControllers();

app.Run();

