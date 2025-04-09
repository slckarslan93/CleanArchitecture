using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Features.CarFeatures.Queries.GetAllCar;
public sealed record GetAllCarQuery(int pageNumber = 1 , int pageSize = 10,string search = "") : IRequest<IList<Car>>;

//paginationu da manuel olarak yaz 