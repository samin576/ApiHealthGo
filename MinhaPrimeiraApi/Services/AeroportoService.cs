using MinhaPrimeiraApi.DTO;
using MinhaPrimeiraApi.Entity;
using MinhaPrimeiraApi.Repository;
using Microsoft.AspNetCore.Mvc;
using MinhaPrimeiraApi.Contracts.Services;
using MinhaPrimeiraApi.Response;
using MeuPrimeiroCrud.Repository;

namespace MinhaPrimeiraApi.Services
{
    public class AeroportoService : IAeroportoService
    {
        public async Task<MessageResponse> Delete(int id)
        {
            AeroportoRepository _repository = new AeroportoRepository();
            await _repository.Delete(id);
            return new MessageResponse
            {
                Message = "Aeroporto excluido com sucesso!"
            };
        }

        public async Task<AeroportoGetAllResponse> GetAll()
        {
            AeroportoRepository _repository = new AeroportoRepository();
            return new AeroportoGetAllResponse
            {
                Data = await _repository.GetAll()
            };
        }
        public async Task<AeroportoEntity> GetById(int id)
        {
            AeroportoRepository _repository = new AeroportoRepository();
            return await _repository.GetById(id);
        }

        public async Task<MessageResponse> Post(AeroportoInsertDTO aeroporto)
        {
            AeroportoRepository _repository = new AeroportoRepository();
            await _repository.Insert(aeroporto);
            return new MessageResponse
            {
                Message = "Aeroporto inserido com sucesso!"
            };

        }

        public async Task<MessageResponse> Update(AeroportoEntity aeroporto)
        {
            AeroportoRepository _repository = new AeroportoRepository();
            await _repository.Update(aeroporto);
            return new MessageResponse
            {
                Message = "Aeroporto alterado com sucesso"
            };
        }
    }
}