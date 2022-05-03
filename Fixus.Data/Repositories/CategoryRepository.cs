using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Fixus.Data.Entities;

namespace Fixus.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly FixusContext _FixusContext;

        public CategoryRepository()
        {
            _FixusContext = null;
        }

        public CategoryRepository(FixusContext FixusContext)
        {
            _FixusContext = FixusContext;
        }

        public Category Get(string name, int parentId)
        {
            using (var context = _FixusContext ?? new FixusContext())
            {
                return context.Categories
                    .Where(c => c.Name == name && c.ParentCategoryId == parentId)
                    .FirstOrDefault();
            }
        }

        public IEnumerable<Category> Get(int parentId)
        {
            using (var context = _FixusContext ?? new FixusContext())
            {
                return context.Categories
                    .Where(c=>c.ParentCategoryId == parentId)
                    .ToList();
            }
        }

        public void Add(string name, int parentId)
        {
            using (var context = _FixusContext ?? new FixusContext())
            {
                var category = new Category
                {
                    Name = name,
                    ParentCategoryId = parentId
                };

                context.Categories.Add(category);

                context.SaveChanges();
            }
        }
    }
}