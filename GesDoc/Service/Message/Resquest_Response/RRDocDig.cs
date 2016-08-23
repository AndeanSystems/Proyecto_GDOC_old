using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

using Service.Message.Base;
using Entity.Entities;

namespace Service.Message.Resquest_Response
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class DocDigRequest : RequestBase
    {
        [DataMember]
        public eDocDig CtrDocDig;

    }

    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class DocDigResponse : ResponseBase
    {
        [DataMember]
        public Int64 AddDocDig;

    }

    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class LDocDigResponse : ResponseBase
    {
        [DataMember]
        public IList<eDocDig> ListaDocDig;
    }
}
