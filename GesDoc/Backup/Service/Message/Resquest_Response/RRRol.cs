using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

using Service.Message.Base;
using Entity.Entities;

namespace Service.Message.Resquest_Response
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class RolRequest : RequestBase
    {
        [DataMember]
        public eRol CtrRol;
    }

    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class RolResponse : ResponseBase
    {
        [DataMember]
        public IList<eRol> ListaRol;
    }
}
