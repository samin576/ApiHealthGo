using System.Text;
using System.Threading.Tasks;
using MyFirstCRUD.DTO;
using MyFirstCRUD.entity;

namespace MyFirstCRUD.Contracts.Repository
{
    interface INacaoRepository
    {
        Task<IEnumerable<NacaoEntity>> GetAll();
        Task<NacaoEntity> GetById(int id);
        Task Insert(NacaoInsertDTO nacao);
        Task Delete(int id);
        Task Update(NacaoEntity nacao);
    }
}
