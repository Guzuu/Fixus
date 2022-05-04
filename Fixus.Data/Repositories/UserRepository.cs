using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Fixus.Data.Entities;

namespace Fixus.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly FixusContext _FixusContext;

        public UserRepository()
        {
            _FixusContext = null;
        }

        public UserRepository(FixusContext FixusContext)
        {
            _FixusContext = FixusContext;
        }

        public User Get(int id)
        {
            using (var context = _FixusContext ?? new FixusContext())
            {
                return context.Users
                    .Where(c => c.UserId == id)
                    .FirstOrDefault();
            }
        }
        public User GetByPost(int postId)
        {
            using (var context = _FixusContext ?? new FixusContext())
            {
                return context.Posts
                    .Where(c => c.PostId == postId)
                    .FirstOrDefault().AddedByUser;
            }
        }

        public User Get(string username)
        {
            using (var context = _FixusContext ?? new FixusContext())
            {
                return context.Users
                    .Where(c=>c.Username.ToUpper() == username.ToUpper())
                    .FirstOrDefault();
            }
        }

        public IEnumerable<User> Get()
        {
            using (var context = _FixusContext ?? new FixusContext())
            {
                return context.Users.ToList();
            }
        }

        public void Add(string username, string password)
        {
            using (var context = _FixusContext ?? new FixusContext())
            {
                var user = new User
                {
                    Username = username,
                    Password = password
                };

                context.Users.Add(user);

                context.SaveChanges();
            }
        }
    }
}