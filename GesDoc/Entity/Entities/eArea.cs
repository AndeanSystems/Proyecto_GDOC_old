using System;
using System.Runtime.Serialization;

namespace Entity.Entities
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class eArea
    {
        [DataMember] 
        public String EstaAre { get; set; }

        [DataMember] 
        public Int64 CodiAre { get; set; }

        [DataMember] 
        public String DescAre { get; set; }

        [DataMember] 
        public String AbreAre { get; set; }
    }
}
