using System.Threading.Tasks;
using CleanArchitecture.Application.Features.CarFeatures.Commmands.CreateCar;
using CleanArchitecture.Application.Features.CarFeatures.Queries.GetAllCar;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Presentation.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CleanArchitecture.UnitTest
{
    public class CarsControllerUnitTest
    {
        [Fact]
        public async Task Create_ReturnsOkResult_WhenRequestIsValid()
        {
            //arrange
            var mediatrMock = new Mock<IMediator>();
            CreateCarCommand createCarCommand = new CreateCarCommand("Toyota", "Corolla", 5000);
            MessageResponse response = new("Car created successfully");
            CancellationToken cancellationToken = new();

            mediatrMock.Setup(m => m.Send(createCarCommand, cancellationToken)).ReturnsAsync(response);
            CarsController carsController = new(mediatrMock.Object);

            //act
            var result = await carsController.Create(createCarCommand, cancellationToken);

            //assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<MessageResponse>(okResult.Value);

            Assert.Equal(response, returnValue);
            mediatrMock.Verify(m => m.Send(createCarCommand, cancellationToken), Times.Once);
        }

     

    }
}
