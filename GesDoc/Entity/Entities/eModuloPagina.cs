using System;
using System.Runtime.Serialization;

namespace Entity.Entities
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class eModuloPagina
    {
        [DataMember] 
        public Int64 Codigo { get; set; }

        [DataMember] 
        public Int64 CodigoPadre { get; set; }

        [DataMember] 
        public String Nombre { get; set; }

        [DataMember] 
        public String Comentario { get; set; }

        [DataMember] 
        public String DireccionURL { get; set; }

        [DataMember] 
        public String Estado { get; set; }

        [DataMember] 
        public String Modulo { get; set; }
    }
}
