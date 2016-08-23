using System;
using System.Runtime.Serialization;

namespace Entity.Entities
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class eDocumentoElectronico
    {
        [DataMember] 
        public Int64 CodiOper { get; set; }

        [DataMember] 
        public Int64 CodiDocuElec { get; set; }

        [DataMember] 
        public String Type { get; set; }

        [DataMember] 
        public String TipoComu { get; set; }

        [DataMember] 
        public String AsunDocuElec { get; set; }

        [DataMember] 
        public DateTime? FechEmi { get; set; }

        [DataMember] 
        public DateTime FechEnvi { get; set; }

        [DataMember] 
        public String PrioDocuElec { get; set; }

        [DataMember] 
        public String MensDocuElec { get; set; }

        [DataMember] 
        public DateTime FechVige { get; set; }

        [DataMember] 
        public String EstDocuElec { get; set; }

        [DataMember] 
        public String CateDocuElec { get; set; }

        [DataMember] 
        public DateTime FechCie { get; set; }

        [DataMember] 
        public String TipoAcc { get; set; }

        [DataMember] 
        public String CodiTipoDocu { get; set; }

        [DataMember] 
        public String NumDocuElec { get; set; }

        [DataMember] 
        public eUsuario User { get; set; }

        [DataMember] 
        public Int64 CodUsu { get; set; }

        [DataMember]
        public String Memo { get; set; }

        [DataMember]
        public String Reenvio { get; set; }

        [DataMember] 
        public eParticipante Participante { get; set; }
    }
}
