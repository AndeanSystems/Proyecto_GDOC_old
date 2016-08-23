using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

using Service.Message.Base;
using Entity.Entities;

namespace Service.Message.Resquest_Response
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class TipoCargoRequest : RequestBase
    {
        [DataMember]
        public eTipoCargo CtrTipoCargo;
    }

    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class TipoCargoResponse : ResponseBase
    {
        [DataMember]
        public IList<eTipoCargo> ListaTipoCargo;
    }
}
