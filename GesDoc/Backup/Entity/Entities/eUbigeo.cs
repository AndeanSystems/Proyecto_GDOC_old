using System;
using System.Runtime.Serialization;

namespace Entity.Entities
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class eUbigeo
    {
        [DataMember] 
        public int? CodUbi { get; set;}

        [DataMember] 
        public String Descripcion { get; set;}

        [DataMember] 
        public String TipoCod { get; set;}

        [DataMember] 
        public int? Cod_Dpto { get; set;}

        [DataMember] 
        public int? Cod_Prov { get; set; }
    }
}
