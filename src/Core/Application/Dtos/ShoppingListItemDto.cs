using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class ShoppingListItemDto
    {
        public string Name { get; set; }
        public StockUnitDto StockUnit { get; set; }
    }
}
