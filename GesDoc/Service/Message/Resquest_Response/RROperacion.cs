using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

using Service.Message.Base;
using Entity.Entities;

namespace Service.Message.Resquest_Response
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class OperacionRequest : RequestBase
    {
        [DataMember]
        public eOperaciones CtrOper;
    }
    
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class OperacionResponse : ResponseBase
    {
        [DataMember]
        public IList<eOperaciones> OperacionLista;
    }
}
