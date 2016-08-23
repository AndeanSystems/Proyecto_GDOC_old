using System.Collections.Generic;
using System.Runtime.Serialization;

using Service.Message.Base;
using Entity.Entities;

namespace Service.Message.Resquest_Response
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class TipoUsuarioRequest : RequestBase
    {
        [DataMember]
        public eTipoUsuario CtrTipoUsuario;
    }

    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class TipoUsuarioResponse : ResponseBase
    {
        [DataMember]
        public IList<eTipoUsuario> ListaTipoUsuario;
    }
}
