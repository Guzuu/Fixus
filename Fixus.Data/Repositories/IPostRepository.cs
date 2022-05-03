using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Design;
using System.Text;
using System.Threading.Tasks;
using Fixus.Data.Entities;

namespace Fixus.Data.Repositories
{
    public interface IPostRepository
    {
        Post Get(int addedByUserId);
        Post Get(string title);

        void Add(string title, string description, int categoryId, int addedByUserId);
    }
}

