using PersonManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PersonManager.Infrastructure.Persistence.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            //builder.Ignore(e => e.DomainEvents);

            builder.HasOne(c => c.CurrentPerson).WithMany(c => c.Addresses).HasForeignKey(c=>c.PersonId);

            builder.Property(t => t.City)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(t => t.Street)
                .HasMaxLength(300)
                .IsRequired();
        }
    }
}