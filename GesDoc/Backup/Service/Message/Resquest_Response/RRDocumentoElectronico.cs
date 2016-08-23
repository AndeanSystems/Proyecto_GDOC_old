using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

using Service.Message.Base;
using Entity.Entities;

namespace Service.Message.Resquest_Response
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class DocumentoElectronicoRequest : RequestBase
    {
        [DataMember]
        public eDocumentoElectronico CtrDocumentoElectronico;
    }

    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class DocumentoElectronicoResponse : ResponseBase
    {
        [DataMember]
        public Int64 EnviarDocumentoElectronico;
    }

    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class LDocElecResponse : ResponseBase
    {
        [DataMember]
        public IList<eDocumentoElectronico> ListaDocElecttonico;
    }
}
