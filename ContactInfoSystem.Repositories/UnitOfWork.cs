using ContactInfoSystem.Models;
using ContactInfoSystem.Repositories.Implementations;
using ContactInfoSystem.Repositories.Interfaces;

namespace ContactInfoSystem.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        ContactInfoDbContext _ContactInfoDbContext;
        public UnitOfWork(ContactInfoDbContext ContactInfoDbContext)
        {
            _ContactInfoDbContext = ContactInfoDbContext;
        }

        private IRepository<Country> _countryRepository;
        public IRepository<Country> CountryRepository
        {
            get
            {
                if (_countryRepository == null)
                    _countryRepository = new Repository<Country>(_ContactInfoDbContext);
                return _countryRepository;
            }
        }

        private IRepository<Designation> _designationRepository;
        public IRepository<Designation> DesignationRepository
        {
            get
            {
                if (_designationRepository == null)
                    _designationRepository = new Repository<Designation>(_ContactInfoDbContext);
                return _designationRepository;
            }
        }



        private IRepository<Role> _roleRepository;
        public IRepository<Role> RoleRepository
        {
            get
            {
                if (_roleRepository == null)
                    _roleRepository = new Repository<Role>(_ContactInfoDbContext);
                return _roleRepository;
            }
        }

        private IUserRepository _UserRepository;
        public IUserRepository UserRepository
        {
            get
            {
                if (_UserRepository == null)
                    _UserRepository = new UserRepository(_ContactInfoDbContext);
                return _UserRepository;
            }
        }


        public int SaveChanges()
        {
            return _ContactInfoDbContext.SaveChanges();
        }
    }
}
