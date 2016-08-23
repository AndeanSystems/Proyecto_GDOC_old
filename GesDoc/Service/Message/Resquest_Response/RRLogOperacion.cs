using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

using Service.Message.Base;
using Entity.Entities;

namespace Service.Message.Resquest_Response
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class LogOperacionRequest : RequestBase
    {
        [DataMember]
        public eLogOperacion CtrLogOper;
    }

    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class LogOperacionResponse : ResponseBase
    {
        [DataMember]
        public Int64 AddLogOperacion;
    }
}
