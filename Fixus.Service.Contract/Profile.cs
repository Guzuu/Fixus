using System.Runtime.Serialization;

namespace Fixus.Service.Contract
{
    [DataContract]
    public class Profile
    {
        [DataMember]
        public int ProfileId { get; set; }
        
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Gender { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public bool IsRepairman { get; set; }
    }
}