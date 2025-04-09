using CleanArchitecture.Application.Behaviors;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Persistance.Context;
using CleanArchitecture.Persistance.Services;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICarService, CarService>();

builder.Services.AddAutoMapper(typeof(CleanArchitecture.Persistance.AssemblyReference).Assembly);


builder.Services.AddControllers()
    .AddApplicationPart(typeof(CleanArchitecture.Presentation.AssemblyReference).Assembly); //controller'larýn bulunduðu assembly'i ekliyoruz (artik presenrarion katmaninda olacak controller lar)

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CleanArchitecture.Application.AssemblyReference).Assembly)); //mediator'ý ekliyoruz 

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

builder.Services.AddValidatorsFromAssembly(typeof(CleanArchitecture.Application.AssemblyReference).Assembly); //FluentValidation'ý ekliyoruz validationu otomatik oalrak alicak


string connectionString = builder.Configuration.GetConnectionString("SqlServer");

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connectionString));

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
