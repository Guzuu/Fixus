using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Fixus.Data.Entities;

namespace Fixus.Data.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly FixusContext _FixusContext;

        public ProfileRepository()
        {
            _FixusContext = null;
        }

        public ProfileRepository(FixusContext FixusContext)
        {
            _FixusContext = FixusContext;
        }

        public Profile Get(int userId)
        {
            using (var context = _FixusContext ?? new FixusContext())
            {
                return context.Profiles
                    .Where(c => c.User.UserId == userId)
                    .FirstOrDefault();
            }
        }

        public Profile Get(string username)
        {
            using (var context = _FixusContext ?? new FixusContext())
            {
                return context.Profiles
                    .Where(c=>c.User.Username.ToUpper() == username.ToUpper())
                    .FirstOrDefault();
            }
        }

        public void Add(string name, string gender, string description, bool isRepairman, int userId)
        {
            using (var context = _FixusContext ?? new FixusContext())
            {
                var user = context.Users
                    .Where(c => c.UserId == userId)
                    .FirstOrDefault();
                var profile = new Profile
                {
                    Name = name,
                    Gender = gender,
                    Description = description,
                    IsRepairman = isRepairman,
                    User = user,
                };
                context.Profiles.Add(profile);

                context.SaveChanges();
            }
        }
    }
}