using System;
using System.Runtime.Serialization;

namespace Entity.Entities
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class eTipoParticipacion
    {
        [DataMember] 
        public int CodiTipoPart { get; set; }

        [DataMember] 
        public String TipoParticip { get; set; }

        [DataMember] 
        public String DescParticip { get; set; }

        [DataMember] 
        public String EstTipoParticipacion { get; set; }
    }
}
