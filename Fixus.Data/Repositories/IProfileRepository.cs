using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Design;
using System.Text;
using System.Threading.Tasks;
using Fixus.Data.Entities;

namespace Fixus.Data.Repositories
{
    public interface IProfileRepository
    {
        Profile Get(string username);

        Profile Get(int userId);

        void Add(string name, string gender, string description, bool isRepairman, int userId);
    }
}

