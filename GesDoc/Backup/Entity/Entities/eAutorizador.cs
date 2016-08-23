using System;
using System.Runtime.Serialization;

namespace Entity.Entities
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class eAutorizador 
    {
        [DataMember] 
        public String Type {get;set;}

        [DataMember] 
        public Int64 CodiUsuPart {get;set;}

        [DataMember] 
        public Int64 CodiOper { get; set; }

        [DataMember] 
        public String TipoOper{get;set;}

        [DataMember] 
        public String RespUsuAuto{get;set;}

        [DataMember] 
        public DateTime FechUsuAuto{get;set;}

        [DataMember] 
        public String ComeUsuAuto{get;set;}

        [DataMember] 
        public String EstaAuto { get; set; }

        [DataMember] 
        public eUsuario User { get; set; }
    }
}
