using System.Runtime.Serialization;

namespace Fixus.Service.Contract
{
    [DataContract]
    public class Category
    {
        [DataMember]
        public int CategoryId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string ParentCategoryId { get; set; }
    }
}