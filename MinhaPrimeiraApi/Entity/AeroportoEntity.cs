using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhaPrimeiraApi.Entity
{
    public class AeroportoEntity
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public string CodigoIata { get; set; }
        public int Cidade_id { get; set; }
    }
}
