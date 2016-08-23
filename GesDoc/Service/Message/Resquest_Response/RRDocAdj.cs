using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

using Service.Message.Base;
using Entity.Entities;

namespace Service.Message.Resquest_Response
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class DocAdjRequest : RequestBase
    {
        [DataMember]
        public eDocAdj CtrDocAdj;
    }

    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class DocAdjResponse : ResponseBase
    {
        [DataMember]
        public Int64 AddDocAdj;
    }

    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class LDocAdjResponse : ResponseBase
    {
        [DataMember]
        public IList<eDocAdj> ListAdj;
    }
}
