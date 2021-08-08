using ContactInfoSystem.Models;
using ContactInfoSystem.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactInfoSystem.Repositories
{
    public interface IUnitOfWork
    {
        IRepository<Country> CountryRepository { get; }
        IRepository<Designation> DesignationRepository { get; }
        IUserRepository UserRepository { get; }
        IRepository<Role> RoleRepository { get; }

        int SaveChanges();
    }
}
