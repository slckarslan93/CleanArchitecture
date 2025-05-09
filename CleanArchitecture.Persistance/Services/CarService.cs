﻿using AutoMapper;
using CleanArchitecture.Application.Features.CarFeatures.Commmands.CreateCar;
using CleanArchitecture.Application.Features.CarFeatures.Queries.GetAllCar;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistance.Services;

public sealed class CarService : ICarService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public CarService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task CreateAsync(CreateCarCommand request, CancellationToken cancellationToken)
    {
        Car car = _mapper.Map<Car>(request);
        await _context.Set<Car>().AddAsync(car, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IList<Car>> GetAllAsync(GetAllCarQuery request, CancellationToken cancellationToken)
    {
        IList<Car> cars = await _context.Set<Car>().ToListAsync(cancellationToken);
        return cars;
    }
}