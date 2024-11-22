using BuildingBlocks.CQRS;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ordering.Application.Orders.Commands.DeleteOrder
{
    public record DeleteOrderCommand(Guid OrderId): ICommand<DeleteOrderResult>
    {
    }

    public record DeleteOrderResult(bool IsSuccess);

    public class DeleteOrderValidation: AbstractValidator<DeleteOrderCommand>
    {
        public DeleteOrderValidation() 
        {
            RuleFor(x => x.OrderId).NotEmpty().WithMessage("OrderId is required");
        }
    }
}
