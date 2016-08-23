using System;
using System.Runtime.Serialization;

namespace Entity.Entities
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class eTipoEvento
    {
        [DataMember] 
        public String EstTipoEvento{get;set;}

        [DataMember] 
        public String CodiEven { get; set; }

        [DataMember] 
        public String DescEven { get; set; }
    }
}
