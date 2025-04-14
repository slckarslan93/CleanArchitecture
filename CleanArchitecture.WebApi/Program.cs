using CleanArchitecture.Application.Abstractions;
using CleanArchitecture.Application.Behaviors;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Authantication;
using CleanArchitecture.Persistance.Services;
using CleanArchitecture.WebApi.Middlewares;
using CleanArchitecture.WebApi.OptionsSetup;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddTransient<ExceptionMiddleware>();
builder.Services.AddAutoMapper(typeof(CleanArchitecture.Persistance.AssemblyReference).Assembly);

builder.Services.AddIdentity<User, Role>().AddEntityFrameworkStores<AppDbContext>();

builder.Services.ConfigureOptions<JwtOptionsSetup>(); //JWT ayarlar�n� al�r ve ayarlar
builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();

builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IUserRoleService, UserRoleService>();

builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddAuthorization();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials().SetIsOriginAllowed(policy => true));
     
});

builder.Services.AddScoped<IJwtProvider, JwtProvider>();

builder.Services.AddControllers()
    .AddApplicationPart(typeof(CleanArchitecture.Presentation.AssemblyReference).Assembly); //controller'lar�n bulundu�u assembly'i ekliyoruz (artik presenrarion katmaninda olacak controller lar)

//Kendin bir repostry pattern ekleyebilirsin unitofwork ile beraber cqrs ile uyumlu

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CleanArchitecture.Application.AssemblyReference).Assembly)); //mediator'� ekliyoruz

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

builder.Services.AddValidatorsFromAssembly(typeof(CleanArchitecture.Application.AssemblyReference).Assembly); //FluentValidation'� ekliyoruz validationu otomatik oalrak alicak

string connectionString = builder.Configuration.GetConnectionString("SqlServer");

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connectionString));

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseCors();
app.UseMiddlewareExtension();

app.UseHttpsRedirection();

//app.UseAuthorization(); //service olarak yazdigimiz icin middleware ye gerek kalmadi

app.MapControllers();

app.Run();