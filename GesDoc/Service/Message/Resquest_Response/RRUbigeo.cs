using System.Collections.Generic;
using System.Runtime.Serialization;

using Service.Message.Base;
using Entity.Entities;

namespace Service.Message.Resquest_Response
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class UbigeoRequest : RequestBase
    {
        [DataMember]
        public eUbigeo CtrUbigeo;
    }

    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class UbigeoResponse : ResponseBase
    {
        [DataMember]
        public IList<eUbigeo> ListaUbigeo;
    }
}
