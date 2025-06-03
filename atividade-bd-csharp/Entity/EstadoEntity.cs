using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstCRUD.entity
{
    class EstadoEntity:NacaoEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public char Sigla {  get; set; }


    }
}
