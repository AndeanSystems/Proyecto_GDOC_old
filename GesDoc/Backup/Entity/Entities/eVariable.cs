using System;
using System.Runtime.Serialization;

namespace Entity.Entities
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class eVariable
    {
        [DataMember] 
        public String Descrip { get; set; }

        [DataMember] 
        public Int64 Codigo { get; set; }

        [DataMember] 
        public Int64 CodUsu { get; set; }

        [DataMember] 
        public String Numdoc { get; set; }
    }
}
