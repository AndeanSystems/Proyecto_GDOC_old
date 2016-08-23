using System;
using System.Runtime.Serialization;

namespace Entity.Entities
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class eTipoAcceso
    {
        [DataMember] 
        public String TipoAcc { get; set; }

        [DataMember] 
        public String DescAcc { get; set; }

        [DataMember] 
        public String EstAcc { get; set; }
    }
}
