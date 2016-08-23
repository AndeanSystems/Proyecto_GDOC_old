using System;
using System.Runtime.Serialization;

namespace Entity.Entities
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class eUsuarioGrupo
    {
        [DataMember] 
        public Int64 CodiUsuGrup { get; set; }

        [DataMember] 
        public eUsuario Usuario { get; set; }

        [DataMember] 
        public eGrupo Grupo { get; set; }

        [DataMember] 
        public String UsuCrea { get; set; }

        [DataMember] 
        public DateTime FechCrea { get; set; }

        [DataMember] 
        public String EstUsuGrup { get; set; }
    }
}
