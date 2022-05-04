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
        Post Get(string title);
        IEnumerable<Post> Get(int categoryId);
        void Add(string title, string description, int categoryId, int addedByUserId);
        void Edit(string title, string description, int categoryId, int assignedUserId);
    }
}

