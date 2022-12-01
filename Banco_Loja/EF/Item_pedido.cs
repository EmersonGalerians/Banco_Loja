using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banco.EF
{
    public class Item_pedido
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public int Valor_Total { get; set; }
        public int Produto_Id { get; set; }
        public int Pedidido_Id { get; set; }

    }
}
