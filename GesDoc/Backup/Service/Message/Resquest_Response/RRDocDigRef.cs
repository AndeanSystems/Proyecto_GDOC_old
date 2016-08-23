using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

using Service.Message.Base;
using Entity.Entities;

namespace Service.Message.Resquest_Response
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class DocDigRefRequest : RequestBase
    {
        [DataMember]
        public eDocDigRef CtrDocDigRef;
    }

    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class DocDigRefResponse : ResponseBase
    {
        [DataMember]
        public Int64 AddDocDigRef;
    }

    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class LDocDigRefResponse : ResponseBase
    {
        [DataMember]
        public IList<eDocDigRef> ListaRefDigital;
    }


}
