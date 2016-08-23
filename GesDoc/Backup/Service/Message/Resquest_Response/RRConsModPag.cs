using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

using Service.Message.Base;
using Entity.Entities;

namespace Service.Message.Resquest_Response
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class ConsModPagRequest : RequestBase
    {
        [DataMember]
        public eModuloPagina CtrModPag;
    }

    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class ConsModPagResponse : ResponseBase
    {
        [DataMember]
        public IList<eModuloPagina> ListaModPag;
    }
}
