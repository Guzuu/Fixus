using System;
using System.Collections.Generic;
using System.Linq;
using Fixus.Data.Repositories;
using Fixus.Service.Contract;

namespace Fixus.Service
{
    public class FixusService : IFixusService
    {
        #region User
        public User GetUserByUsername(string username)
        {
            IUserRepository userRepository = new UserRepository();

            var user = userRepository.Get(username);

            return GetUser(user);
        }

        public User GetUserById(int id)
        {
            IUserRepository userRepository = new UserRepository();

            var user = userRepository.Get(id);

            return GetUser(user);
        }

        private User GetUser(Data.Entities.User user)
        {
            User result = null;

            if (user != null)
            {
                result = new User
                {
                    UserId = user.UserId,
                    Username = user.Username,
                    Password = user.Password
                };
            }

            return result;
        }

        public IEnumerable<User> GetAllUsers()
        {
            var result = new List<User>();
            IUserRepository userRepository = new UserRepository();

            foreach (var user in userRepository.Get())
            {
                result.Add(new User
                {
                    UserId = user.UserId,
                    Username = user.Username,
                    Password = user.Password
                });
            }

            return result;
        }

        public User AddUser(string username, string password)
        {
            IUserRepository userRepository = new UserRepository();

            userRepository.Add(username, password);

            var user = userRepository.Get(username);

            return GetUser(user);
        }
        #endregion

        #region Profile
        public Profile GetProfileByUsername(string username)
        {
            IProfileRepository profileRepository = new ProfileRepository();

            var profile = profileRepository.Get(username);

            return GetProfile(profile);
        }

        public Profile GetProfileByUserId(int userId)
        {
            IProfileRepository profileRepository = new ProfileRepository();

            var profile = profileRepository.Get(userId);

            return GetProfile(profile);
        }

        private Profile GetProfile(Data.Entities.Profile profile)
        {
            Profile result = null;

            if (profile != null)
            {
                result = new Profile
                {
                    ProfileId = profile.ProfileId,
                    Name = profile.Name,
                    Gender = profile.Gender,
                    Description = profile.Description,
                    IsRepairman = profile.IsRepairman,
                };
            }

            return result;
        }

        public Profile AddProfile(string name, string gender, string description, bool isRepairman, int userId)
        {
            IProfileRepository profileRepository = new ProfileRepository();

            profileRepository.Add(name, gender, description, isRepairman, userId);

            var profile = profileRepository.Get(userId);

            return GetProfile(profile);
        }

        public Profile EditProfile(string name, string gender, string description, bool isRepairman, int userId)
        {
            IProfileRepository profileRepository = new ProfileRepository();

            profileRepository.Edit(name, gender, description, isRepairman, userId);

            var profile = profileRepository.Get(userId);

            return GetProfile(profile);
        }
        #endregion

        #region Category

        public Category GetCategoryByNameAndParentId(string name, int parentId)
        {
            ICategoryRepository categoryRepository = new CategoryRepository();

            var category = categoryRepository.Get(name, parentId);

            return GetCategory(category);
        }

        private Category GetCategory(Data.Entities.Category category)
        {
            Category result = null;

            if (category != null)
            {
                result = new Category
                {
                    CategoryId = category.CategoryId,
                    Name = category.Name
                };
            }

            return result;
        }

        public IEnumerable<Category> GetAllParentCategories(int parentId)
        {
            var result = new List<Category>();
            ICategoryRepository categoryRepository = new CategoryRepository();

            foreach (var category in categoryRepository.Get(parentId))
            {
                result.Add(new Category
                {
                    CategoryId = category.CategoryId,
                    Name = category.Name
                });
            }

            return result;
        }

        public Category AddCategory(string name, int parentId)
        {
            ICategoryRepository categoryRepository = new CategoryRepository();

            categoryRepository.Add(name, parentId);

            var category = categoryRepository.Get(name, parentId);

            return GetCategory(category);
        }
        #endregion

        #region Post
        public Post GetPostByTitle(string title)
        {
            IPostRepository postRepository = new PostRepository();

            var post = postRepository.Get(title);

            return GetPost(post);
        }

        public IEnumerable<Post> GetAllCategoryPosts(int categoryId)
        {
            var result = new List<Post>();
            IPostRepository postRepository = new PostRepository();

            foreach (var post in postRepository.Get(categoryId))
            {
                result.Add(new Post
                {
                    PostId = post.PostId,
                    Title = post.Title,
                    Description = post.Description,
                    AddedByUserId = post.AddedByUser.UserId,
                    AssignedUserId = post.AssignedToUser.UserId
                });
            }

            return result;
        }

        private Post GetPost(Data.Entities.Post post)
        {
            Post result = null;

            if (post != null)
            {
                result = new Post
                {
                    PostId = post.PostId,
                    Title = post.Title,
                    Description = post.Description,
                    AddedByUserId = post.AddedByUser.UserId,
                    AssignedUserId = post.AssignedToUser.UserId
                };
            }

            return result;
        }

        public Post AddPost(string title, string description, int categoryId, int addedByUserId)
        {
            IPostRepository postRepository = new PostRepository();

            postRepository.Add(title, description, categoryId, addedByUserId);

            var post = postRepository.Get(title);

            return GetPost(post);
        }

        public Post EditPost(string title, string description, int categoryId, int assignedUserId)
        {
            IPostRepository postRepository = new PostRepository();

            postRepository.Edit(title, description, categoryId, assignedUserId);

            var post = postRepository.Get(title);

            return GetPost(post);
        }
        #endregion

    }

}
