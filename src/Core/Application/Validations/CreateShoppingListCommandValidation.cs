using Application.Features.ShoppingLists.Requests.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validations
{
    public class CreateShoppingListCommandValidation :AbstractValidator<CreateShoppingListCommand>
    {
        public CreateShoppingListCommandValidation()
        {
            RuleFor(x => x.Note).MinimumLength(5).MaximumLength(100);
            RuleFor(x => x.CategoryId).NotEmpty();
            RuleFor(x => x.name).MinimumLength(3);
        }
    }
}
