using System;
using System.Runtime.Serialization;

namespace Entity.Entities
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class eUsuario
    {
        [DataMember] 
        public Int64 Codigo { get; set; }

        [DataMember] 
        public Int64 CodigoPersona { get; set; }

        [DataMember] 
        public String IdeUsuario { get; set; }

        [DataMember] 
        public String Pasword { get; set; }

        [DataMember] 
        public String FirmaElectronica { get; set; }

        [DataMember] 
        public String Estado { get; set; }

        [DataMember] 
        public DateTime FechaRegistro { get; set; }

        [DataMember] 
        public DateTime FechaUltimoAcceso { get; set; }

        [DataMember] 
        public DateTime FechaModificacion { get; set; }

        [DataMember] 
        public Int16 IntentoErradosPasword { get; set; }

        [DataMember] 
        public Int16 IntentoErradoFirma { get; set; }

        [DataMember] 
        public Int16 IntentoErradoPasword { get; set; }

        [DataMember] 
        public String TermUsu { get; set; }

        [DataMember] 
        public String UsuCrea { get; set; }

        [DataMember] 
        public String CodiCnx { get; set; }

        [DataMember] 
        public String CodiRol { get; set; }

        [DataMember] 
        public Int64 CodiTipUsu { get; set; }

        [DataMember] 
        public String ClasUsu { get; set; }

        [DataMember] 
        public String ExpiClav { get; set; }

        [DataMember] 
        public String ExpiFirm { get; set; }

        [DataMember] 
        public DateTime FechExpiClav { get; set; }

        [DataMember] 
        public DateTime FechExpiFirm { get; set; }

        [DataMember] 
        public String DescArea { get; set; }

        [DataMember] 
        public String DescCarg { get; set; }

        [DataMember] 
        public String NombPers { get; set; }

        [DataMember] 
        public String ApePers { get; set; }

        [DataMember] 
        public ePersonal Pers { get; set; }

        [DataMember] 
        public eParticipante Participante { get; set; }
    }
}
