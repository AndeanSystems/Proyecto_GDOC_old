using System.Collections.Generic;
using System.Runtime.Serialization;

using Service.Message.Base;
using Entity.Entities;

namespace Service.Message.Resquest_Response
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class TipoParticipRequest : RequestBase
    {
        [DataMember]
        public eTipoParticipacion CtrTipoPartic;

    }

    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class TipoParticipResponse : ResponseBase
    {
        [DataMember]
        public IList<eTipoParticipacion> ListaParticip;
    }
}
