using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

using Service.Message.Base;
using Entity.Entities;


namespace Service.Message.Resquest_Response
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class BuscarDocumentoRequest : RequestBase
    {
        [DataMember]
        public eBuscarDocumentos CtrDocDigTD;
    }

    public class BuscarDocumentoResponse : ResponseBase
    {
        [DataMember]
        public IList<eBuscarDocumentos> BListaDocDig;

        [DataMember]
        public IList<eBuscarDocumentos> BListaDocElect;

        [DataMember]
        public IList<eBuscarDocumentos> BListaMesaVirtual;

        [DataMember]
        public IList<eBuscarDocumentos> BListaDocumentoAdjunto;

    }
}
