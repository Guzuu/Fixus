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

        public Post Get(string title)
        {
            using (var context = _FixusContext ?? new FixusContext())
            {
                return context.Posts
                    .Where(c=>c.Title.ToUpper() == title.ToUpper())
                    .Include("AddedByUser")
                    .Include("AssignedToUser")
                    .FirstOrDefault();
            }
        }

        public IEnumerable<Post> Get(int categoryId)
        {
            using (var context = _FixusContext ?? new FixusContext())
            {
                return context.Posts
                    .Where(c => c.Category.CategoryId == categoryId)
                    .Include("AddedByUser")
                    .Include("AssignedToUser")
                    .ToList();
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

        public void Edit(string title, string description, int categoryId, int assignedUserId)
        {
            using (var context = _FixusContext ?? new FixusContext())
            {
                var assignedUser = context.Users
                    .Where(c => c.UserId == assignedUserId)
                    .FirstOrDefault();

                var category = context.Categories
                    .Where(c => c.CategoryId == categoryId)
                    .FirstOrDefault();

                var post = context.Posts.Where(c => c.Title == title).FirstOrDefault();

                if (title != null)
                {
                    post.Title = title;
                    post.Description = description;
                    post.Category = category;
                    post.AssignedToUser = assignedUser;
                }

                context.SaveChanges();
            }
        }
    }
}