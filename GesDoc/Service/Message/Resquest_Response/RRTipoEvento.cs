using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

using Service.Message.Base;
using Entity.Entities;

namespace Service.Message.Resquest_Response
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class TipoEventoRequest : RequestBase
    {
        [DataMember]
        public eTipoEvento CtrTipoEvento;
    }

    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class TipoEventoResponse : ResponseBase
    {
        [DataMember]
        public IList<eTipoEvento> ListaEvento;
    }
}
