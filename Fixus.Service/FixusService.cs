﻿using System;
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
    }

}
