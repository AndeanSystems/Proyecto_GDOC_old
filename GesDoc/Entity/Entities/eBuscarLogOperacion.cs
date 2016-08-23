using System;
using System.Runtime.Serialization;

namespace Entity.Entities
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class eBuscarLogOperacion 
    {
        [DataMember] 
        public Int64 TipoBusq { get; set; }

        [DataMember] 
        public Int64 CodiDocu { get; set; }

        [DataMember] 
        public String  NumDocu { get; set; }

        [DataMember] 
        public DateTime FechEven {get; set;}

        [DataMember] 
        public Int64 CodiUsu { get; set; }

        [DataMember] 
        public String CodiEven {get;set;}

        [DataMember] 
        public String DescEven { get; set; }

        [DataMember] 
        public String AbreEven { get; set; }

        [DataMember] 
        public String EstEven { get; set; }

        [DataMember] 
        public String IdeUsu { get; set; }

        [DataMember] 
        public Int64 CodiDocAdju { get; set; }
    }
}
