using Microsoft.EntityFrameworkCore;
using PersonManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PersonManager.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Person> Persons { get; set; }

        DbSet<Address> Addresses { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
