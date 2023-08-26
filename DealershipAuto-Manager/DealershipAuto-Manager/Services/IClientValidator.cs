using DealershipAuto_Manager.Dtos;

namespace DealershipAuto_Manager.Services
{
    public interface IClientValidator
    {
        bool IsValidAddClientDto(AddClientDto clientDto);
        bool IsValidUpdateClientDto(AddClientDto clientDto);
    }
}
