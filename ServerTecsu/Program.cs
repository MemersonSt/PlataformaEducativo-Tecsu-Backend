using ServerTecsu.Business.DataAccess;
using ServerTecsu.Business.RegistrarEstudiante;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var sqlConnectionString = builder.Configuration.GetConnectionString("SqlConnection");
builder.Services.AddSingleton(new Configuracion(sqlConnectionString));
builder.Services.AddTransient<SqlHelper>();
builder.Services.AddTransient<IRegistrarEstudiante, RegistrarEstudiante>();
builder.Services.AddTransient<OperadorRegistrarEstudiante>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
