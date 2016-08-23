using System;
using System.Runtime.Serialization;

namespace Entity.Entities
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class ePersonal
    {
        [DataMember] 
        public Int64 CodigoPersona { get; set; }

        [DataMember] 
        public String NombPers { get; set; }

        [DataMember] 
        public String ApePers { get; set; }

        [DataMember] 
        public String SexoPers { get; set; }

        [DataMember] 
        public String EmaiPers { get; set; }

        [DataMember] 
        public String EmaiTrab { get; set; }

        [DataMember] 
        public DateTime FechNac { get; set; }

        [DataMember] 
        public String TelePers { get; set; }

        [DataMember] 
        public String AnexPers { get; set; }

        [DataMember] 
        public String CeluPers { get; set; }

        [DataMember] 
        public String EstaPers { get; set; }

        [DataMember] 
        public Int64 CodiTipUsu { get; set; }

        [DataMember] 
        public Int64 CodiArea { get; set; }

        [DataMember] 
        public Int64 CodiCarg { get; set; }

        [DataMember] 
        public String ClasPers { get; set; }

        [DataMember] 
        public Int64 RucEmpr { get; set; }

        [DataMember] 
        public String DNI { get; set; }

        [DataMember] 
        public String DirePers { get; set; }
    }
}
