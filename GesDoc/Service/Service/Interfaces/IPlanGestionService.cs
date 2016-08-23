using System;
using System.Collections.Generic;
using System.ServiceModel;

//using Service.Message.Entity.Response;
//using Service.Message.Entity.Request;

using Service.Message.Resquest_Response;

namespace Service.Service.Interfaces
{
    [ServiceContract]
    public interface IPlanGestionService
    {

#region Class: Objetivo Estrategico

        [OperationContract]
        PlanGestionResponse SetObetivoEstrategico(PlanGestionRequest RqtListaPlanGestion);

        [OperationContract]
        PlanGestionResponse GetObetivoEstrategico(PlanGestionRequest RqtListaPlanGestion, String _Items);

#endregion

#region Class: Objetivo Operativo

        [OperationContract]
        PlanGestionResponse SetObetivoOperativo(PlanGestionRequest RqtListaPlanGestion);

        [OperationContract]
        PlanGestionResponse GetObetivoOperativo(PlanGestionRequest RqtListaPlanGestion, String _Items);

#endregion

#region Class: Proyecto

        [OperationContract]
        PlanGestionResponse SetProyecto(PlanGestionRequest RqtListaPlanGestion);

        [OperationContract]
        PlanGestionResponse GetProyecto(PlanGestionRequest RqtListaPlanGestion, String _Items);

#endregion

#region Class: Actividad

        [OperationContract]
        PlanGestionResponse SetActividad(PlanGestionRequest RqtListaPlanGestion);

        [OperationContract]
        PlanGestionResponse GetActividad(PlanGestionRequest RqtListaPlanGestion, String _Items);

#endregion

#region Class: Comentario de Avance

        [OperationContract]
        PlanGestionResponse SetComentarioAvance(PlanGestionRequest RqtListaPlanGestion);

        [OperationContract]
        PlanGestionResponse GetComentarioAvance(PlanGestionRequest RqtListaPlanGestion, String _Items);

#endregion

#region Class: Informe

        [OperationContract]
        PlanGestionResponse GetInforme(PlanGestionRequest RqtListaPlanGestion);

        //[OperationContract]
        //PlanGestionResponse GetObetivoEstrategicoList(PlanGestionRequest RqtListaPlanGestion);

        //[OperationContract]
        //PlanGestionResponse GetObetivoOperativoList(PlanGestionRequest RqtListaPlanGestion);

        //[OperationContract]
        //PlanGestionResponse GetProyectoList(PlanGestionRequest RqtListaPlanGestion);

#endregion


    }
}
