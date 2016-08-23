using System;
using System.Runtime.Serialization;

namespace Entity.Entities
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class eBuscarDocumentos
    {
        [DataMember] 
        public int TipoBusq { get; set; }

        [DataMember] 
        public Int64 CodiUsuRem { get; set; }

        [DataMember] 
        public Int64 CodiUsuDes { get; set; }

        [DataMember] 
        public DateTime? FecReg2 { get; set; }

        [DataMember] 
        public eDocDig sDocDig { get; set; }

        [DataMember] 
        public eDocumentoElectronico sDocElect { get; set; }

        [DataMember] 
        public eMesaVirtual sMesaVirtual { get; set; }

        [DataMember] 
        public int Orden { get; set; }

        [DataMember] 
        public eDocDigListTD sTipoDocumento { get; set; }        
    }
}
