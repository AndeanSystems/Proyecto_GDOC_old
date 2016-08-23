using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

using Service.Message.Base;
using Entity.Entities;

namespace Service.Message.Resquest_Response
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class TipoAccesoRequest : RequestBase
    {
        [DataMember]
        public eTipoAcceso CtrTipoAcceso;
    }

    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class TipoAccesoResponse : ResponseBase
    {
        [DataMember]
        public IList<eTipoAcceso> ListaTipoAcceso;
    }
}
