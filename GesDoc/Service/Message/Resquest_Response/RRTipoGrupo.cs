using System.Collections.Generic;
using System.Runtime.Serialization;

using Service.Message.Base;
using Entity.Entities;

namespace Service.Message.Resquest_Response
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class TipoGrupoRequest : RequestBase
    {
        [DataMember]
        public eGrupo CtrTipoGrupo;
    }

    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class TipoGrupoResponse : ResponseBase
    {
        [DataMember]
        public IList<eGrupo> ListaTipoGrupo;
    }
}
