using System;
using System.Runtime.Serialization;

namespace Entity.Entities
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class eDocAdj
    {
        [DataMember] 
        public String Type {get;set;}

        [DataMember] 
        public Int64 CodiAdj { get; set; }

        [DataMember] 
        public Int64 CodiOper {get;set;}

        [DataMember] 
        public String CodiTipoDocu { get; set; }

        [DataMember] 
        public String TipoOper {get;set;}

        [DataMember] 
        public Int64 CodiDocAdju {get;set;}

        [DataMember] 
        public String TipoDocAdju {get;set;}

        [DataMember] 
        public Int64 CodiComenMesaV {get;set;}

        [DataMember] 
        public String EstDocuAdju { get; set;}
    }
}
