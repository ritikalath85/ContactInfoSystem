using ContactInfoSystem.Models;
using ContactInfoSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace ContactInfoSystem.Repositories.Implementations
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public ContactInfoDbContext context
        {
            get
            {
                return _dbContext as ContactInfoDbContext;
            }
        }
        public UserRepository(DbContext _db) : base(_db)
        {

        }
        public PagingModel<UserModel> GetUsers(int page, int pageSize)
        {
            var data = from users in context.Users
                       join userRoles in context.UserRoles
                       on users.Id equals userRoles.UserId
                       join roles in context.Roles
                       on userRoles.RoleId equals roles.Id
                       join country in context.Countries
                       on users.CountryId equals country.CountryId
                       select new UserModel
                       {
                           Id = users.Id,
                           Name = users.Name,
                           UserImageName = users.UserImageName,
                           Username = users.UserName,
                           RoleName = roles.Name,
                           PhoneNumber = users.PhoneNumber,
                           CountryName = country.CountryName,
                           GenderName = users.Gender == 1 ? "Male" : "Female"

                       };

            int count = data.Count();
            var dataList = data.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            PagingModel<UserModel> model = new PagingModel<UserModel>();
            if (dataList.Count > 0)
            {
                model.Data = new StaticPagedList<UserModel>(dataList, page, pageSize, count);
                model.Page = page;
                model.PageSize = pageSize;
                model.TotalPages = count;
            }
            return model;
        }

    }
}
