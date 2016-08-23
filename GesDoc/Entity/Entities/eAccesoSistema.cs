using System;
using System.Runtime.Serialization;

namespace Entity.Entities
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class eAccesoSistema 
    {
        [DataMember] 
        public Int64 Codigo { get; set; }

        [DataMember] 
        public eModuloPagina Pagina { get; set; }

        [DataMember] 
        public eUsuario Usuario { get; set; }

        [DataMember] 
        public String Estado { get; set; }

        [DataMember] 
        public eUsuario UsuarioCreacion { get; set; }
        
        [DataMember] 
        public DateTime FechaModificacion { get; set; }

    }
}
