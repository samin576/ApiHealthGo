using MinhaPrimeiraApi.DTO;
using MinhaPrimeiraApi.Entity;
using MinhaPrimeiraApi.Repository;
using Microsoft.AspNetCore.Mvc;
using MinhaPrimeiraApi.Contracts.Services;
using MinhaPrimeiraApi.Response;
using MeuPrimeiroCrud.Repository;

namespace MinhaPrimeiraApi.Services
{
    public class NacaoService : INacaoService
    {
        public async Task<MessageResponse> Delete(int id)
        {
            NacaoRepository _repository = new NacaoRepository();
            await _repository.Delete(id);
            return new MessageResponse
            {
                Message = "Nação excluida com sucesso!"
            };
        }

        public async Task<NacaoGetAllResponse> GetAll()
        {
            NacaoRepository _repository = new NacaoRepository();
            return new NacaoGetAllResponse
            {
                Data = await _repository.GetAll()
            };
        }
        public async Task<NacaoEntity> GetById(int id)
        {
            NacaoRepository _repository = new NacaoRepository();
            return await _repository.GetById(id);
        }

        public async Task<MessageResponse> Post(NacaoInsertDTO nacao)
        {
            NacaoRepository _repository = new NacaoRepository();
            await _repository.Insert(nacao);
            return new MessageResponse
            {
                Message = "Nação inserida com sucesso!"
            };

        }

        public async Task<MessageResponse> Update(NacaoEntity nacao)
        {
            NacaoRepository _repository = new NacaoRepository();
            await _repository.Update(nacao);
            return new MessageResponse
            {
                Message = "Nação alterada com sucesso"
            };
        }
    }
}