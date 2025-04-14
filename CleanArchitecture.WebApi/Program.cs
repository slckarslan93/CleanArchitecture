using CleanArchitecture.WebApi.Configuration;
using CleanArchitecture.WebApi.Middlewares;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.InstallServices(builder.Configuration, typeof(IServiceInstaller).Assembly);

//Kendin bir repostry pattern ekleyebilirsin unitofwork ile beraber cqrs ile uyumlu

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