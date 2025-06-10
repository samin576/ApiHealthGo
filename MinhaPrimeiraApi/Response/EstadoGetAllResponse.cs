using MinhaPrimeiraApi.Entity;

namespace MinhaPrimeiraApi.Response
{
    public class EstadoGetAllResponse
    {
        public IEnumerable<EstadoEntity> Data { get; set; }
    }
}
