using Microsoft.EntityFrameworkCore;
using todo_list.API.Data;
using todo_list.API.Data.Repositories;
using todo_list.API.Data.Repositories.Interfaces;
using todo_list.API.Services;
using todo_list.API.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>
    (options => options
    .UseSqlServer(builder
    .Configuration
    .GetConnectionString("Default")));

//Injeção de dependência
builder.Services.AddScoped<ITarefaService, TarefaService>();
builder.Services.AddScoped<ITarefaRepository, TarefaRepository>();
builder.Services.AddScoped<IContextRepository, ContextRepository>();

builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
