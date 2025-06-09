using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinhaPrimeiraApi.DTO;
using MinhaPrimeiraApi.entity;

namespace MinhaPrimeiraApi.Contracts.Repository
{
    interface IEspecialidadeRepository
    {
        Task<IEnumerable<EspecialidadeEntity>> GetAll();

        Task<EspecialidadeEntity> GetById(int id);

        Task Insert(EspecialidadeInsertDTO especialidade);

        Task Delete(int id);

        Task Update(EspecialidadeEntity especialidade);
    }
}
