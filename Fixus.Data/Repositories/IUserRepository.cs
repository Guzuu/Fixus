using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Design;
using System.Text;
using System.Threading.Tasks;
using Fixus.Data.Dtos;
using Fixus.Data.Entities;

namespace Fixus.Data.Repositories
{
    public interface IUserRepository
    {
        User Get(string username);

        User Get(int id);

        IEnumerable<User> Get();

        void Add(string username, string password);
    }
}

