using MinhaPrimeiraApi.DTO;
using MinhaPrimeiraApi.Entity;
using MinhaPrimeiraApi.Repository;

namespace MinhaPrimeiraApi.Contracts.Repository
{
    public interface INacaoRepository
    {
        Task<IEnumerable<NacaoEntity>> GetAll();
        Task<NacaoEntity> GetById(int id);
        Task Insert(NacaoInsertDTO nacao);
        Task Delete(int id);
        Task Update(NacaoEntity nacao);
    }
}
