using DealershipAuto_Manager.Dtos;

namespace DealershipAuto_Manager.Services
{
    public interface ICarValidator
    {
        bool IsValidAddCarDto(AddCarDto carDto);
        bool IsValidUpdateCarDto(UpdateCarDto carDto);
    }
}
