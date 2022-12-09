using PersonManager.Application.Common.Mappings;
using PersonManager.Domain.Entities;
using System.Collections.Generic;

namespace PersonManager.Application.Common.Dtos
{
    public class AddressDto : IMapFrom<Address>
    {
        public AddressDto()
        {
        }

        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
    }
}
