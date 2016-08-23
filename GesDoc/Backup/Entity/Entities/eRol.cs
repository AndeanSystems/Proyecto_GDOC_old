using System;
using System.Runtime.Serialization;

namespace Entity.Entities
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class eRol
    {
        [DataMember] 
        public String EstTipoRol { get; set; }

        [DataMember] 
        public String CodiRol { get; set; }

        [DataMember] 
        public String DescRol { get; set; }
    }
}
