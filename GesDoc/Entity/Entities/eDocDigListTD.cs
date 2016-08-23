using System;
using System.Runtime.Serialization;

namespace Entity.Entities
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class eDocDigListTD
    {
        [DataMember] 
        public String CodiTipoDocu { get; set; }

        [DataMember] 
        public String NombTipoDocu { get; set; }

        [DataMember] 
        public String EstTipoDocumento { get; set; }
    }
}
