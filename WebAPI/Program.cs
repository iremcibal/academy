using Autofac;
using Business;
using Business.DependencyResolvers.Autofac;
using Business.DependencyResolvers;
using Core.Extensions;
using Core.DependencyResolvers;
using Autofac.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
// Add services to the container.
//builder.Services.AddBusinessService();
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(
    builder => builder.RegisterModule(new AutofacBusinessModule()));
builder.Services.AddDependencyResolvers(new ICoreModule[]
{
    new CoreModule(),
    new BusinessCoreModule()
});
builder.Services.AddControllers();

builder.Services.AddCors();
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

app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowAnyOrigin());

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
