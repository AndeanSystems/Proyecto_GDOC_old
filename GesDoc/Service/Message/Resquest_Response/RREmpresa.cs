using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

using Service.Message.Base;
using Entity.Entities;

namespace Service.Message.Resquest_Response
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class EmpresaRequest : RequestBase
    {
        [DataMember]
        public eEmpresa CtrEmpresa;
    }

    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class EmpresaResponse : ResponseBase
    {
        [DataMember]
        public Int64 AddEmpresa;
    }

    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class LEmpresaResponse : ResponseBase
    {
        [DataMember]
        public IList<eEmpresa> EmpresaLista;
    }
}
