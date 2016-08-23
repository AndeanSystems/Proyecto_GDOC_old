using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

using Service.Message.Base;
using Entity.Entities;

namespace Service.Message.Resquest_Response
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class AccesoRequest : RequestBase
    {
        [DataMember]
        public eAccesoSistema CtrAcceso;
    }

    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class AccesoResponse : ResponseBase
    {
        [DataMember]
        public Int64 AddAcceso;
    }

    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class LAccesoResponse : ResponseBase
    {
        [DataMember]
        public IList<eAccesoSistema> ListaAcceso;
    }
}
