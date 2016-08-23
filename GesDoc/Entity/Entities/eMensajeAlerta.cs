using System;
using System.Runtime.Serialization;

namespace Entity.Entities
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class eMensajeAlerta 
    {
        [DataMember] 
        public String Type { get; set; }

        [DataMember] 
        public Int64 CodiMensAler { get; set; }

        [DataMember] 
        public Int64 CodiOper {get; set;}

        [DataMember] 
	    public String TipoOper{get;set;}

        [DataMember] 
        public DateTime FechAler {get;set;}

        [DataMember] 
        public String TipoAler {get;set;}

        [DataMember] 
        public String CodiEven {get; set;}

        [DataMember] 
        public String EstMensAler {get;set;}

        [DataMember] 
        public Int64 CodiUsu {get;set;}

        [DataMember] 
        public DateTime FechAler2 { get; set; }

        [DataMember] 
        public String DescEven { get; set; }
    }
}
