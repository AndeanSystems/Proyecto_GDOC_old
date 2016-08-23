using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

using Service.Message.Base;
using Entity.Entities;

namespace Service.Message.Resquest_Response
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class BDocDigRequest : RequestBase
    {
        [DataMember]
        public eBuscarDocumentos CtrDocDigTD;
    }

    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class BDocDigResponse : ResponseBase
    {
        [DataMember]
        public IList<eBuscarDocumentos> BListaDocDig;
    }
}
