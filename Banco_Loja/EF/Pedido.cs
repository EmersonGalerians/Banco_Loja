using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banco.EF
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int Valor_Total { get; set; }
        public int Cliente_Id_Cliente { get; set; }
    }
}
