using AutoMapper;
using PersonManager.Application.Common.Mappings;
using PersonManager.Domain.Entities;
using System.Collections.Generic;

namespace PersonManager.Application.Common.Dtos
{
    public class PersonDto : IMapFrom<Person>
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public IList<AddressDto> Addresses { get; set; }
        public PersonDto()
        {
            Addresses = new List<AddressDto>();
        }
        //public int Id { get; set; }

        //public int ListId { get; set; }

        //public string Title { get; set; }

        //public bool Done { get; set; }

        //public int Priority { get; set; }

        //public string Note { get; set; }

        public void Mapping(Profile profile)
        {
            //profile.CreateMap<Person, PersonDto>()
            //    .ForMember(d => d.Priority, opt => opt.MapFrom(s => (int)s.Priority));
        }
    }
}
