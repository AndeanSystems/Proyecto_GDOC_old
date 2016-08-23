using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

using Service.Message.Base;
using Entity.Entities;

namespace Service.Message.Resquest_Response
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class TipoAreaRequest : RequestBase
    {
        [DataMember]
        public eArea CtrTipoArea;
    }

    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class TipoAreaResponse : ResponseBase
    {
        [DataMember]
        public IList<eArea> ListaTipoArea;
    }
}
