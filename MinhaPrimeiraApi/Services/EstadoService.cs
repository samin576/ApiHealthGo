using MinhaPrimeiraApi.DTO;
using MinhaPrimeiraApi.Entity;
using MinhaPrimeiraApi.Repository;
using Microsoft.AspNetCore.Mvc;
using MinhaPrimeiraApi.Contracts.Services;
using MinhaPrimeiraApi.Response;
using MeuPrimeiroCrud.Repository;

namespace MinhaPrimeiraApi.Services
{
    public class EstadoService : IEstadoService
    {
        public async Task<MessageResponse> Delete(int id)
        {
            EstadoRepository _repository = new EstadoRepository();
            await _repository.Delete(id);
            return new MessageResponse
            {
                Message = "Estado excluido com sucesso!"
            };
        }

        public async Task<EstadoGetAllResponse> GetAll()
        {
            EstadoRepository _repository = new EstadoRepository();
            return new EstadoGetAllResponse
            {
                Data = await _repository.GetAll()
            };
        }
        public async Task<EstadoEntity> GetById(int id)
        {
            EstadoRepository _repository = new EstadoRepository();
            return await _repository.GetById(id);
        }

        public async Task<MessageResponse> Post(EstadoInsertDTO estado)
        {
            EstadoRepository _repository = new EstadoRepository();
            await _repository.Insert(estado);
            return new MessageResponse
            {
                Message = "Estado inserido com sucesso!"
            };

        }

        public async Task<MessageResponse> Update(EstadoEntity estado)
        {
            EstadoRepository _repository = new EstadoRepository();
            await _repository.Update(estado);
            return new MessageResponse
            {
                Message = "Estado alterado com sucesso"
            };
        }
    }
}