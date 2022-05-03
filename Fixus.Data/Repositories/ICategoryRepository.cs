using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Design;
using System.Text;
using System.Threading.Tasks;
using Fixus.Data.Entities;

namespace Fixus.Data.Repositories
{
    public interface ICategoryRepository
    {   
        Category Get(string name, int parentId);

        IEnumerable<Category> Get(int parentId);

        void Add(string name, int parentId);
    }
}

