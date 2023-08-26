using DealershipAuto_Manager.Dtos;

namespace DealershipAuto_Manager.Services
{
    public class ClientValidator : IClientValidator
    {
        public bool IsValidAddClientDto(AddClientDto clientDto)
        {
            if (string.IsNullOrEmpty(clientDto.Name)) return false;

            return true;
        }

        public bool IsValidUpdateClientDto(AddClientDto clientDto)
        {
            if (string.IsNullOrEmpty(clientDto.Name)) return false;

            return true;
        }
    }
}
