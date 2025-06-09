using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinhaPrimeiraApi.DTO;
using MinhaPrimeiraApi.entity;

namespace MinhaPrimeiraApi.Contracts.Repository
{
    interface IAeroportoRepository
    {
        Task<IEnumerable<AeroportoEntity>> GetAll();

        Task<AeroportoEntity> GetById(int id);

        Task Insert(AeroportoInsertDTO aeroporto);

        Task Delete(int id);

        Task Update(AeroportoEntity aeroporto);
    }
}
