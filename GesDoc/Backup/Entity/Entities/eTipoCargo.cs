using System;
using System.Runtime.Serialization;

namespace Entity.Entities
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class eTipoCargo
    {
        [DataMember] 
        public String EstCargo { get; set; }

        [DataMember] 
        public Int64 CodiCarg { get; set; }

        [DataMember] 
        public String DescCarg { get; set; }
    }
}
