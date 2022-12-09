namespace PersonManager.Domain.Entities
{ 
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int PersonId { get; set; }
        public Person CurrentPerson { get; set; }
    }
}
