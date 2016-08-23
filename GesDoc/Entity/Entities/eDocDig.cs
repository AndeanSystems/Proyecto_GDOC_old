using System;
using System.Runtime.Serialization;

namespace Entity.Entities
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class eDocDig
    {
        [DataMember] 
        public Int64 CodiDocuDigi { get; set; }

        [DataMember] 
        public String Type { get; set; }

        [DataMember] 
        public String TituDocuDigi { get; set; }

        [DataMember] 
        public String AsunDocuDigi { get; set; }

        [DataMember] 
        public String NombOrig { get; set; }

        [DataMember] 
        public String RutaFisi { get; set; }

        [DataMember] 
        public Int64 TamaDocu { get; set; }

        [DataMember] 
        public String ExteDocu { get; set; }

        [DataMember] 
        public String NombFisi { get; set; }

        [DataMember] 
        public String ClasDocu { get; set; }

        [DataMember] 
        public String EstDocuDigi { get; set; }

        [DataMember] 
        public DateTime FechEmiDocu { get; set; }

        [DataMember] 
        public DateTime FechRece { get; set; }

        [DataMember] 
        public DateTime? FechRegi { get; set; }

        [DataMember] 
        public DateTime FechActu { get; set; }

        [DataMember] 
        public String AcceDocuDigi { get; set; }

        [DataMember] 
        public String CodiTipoDocu { get; set; }

        [DataMember] 
        public String NumDocuDigi { get; set; }

        [DataMember] 
        public eUsuario User { get; set; }

        [DataMember] 
        public Int64 CodUsu { get; set; }

        [DataMember] 
        public int Orden { get; set; }

        [DataMember]
        public string Comentario { get; set; }

        [DataMember]
        public string NomTipoDocu { get; set; }
    }
}
