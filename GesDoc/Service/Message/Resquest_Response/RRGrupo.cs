using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

using Service.Message.Base;
using Entity.Entities;

namespace Service.Message.Resquest_Response
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class GrupoRequest : RequestBase
    {
        [DataMember]
        public eGrupo CtrGrupo;
    }

    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class GrupoResponse : ResponseBase
    {
        [DataMember]
        public Int64 AddGrupo;
    }

    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class GrupoUsuarioResponse : ResponseBase
    {
        [DataMember]
        public Int64 GrupoUsuarioAdd;
    }
}
