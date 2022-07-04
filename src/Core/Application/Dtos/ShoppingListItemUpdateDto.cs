using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class ShoppingListItemUpdateDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsPurchased { get; set; }
        public int Amount { get; set; }
    }
}
