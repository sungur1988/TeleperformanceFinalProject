using Application.Features.ShoppingLists.Requests.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validations
{
    public class ShoppingListCompletedCommandValidator:AbstractValidator<ShoppingListCompletedCommand>
    {
        public ShoppingListCompletedCommandValidator()
        {
            RuleFor(x=>x.IsCompleted).Equal(true);
        }
    }
}
