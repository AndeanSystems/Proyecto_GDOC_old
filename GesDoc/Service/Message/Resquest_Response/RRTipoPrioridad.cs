using System.Collections.Generic;
using System.Runtime.Serialization;

using Service.Message.Base;
using Entity.Entities;

namespace Service.Message.Resquest_Response
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class TipoPrioridadRequest : RequestBase
    {
        [DataMember]
        public eTipoPrioridad CtrTipoPrioridad;
    }

    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class TipoPrioridadResponse : ResponseBase
    {
        [DataMember]
        public IList<eTipoPrioridad> ListaTipoPrioridad;
    }
}
