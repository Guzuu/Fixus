using System.Collections.Generic;
using System.ServiceModel;

namespace Fixus.Service.Contract
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        User GetUserByUsername(string username);

        [OperationContract]
        User GetUserById(int id);

        [OperationContract]
        IEnumerable<User> GetAllUsers();

        [OperationContract]
        User AddUser(string username, string password);
    }
}
