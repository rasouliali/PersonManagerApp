using FluentValidation;

namespace PersonManager.Application.Persons.Queries.GetPersonsWithPagination
{
    public class GetPersonsWithPaginationQueryValidator : AbstractValidator<GetPersonsWithPaginationQuery>
    {
        public GetPersonsWithPaginationQueryValidator()
        {

            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
        }
    }
}
