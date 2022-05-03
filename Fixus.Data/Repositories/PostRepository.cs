using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Fixus.Data.Entities;

namespace Fixus.Data.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly FixusContext _FixusContext;

        public PostRepository()
        {
            _FixusContext = null;
        }

        public PostRepository(FixusContext FixusContext)
        {
            _FixusContext = FixusContext;
        }

        public Post Get(int addedByUserId)
        {
            using (var context = _FixusContext ?? new FixusContext())
            {
                return context.Posts
                    .Where(c => c.AddedByUser.UserId == addedByUserId)
                    .FirstOrDefault();
            }
        }

        public Post Get(string title)
        {
            using (var context = _FixusContext ?? new FixusContext())
            {
                return context.Posts
                    .Where(c=>c.Title.ToUpper() == title.ToUpper())
                    .FirstOrDefault();
            }
        }

        public void Add(string title, string description, int categoryId, int addedByUserId)
        {
            using (var context = _FixusContext ?? new FixusContext())
            {
                var addedByUser = context.Users
                    .Where(c => c.UserId == addedByUserId)
                    .FirstOrDefault();

                var category = context.Categories
                    .Where(c => c.CategoryId == categoryId)
                    .FirstOrDefault();

                var post = new Post
                {
                    Title = title,
                    Description = description,
                    Category = category,
                    AddedByUser = addedByUser,
                    AssignedToUser = null,
                };
                context.Posts.Add(post);

                context.SaveChanges();
            }
        }
    }
}