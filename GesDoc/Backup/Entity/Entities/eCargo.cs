using System;
using System.Runtime.Serialization;

namespace Entity.Entities
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class eCargo 
    {
        [DataMember] 
        public Int64 Codigo { get; set; }
        
        [DataMember] 
        public String Descripcion { get; set; }

        [DataMember] 
        public String Abrevitura { get; set; }

        [DataMember] 
        public Int16 Estado { get; set; }
    }
}
