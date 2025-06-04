using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFirstCRUD.DTO;
using MyFirstCRUD.entity;

namespace MyFirstCRUD.Contracts.Repository
{
    interface IEstadoRepository
    {
        Task<IEnumerable<EstadoEntity>> GetAll();

        Task<EstadoEntity> GetById(int id);

        Task Insert(EstadoInsertDTO estado);

        Task Delete(int id);

        Task Update(EstadoEntity estado);
    }
}

