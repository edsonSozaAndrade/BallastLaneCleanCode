using Core.Implementations;
using Core.Interfaces;
using Infrastructure.Context;
using Infrastructure.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add contexts
builder.Services.AddSingleton(provider => new LiteContext("UserDb.db"));

// Registrar casos de uso
builder.Services.AddScoped<CreateNewUser>();
builder.Services.AddScoped<GetUser>();
builder.Services.AddScoped<GetAllUsers>();
builder.Services.AddScoped<UpdateExistingUser>();
builder.Services.AddScoped<DeleteExistingUser>();

//Register Repositories
builder.Services.AddScoped<IUserRepository, UserRepositoryLiteDb>();

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
