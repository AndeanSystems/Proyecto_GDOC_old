using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

using Service.Message.Base;
using Entity.Entities;

namespace Service.Message.Resquest_Response
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class MensajeAlertaRequest : RequestBase
    {
        [DataMember]
        public eMensajeAlerta CtrMenAlert;
    }

    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class MensajeAlertaResponse : ResponseBase
    {
        [DataMember]
        public Int64 AddMensajeAlerta;
    }

    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class LMensajeAlertaResponse : ResponseBase
    {
        [DataMember]
        public IList<eMensajeAlerta> ListaAlerta;
    }
}
