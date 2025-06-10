using MinhaPrimeiraApi.DTO;
using MinhaPrimeiraApi.Entity;
using MinhaPrimeiraApi.Repository;
using Microsoft.AspNetCore.Mvc;
using MinhaPrimeiraApi.Contracts.Services;
using MinhaPrimeiraApi.Response;
using MeuPrimeiroCrud.Repository;

namespace MinhaPrimeiraApi.Services
{
    public class CidadeService : ICidadeService
    {
        public async Task<MessageResponse> Delete(int id)
        {
            CidadeRepository _repository = new CidadeRepository();
            await _repository.Delete(id);
            return new MessageResponse
            {
                Message = "Cidade excluida com sucesso!"
            };
        }

        public async Task<CidadeGetAllResponse> GetAll()
        {
            CidadeRepository _repository = new CidadeRepository();
            return new CidadeGetAllResponse
            {
                Data = await _repository.GetAll()
            };
        }
        public async Task<CidadeEntity> GetById(int id)
        {
            CidadeRepository _repository = new CidadeRepository();
            return await _repository.GetById(id);
        }

        public async Task<MessageResponse> Post(CidadeInsertDTO cidade)
        {
            CidadeRepository _repository = new CidadeRepository();
            await _repository.Insert(cidade);
            return new MessageResponse
            {
                Message = "Cidade inserida com sucesso!"
            };

        }

        public async Task<MessageResponse> Update(CidadeEntity cidade)
        {
            CidadeRepository _repository = new CidadeRepository();
            await _repository.Update(cidade);
            return new MessageResponse
            {
                Message = "Cidade alterada com sucesso"
            };
        }
    }
}