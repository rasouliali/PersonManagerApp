using PersonManager.Application.Common.Mappings;
using PersonManager.Domain.Entities;

namespace PersonManager.Application.Persons.Queries.GetPersonsWithPagination
{
    public class PersonBriefDto : IMapFrom<Person>
    {
        public int Id { get; set; }

        public int ListId { get; set; }

        public string Title { get; set; }

        public bool Done { get; set; }
    }
}
