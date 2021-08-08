using ContactInfoSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactInfoSystem.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        PagingModel<UserModel> GetUsers(int page, int pageSize);
    }
}
