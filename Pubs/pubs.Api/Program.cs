using Microsoft.EntityFrameworkCore;
using pubs.Infrastructure.Context;
using pubs.Infrastructure.Interfaces;
using pubs.Infrastructure.Logging;
using pubs.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

//Connection Strings
builder.Services.AddDbContext<PubsContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("PubsContext")));

//Repositories
builder.Services.AddScoped<IStoresRepository, StoresRepository>();
builder.Services.AddScoped<ICustomlogger, CustomLogger>();

//App Services
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
