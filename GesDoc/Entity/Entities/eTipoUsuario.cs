using System;
using System.Runtime.Serialization;

namespace Entity.Entities
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class eTipoUsuario
    {
        [DataMember] 
        public Int64 CodiTipUsu { get; set;}

        [DataMember] 
        public String DescTipUsu { get; set;}

        [DataMember] 
        public String AbreTipUsu { get; set;}

        [DataMember] 
        public String EstaTipUsu { get; set;}
    }
}
