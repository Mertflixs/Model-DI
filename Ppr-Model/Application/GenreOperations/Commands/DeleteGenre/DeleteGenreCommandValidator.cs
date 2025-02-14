using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Ppr_Model.Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommandValidator : AbstractValidator<DeleteGenreCommand>
    {
        public DeleteGenreCommandValidator() {
            RuleFor(command => command.GenreId).GreaterThan(0);
        }
    }
}