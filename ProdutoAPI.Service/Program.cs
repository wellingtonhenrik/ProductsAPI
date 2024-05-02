using ProdutoAPI.Service.Extensions;
using ProdutoAPI.Infra.IoC.Extensions;
using Serilog.Sinks.LogBee.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSerilogConfig(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddSwaggerDoc();
builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddDbContextConfig(builder.Configuration); //SqlServer
builder.Services.AddMongoDBConfig(builder.Configuration); //MongoDB
builder.Services.AddDependecyInjector(); //Serviços
builder.Services.AddMediatRConfig(); //MediatR 
builder.Services.AddJwtBearerConfig(builder.Configuration); //JWT

var app = builder.Build();

app.UseSwaggerDoc();
app.UseHttpsRedirection();
//resonsavel pela autenticação e tem que estar nessa ordem
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseLogBeeMiddleware();
app.Run();

//tornando classe publica
public partial class Program { }