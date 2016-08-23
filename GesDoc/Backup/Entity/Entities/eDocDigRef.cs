using System;
using System.Runtime.Serialization;

namespace Entity.Entities
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class eDocDigRef
    {
        [DataMember] 
        public String Type { get; set; }

        [DataMember] 
        public Int64 CodiInde { get; set; }

        [DataMember] 
        public String DescInde { get; set; }

        [DataMember] 
        public String EstaInde { get; set; }

        [DataMember] 
        public Int64 CodiOper { get; set; }

        [DataMember] 
        public String TipoOper { get; set; }
    }
}
