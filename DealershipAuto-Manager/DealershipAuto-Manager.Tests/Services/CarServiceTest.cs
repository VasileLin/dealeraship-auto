using AutoFixture;
using DealershipAuto_Manager.Dtos;
using DealershipAuto_Manager.Models;
using DealershipAuto_Manager.Repositories;
using DealershipAuto_Manager.Services;
using Moq;
using Xunit;

namespace DealershipAuto_Manager.Tests.Services
{
    public class CarServiceTest
    {
        [Fact]
        public void Add_InvalidCarData_ShouldThrowArgumentException()
        {
            //Arrange
            var carValidatorMock = new Mock<ICarValidator>();
            var carRepositoryMock = new Mock<ICarRepository>();

            carValidatorMock.Setup(m => m.IsValidAddCarDto(It.IsAny<AddCarDto>())).Returns(false);

            var sut = new CarService(carRepositoryMock.Object, carValidatorMock.Object);

            var addCarDto = new Fixture().Create<AddCarDto>();
            //Act
            var act = () => sut.Add(addCarDto);

            //Assert
            carValidatorMock.Verify(m => m.IsValidAddCarDto(It.IsAny<AddCarDto>()),Times.Once);
            Assert.Throws<ArgumentException>(act);
            carRepositoryMock.Verify(m => m.Add(It.IsAny<Car>()), Times.Never);
        }

        [Fact]
        public void Add_ValidCarData_ShouldAddCar()
        {
            //Arrange
            var carValidatorMock = new Mock<ICarValidator>();
            var carRepositoryMock = new Mock<ICarRepository>();

            carValidatorMock.Setup(m => m.IsValidAddCarDto(It.IsAny<AddCarDto>())).Returns(true);

            var sut = new CarService(carRepositoryMock.Object, carValidatorMock.Object);

            var addCarDto = new Fixture().Create<AddCarDto>();
            //Act
            sut.Add(addCarDto);

            //Assert
            carValidatorMock.Verify(m => m.IsValidAddCarDto(It.IsAny<AddCarDto>()),Times.Once);
            carRepositoryMock.Verify(m =>
            m.Add(It.Is<Car>(c=>c.
            Id != Guid.Empty
            && c.Brand == addCarDto.Brand
            && c.Model == addCarDto.Model
            && c.Price == addCarDto.Price
            && c.ProductionYear == addCarDto.ProductionYear
            && c.IsSold == false)),
            Times.Once);
        }

    }
}
