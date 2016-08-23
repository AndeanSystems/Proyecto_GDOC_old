using System;
using System.Runtime.Serialization;

namespace Entity.Entities
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class eLogOperacion
    {
        [DataMember] 
        public String Type { get; set; }

        [DataMember] 
        public Int64 CodiLogOper {get;set;}

        [DataMember] 
        public DateTime FechEven {get; set;}

        [DataMember] 
        public String  TipoOper {get; set;}

        [DataMember] 
        public String  CodiOper {get;set;}

        [DataMember] 
        public String CodiEven {get;set;}

        [DataMember] 
        public Int64 CodiUsu {get;set;}

        [DataMember] 
        public Int64 CodiCnx { get; set;}
    }
}
