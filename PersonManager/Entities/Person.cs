using System.Collections.Generic;

namespace PersonManager.Domain.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public ICollection<Address> Addresses { get; set; }
    }
}
