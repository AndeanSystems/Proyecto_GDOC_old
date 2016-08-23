using System;
using System.Runtime.Serialization;

namespace Entity.Entities
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class eMesaVirtual
    {
        [DataMember] 
        public int Type { get; set; }

        [DataMember] 
        public Int64 CodiOper { get; set; }

        [DataMember] 
        public String Asunto { get; set; }

        [DataMember] 
        public String Titulo { get; set; }

        [DataMember] 
        public String Acceso { get; set; }

        [DataMember] 
        public String NumOper { get; set; }

        [DataMember] 
        public DateTime? Fecha { get; set; }

        [DataMember] 
        public DateTime FechaFin { get; set; }

        [DataMember] 
        public String Estado { get; set; }

        [DataMember] 
        public Int64 CodiUsu { get; set; }

        [DataMember] 
        public String Usuario { get; set; }

        [DataMember] 
        public int TipoPart { get; set; }

        [DataMember] 
        public String Periodo { get; set; }

        [DataMember] 
        public int ClaseMV { get; set; }

        [DataMember] 
        public String DesMesaVir { get; set; }

        [DataMember] 
        public String Prioridad { get; set; }

        [DataMember] 
        public String Notifica { get; set; }

        [DataMember] 
        public Int64 CodiMesaComent { get; set; }

        [DataMember]
        public String ConfLect { get; set; }
    }
}
