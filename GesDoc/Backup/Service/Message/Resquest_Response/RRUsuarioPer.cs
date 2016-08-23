using System.Collections.Generic;
using System.Runtime.Serialization;

using Service.Message.Base;
using Entity.Entities;
using System;

namespace Service.Message.Resquest_Response
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class UsuarioPerRequest : RequestBase
    {
        [DataMember]
        public eUsuario CtrUsuarioPer;
    }

    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class UsuarioPerResponse : ResponseBase
    {
        [DataMember]
        public IList<eUsuario> ListaUsuarioPer;
    }

    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class UsuarioResponse : ResponseBase
    {
        [DataMember]
        public Int64 AddUser;
    }
}
