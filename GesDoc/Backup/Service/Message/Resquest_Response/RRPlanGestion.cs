using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

using Service.Message.Base;
using Entity.Entities;

namespace Service.Message.Resquest_Response
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class PlanGestionRequest : RequestBase
    {
        [DataMember]
        public ePlanGestion CtrPlanGestion;
    }

    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class PlanGestionResponse : ResponseBase
    {
        [DataMember]
        public Int64 AddObetivoEstrategico;

        [DataMember]
        public Int64 AddObetivoOperativo;

        [DataMember]
        public Int64 AddProyecto;

        [DataMember]
        public Int64 AddActividad;

        [DataMember]
        public Int64 AddComentarioAvance;

        [DataMember]
        public IList<ePlanGestion> ListaObetivoEstrategico;

        [DataMember]
        public IList<ePlanGestion> ListaObetivoOperativo;

        [DataMember]
        public IList<ePlanGestion> ListaProyecto;

        [DataMember]
        public IList<ePlanGestion> ListaActividad;

        [DataMember]
        public IList<ePlanGestion> ListaComentarioAvance;

        [DataMember]
        public IList<ePlanGestion> ListaInforme;
    }
}
