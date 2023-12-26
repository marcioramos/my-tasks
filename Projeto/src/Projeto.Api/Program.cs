using Projeto.Api.Extencions;
using Projeto.Application;
using Projeto.Data;
using Projeto.Data.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureDataApp(builder.Configuration);
builder.Services.ConfigureApplicationApp();
builder.Services.ConfigureCorsPolicy();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

CreateDataBase(app);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors();
app.MapControllers();
app.Run();

static void CreateDataBase(WebApplication app)
{
    var serviceScope = app.Services.CreateScope();
    var dataContext = serviceScope.ServiceProvider.GetService<ContextoBd>();
    dataContext?.Database.EnsureCreated();
}