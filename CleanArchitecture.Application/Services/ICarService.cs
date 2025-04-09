using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Features.CarFeatures.Commmands.CreateCar;

namespace CleanArchitecture.Application.Services;
public interface ICarService
{
    Task CreateAsync(CreateCarCommand request, CancellationToken cancellationToken);
}
