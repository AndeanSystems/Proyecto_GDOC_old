using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

using Service.Message.Base;
using Entity.Entities;

namespace Service.Message.Resquest_Response
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class ListaDescRequest : RequestBase
    {
        [DataMember]
        public eVariable CtrDesList;
    }

    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class ListaDescResponse : ResponseBase
    {
        [DataMember]
        public IList<eVariable> ListDesc;
    }
}
