using System;
using System.Runtime.Serialization;

namespace Entity.Entities
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class eTipoPrioridad
    {
        [DataMember] 
        public Int64 CodiTipoPrio { get; set; }

        [DataMember] 
        public String DescTipoPrio { get; set; }

        [DataMember] 
        public String AbreTipoPrio { get; set; }

        [DataMember] 
        public String EstaTipoPrio { get; set; }
    }
}
