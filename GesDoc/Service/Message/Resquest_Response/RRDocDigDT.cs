using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

using Service.Message.Base;
using Entity.Entities;

namespace Service.Message.Resquest_Response
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class DocDigDTRequest : RequestBase
    {
        [DataMember]
        public eDocDigListTD CtrDocDigTD;
    }

    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class DocDigDTResponse : ResponseBase
    {
        [DataMember]
        public IList<eDocDigListTD> ListaDogDig;
    }
}
