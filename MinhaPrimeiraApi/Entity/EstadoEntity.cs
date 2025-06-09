using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhaPrimeiraApi.entity
{
    class EstadoEntity
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public int Nacao_id { get; set; }
    }
}
