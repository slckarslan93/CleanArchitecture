using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.Register;

namespace CleanArchitecture.Application.Services;
public interface IAuthService
{
    Task RegisterAsync(RegisterCommand request);
}
