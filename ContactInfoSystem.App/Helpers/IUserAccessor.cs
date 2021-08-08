using ContactInfoSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactInfoSystem.App.Helpers
{
    public interface IUserAccessor
    {
        User GetUser();

    }
}
