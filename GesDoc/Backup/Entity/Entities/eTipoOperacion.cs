using System;
using System.Runtime.Serialization;

namespace Entity.Entities
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class eTipoOperacion
    {
        [DataMember] 
        public String EstTipoOperacion { get; set; }

        [DataMember] 
        public String CodiTipoOper { get; set; }

        [DataMember] 
        public String DescTipoOper { get; set; }
    }
}
