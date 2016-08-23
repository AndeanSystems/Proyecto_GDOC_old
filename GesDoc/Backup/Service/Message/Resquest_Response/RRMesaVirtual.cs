using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

using Service.Message.Base;
using Entity.Entities;

namespace Service.Message.Resquest_Response
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class MesaVirtualRequest : RequestBase
    {
        [DataMember]
        public eMesaVirtual CtrMesaVir;
    }

    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class MesaVirtualResponse : ResponseBase
    {
        [DataMember]
        public IList<eMesaVirtual> ListaMesaVirtual;
    }

    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class InsertMesaVResponse : ResponseBase
    {
        [DataMember]
        public Int64 addMesaVirtual;
    }
}
