using System.Collections.Generic;
using System.Runtime.Serialization;

using Service.Message.Base;
using Entity.Entities;
using System;

namespace Service.Message.Resquest_Response
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class UsuParticipRequest : RequestBase
    {
        [DataMember]
        public eParticipante CtrUsuPart;
        [DataMember]
        public List<long> ListCodiOper;
        [DataMember]
        public List<long> ListCodiUsu;
    }

    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class UsuParticipResponse : ResponseBase
    {
        [DataMember]
        public Int64 AddUsuPartip;
        [DataMember]
        public Int64 UpdateUsuPartip;
    }
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class LUserParticResponse : ResponseBase
    {
        [DataMember]
        public IList<eParticipante> ListaUsuPart;
    }
}
