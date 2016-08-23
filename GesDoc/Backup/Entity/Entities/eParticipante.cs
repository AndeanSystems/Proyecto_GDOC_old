using System;
using System.Runtime.Serialization;

namespace Entity.Entities
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class eParticipante
    {
        [DataMember]
        public Int64 CodiUsuPart { get; set; }
        [DataMember]
	    public String  TipoOper { get; set; }
        [DataMember]
        public Int64  CodiOper { get; set; }
        [DataMember]
	    public int TipoPart { get; set; }
        [DataMember]
	    public String ApruOper { get; set; }
        [DataMember]
	    public String EnviNoti { get; set; }
        [DataMember]
	    public DateTime FechNoti { get; set; }
        [DataMember]
        public String EstaUsuaPart { get; set; }
        [DataMember]
        public Int64 CodiUsu { get; set; }
        [DataMember]
        public String Reenvio { get; set; }
        [DataMember]
        public String Envio { get; set; }
        [DataMember]
        public String ConfLect { get; set; }
    }
}
