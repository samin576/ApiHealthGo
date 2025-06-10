using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinhaPrimeiraApi.DTO;
using MinhaPrimeiraApi.Entity;

namespace MinhaPrimeiraApi.Contracts.Repository
{
    interface ICidadeRepository
    {
        Task<IEnumerable<CidadeEntity>> GetAll();

        Task<CidadeEntity> GetById(int id);

        Task Insert(CidadeInsertDTO cidade);

        Task Delete(int id);

        Task Update(CidadeEntity cidade);
    }
}
