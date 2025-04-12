﻿using System.Text;
using CleanArchitecture.Infrastructure.Authantication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CleanArchitecture.WebApi.OptionsSetup;

public sealed class JwtBearerOptionsSetup : IPostConfigureOptions<JwtBearerOptions>
{
    private readonly JwtOptions _jwtOptions;

    public JwtBearerOptionsSetup(IOptions<JwtOptions> jwtOptions)
    {
        _jwtOptions = jwtOptions.Value; //constructer da bu sekilde gecmezsek degerini almiyor interface ile geciceksin options pattern
    }

    public void PostConfigure(string name, JwtBearerOptions options)
    {
       options.TokenValidationParameters.ValidateIssuer = true;
       options.TokenValidationParameters.ValidateAudience = true;
       options.TokenValidationParameters.ValidateLifetime = true;
       options.TokenValidationParameters.ValidateIssuerSigningKey = true;
       options.TokenValidationParameters.ValidIssuer = _jwtOptions.Issuer;
       options.TokenValidationParameters.ValidIssuer = _jwtOptions.Audience;
       options.TokenValidationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey));

    }
}
