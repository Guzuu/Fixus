using System.Collections.Generic;
using System.ServiceModel;

namespace Fixus.Service.Contract
{
    [ServiceContract]
    public interface IFixusService
    {
        #region User
        [OperationContract]
        User GetUserByUsername(string username);

        [OperationContract]
        User GetUserById(int id);

        [OperationContract]
        IEnumerable<User> GetAllUsers();

        [OperationContract]
        User AddUser(string username, string password);
        #endregion

        #region Profile
        [OperationContract]
        Profile GetProfileByUsername(string username);

        [OperationContract]
        Profile GetProfileByUserId(int userId);

        [OperationContract]
        Profile AddProfile(string name, string gender, string description, bool isRepairman, int userId);

        [OperationContract]
        Profile EditProfile(string name, string gender, string description, bool isRepairman, int userId);
        #endregion

        #region Category
        [OperationContract]
        Category GetCategoryByNameAndParentId(string name, int parentId);

        [OperationContract]
        IEnumerable<Category> GetAllParentCategories(int parentId);

        [OperationContract]
        Category AddCategory(string name, int parentId);
        #endregion
    }
}
