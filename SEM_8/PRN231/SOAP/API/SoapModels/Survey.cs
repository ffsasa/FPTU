using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace API.SoapModels
{
    [DataContract]
    public class Survey
    {
        [Key]
        [DataMember]

        public int Id { get; set; }
        [DataMember]
        public int CategoryId { get; set; }
        [DataMember]
    
        public string Description { get; set; }
        [DataMember]

        public int Number { get; set; }
        [DataMember]

        public double PointAverage { get; set; }
        [DataMember]

        public int Verygood { get; set; }
        [DataMember]

        public int Good { get; set; }
        [DataMember]

        public int Medium { get; set; }
        [DataMember]

        public int Bad { get; set; }
        [DataMember]

        public int VeryBad { get; set; }
        [DataMember]

        public int CreateBy { get; set; }
        [DataMember]

        public DateTime CreateAt { get; set; }
        [DataMember]

        public DateTime UpdateAt { get; set; }
        [DataMember]

        public virtual ServeyCategory Category { get; set; }
    }
}
