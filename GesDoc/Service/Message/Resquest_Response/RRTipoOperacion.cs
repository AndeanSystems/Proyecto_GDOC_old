using System.Collections.Generic;
using System.Runtime.Serialization;

using Service.Message.Base;
using Entity.Entities;

namespace Service.Message.Resquest_Response
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class TipoOperacionRequest : RequestBase
    {
        [DataMember]
        public eTipoOperacion CtrTipoOper;
    }

    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class TipoOperacionResponse : ResponseBase
    {
        [DataMember]
        public IList<eTipoOperacion> ListOperacion;
    }
}
