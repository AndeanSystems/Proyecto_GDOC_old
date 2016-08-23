using System.Collections.Generic;
using System.Runtime.Serialization;

using Service.Message.Base;
using Entity.Entities;

namespace Service.Message.Resquest_Response
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class UsuarioGrupoRequest : RequestBase
    {
        [DataMember]
        public eUsuarioGrupo CtrUsuarioGrupo;
    }

    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class UsuarioGrupoResponse : ResponseBase
    {
        [DataMember]
        public IList<eUsuarioGrupo> UsuarioGrupoLista;
    }
}
