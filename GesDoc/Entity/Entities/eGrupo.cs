using System;
using System.Runtime.Serialization;

namespace Entity.Entities
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class eGrupo
    {
        [DataMember] 
        public Int64 CodiGrup { get; set; }

        [DataMember] 
        public String NombGrup { get; set; }

        [DataMember] 
        public String ComeGrup { get; set; }

        [DataMember] 
        public String EstGrup { get; set; }

        [DataMember] 
        public DateTime FechCrea { get; set;}

        [DataMember] 
        public String UsuCrea { get; set; }

        [DataMember] 
        public eUsuario UsuarioGrupo { get; set; }
    }
}
