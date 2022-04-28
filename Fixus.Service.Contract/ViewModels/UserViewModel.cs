using System.Runtime.Serialization;

namespace Fixus.Service.Contract.ViewModels
{
    [DataContract]
    public class UserViewModel
    {
        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public string Username { get; set; }

        public UserViewModel(int userId, string username)
        {
            UserId = userId;
            Username = username;
        }
    }
}