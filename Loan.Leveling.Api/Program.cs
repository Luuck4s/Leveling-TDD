using System.Reflection;
using Loan.Leveling.TDD.Domain.Repository;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurando MediatR
var assembly = Assembly.Load(new AssemblyName("Loan.Leveling.TDD.Domain"));
builder.Services.AddMediatR(assembly);

// Configurando o Repository
builder.Services.AddTransient<IFriendRepository, FriendRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();