using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

using Service.Message.Base;
using Entity.Entities;

namespace Service.Message.Resquest_Response
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class AutorizaRequest : RequestBase
    {
        [DataMember]
        public eAutorizador CtrAutoriza;
    }

    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class AutorizaResponse : ResponseBase
    {
        [DataMember]
        public Int64 AddAutoriza;
    }

    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class LUserAutoResponse : ResponseBase
    {
        [DataMember]
        public IList<eAutorizador> AutorizaList;
    }
}
