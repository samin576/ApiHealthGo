using MinhaPrimeiraApi.DTO;
using MinhaPrimeiraApi.Entity;
using MinhaPrimeiraApi.Response;

namespace MinhaPrimeiraApi.Contracts.Services
{
    public interface IAeroportoService
    {
        Task<MessageResponse> Delete(int id);
        Task<AeroportoGetAllResponse> GetAll();
        Task<AeroportoEntity> GetById(int id);
        Task<MessageResponse> Post(AeroportoInsertDTO aeroporto);
        Task<MessageResponse> Update(AeroportoEntity aeroporto);
    }
}