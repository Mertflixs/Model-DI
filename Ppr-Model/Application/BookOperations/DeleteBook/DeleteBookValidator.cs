using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Ppr_Model.Application.BookOperations.DeleteBook
{
    public class DeleteBookValidator : AbstractValidator<DeleteBook>
    {
        public DeleteBookValidator()
        {
            RuleFor(command => command.bookId).GreaterThan(0);
        }
    }
}