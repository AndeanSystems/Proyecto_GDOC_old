using System;
using System.Runtime.Serialization;

namespace Entity.Entities
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class eEmpresa
    {
        [DataMember] 
        public String Type {get; set;}

        [DataMember] 
	    public Int64 RucEmpr	{get; set;}

        [DataMember] 
        public String RazoSoci {get; set;}

        [DataMember] 
	    public String DireEmpr {get; set;}

        [DataMember] 
        public String EmprId { get; set; }

        [DataMember] 
	    public String CodiUbig {get; set;}

        [DataMember] 
	    public DateTime FechRegi {get; set;}

        [DataMember] 
        public Int64 CodiUsu { get; set; }

        [DataMember] 
        public String EstEmpr { get; set; }
    }
}
