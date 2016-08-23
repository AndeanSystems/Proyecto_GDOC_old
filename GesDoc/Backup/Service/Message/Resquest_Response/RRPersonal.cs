using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

using Service.Message.Base;
using Entity.Entities;

namespace Service.Message.Resquest_Response
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class PersonalRequest : RequestBase
    {
        [DataMember]
        public ePersonal CtrPersonal;
    }

    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class PersonalResponse : ResponseBase
    {
        [DataMember]
        public Int64 AddPersonal;
    }
}
