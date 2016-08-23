using System;
using System.Runtime.Serialization;

namespace Entity.Entities
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class eOperaciones
    {
        [DataMember] 
        public Int64 Type { get; set; }

        [DataMember] 
        public String AsunOper { get; set; }

        [DataMember] 
        public Int64 CodiOper { get; set; }

        [DataMember] 
        public String Asunto { get; set; }

        [DataMember] 
        public String TipoOper { get; set; }

        [DataMember] 
        public String AcceOper { get; set; }

        [DataMember] 
        public String NumOper { get; set; }

        [DataMember] 
        public DateTime Fecha { get; set; }
        
        [DataMember] 
        public Int64 CodUsu { get; set; }

        [DataMember] 
        public String IdeUsu { get; set; }

        [DataMember] 
        public int TipoPart { get; set; }

        [DataMember] 
        public String PrioDoc { get; set; }

        [DataMember] 
        public String Periodo { get; set; }

        [DataMember] 
        public String TipoComu { get; set; }
    }
}
