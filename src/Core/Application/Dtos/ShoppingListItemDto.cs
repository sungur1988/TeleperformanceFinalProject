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
        public string StockUnit { get; set; }
        public int Amount { get; set; }
        public bool IsPurchased { get; set; }
    }
}
