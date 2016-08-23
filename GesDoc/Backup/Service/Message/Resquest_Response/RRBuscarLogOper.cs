using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

using Service.Message.Base;
using Entity.Entities;

namespace Service.Message.Resquest_Response
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class BuscarLogOperRequest : RequestBase
    {
        [DataMember]
        public eBuscarLogOperacion CtrBLogOper;
    }

    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class BuscarLogOperResponse : ResponseBase
    {
        [DataMember]
        public IList<eBuscarLogOperacion> BListaLogOper;
    }
}
