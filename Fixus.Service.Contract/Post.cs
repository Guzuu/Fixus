using System.Runtime.Serialization;

namespace Fixus.Service.Contract
{
    [DataContract]
    public class Post
    {
        [DataMember]
        public int PostId { get; set; }
        
        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public int AddedByUserId { get; set; }

        [DataMember]
        public int AssignedUserId { get; set; }
    }
}