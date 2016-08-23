using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ServiceModel;
using WebGdoc.PlanGestionServRef;
using Entity.Entities;

namespace WebGdoc.ServicesControllers
{
    public class PlanGestionController : ControllerBase
    {

#region Class: Objetivo Estrategico

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public Int64 SetObetivoEstrategico(ePlanGestion _ePlanGestion)
        {
            try
            {
                PlanGestionRequest rqtPlanGestion = new PlanGestionRequest();
                rqtPlanGestion.RequestId = NewRequestId;
                rqtPlanGestion.AccessToken = AccessToken;
                rqtPlanGestion.ClientTag = ClientTag;
                rqtPlanGestion.LoadOptions = new string[] { "Man_ObjetivoEstrategico" };
                rqtPlanGestion.CtrPlanGestion = new ePlanGestion
                {
                    TypeOperacion = _ePlanGestion.TypeOperacion,
                    PeriObjEstr = _ePlanGestion.PeriObjEstr,
                    CodiObjEstr = _ePlanGestion.CodiObjEstr,
                    DescObjEstr = _ePlanGestion.DescObjEstr,
                    AbreObjEstr = _ePlanGestion.AbreObjEstr,
                    EstaObjEstr = _ePlanGestion.EstaObjEstr
                };

                PlanGestionResponse response = PlanGestionServiceClient.SetObetivoEstrategico(rqtPlanGestion);

                if (rqtPlanGestion.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                return response.AddObetivoEstrategico;
            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.Message);  //string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<ePlanGestion> GetObetivoEstrategico(ePlanGestion _ePlanGestion, String _Items)
        {
            try
            {
                PlanGestionRequest rqtPlanGestion = new PlanGestionRequest();
                rqtPlanGestion.RequestId = NewRequestId;
                rqtPlanGestion.AccessToken = AccessToken;
                rqtPlanGestion.ClientTag = ClientTag;
                rqtPlanGestion.LoadOptions = new string[] { "Sel_ObjetivoEstrategico" };
                rqtPlanGestion.CtrPlanGestion = new ePlanGestion
                {
                    TypeOperacion = _ePlanGestion.TypeOperacion,
                    PeriObjEstr = _ePlanGestion.PeriObjEstr,
                    CodiObjEstr = _ePlanGestion.CodiObjEstr,
                    DescObjEstr = _ePlanGestion.DescObjEstr,
                    AbreObjEstr = _ePlanGestion.AbreObjEstr,
                    EstaObjEstr = _ePlanGestion.EstaObjEstr
                };

                PlanGestionResponse response = PlanGestionServiceClient.GetObetivoEstrategico(rqtPlanGestion, _Items);

                if (rqtPlanGestion.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                return response.ListaObetivoEstrategico;
            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.Message);  //string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }
        }
        
#endregion

#region Class: Objetivo Operativo

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public Int64 SetObetivoOperativo(ePlanGestion _ePlanGestion)
        {
            try
            {
                PlanGestionRequest rqtPlanGestion = new PlanGestionRequest();
                rqtPlanGestion.RequestId = NewRequestId;
                rqtPlanGestion.AccessToken = AccessToken;
                rqtPlanGestion.ClientTag = ClientTag;
                rqtPlanGestion.LoadOptions = new string[] { "Man_ObjetivoOperativo" };
                rqtPlanGestion.CtrPlanGestion = new ePlanGestion
                {
                    TypeOperacion = _ePlanGestion.TypeOperacion,
                    PeriObjEstr = _ePlanGestion.PeriObjEstr,
                    CodiObjEstr = _ePlanGestion.CodiObjEstr,

                    CodiObjOper = _ePlanGestion.CodiObjOper,
                    DescObjOper = _ePlanGestion.DescObjOper,
                    AbreObjOper = _ePlanGestion.AbreObjOper,
                    EstaObjOper = _ePlanGestion.EstaObjOper
                };

                PlanGestionResponse response = PlanGestionServiceClient.SetObetivoOperativo(rqtPlanGestion);

                if (rqtPlanGestion.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                return response.AddObetivoOperativo;
            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.Message);  //string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<ePlanGestion> GetObetivoOperativo(ePlanGestion _ePlanGestion, String _Items)
        {
            try
            {
                PlanGestionRequest rqtPlanGestion = new PlanGestionRequest();
                rqtPlanGestion.RequestId = NewRequestId;
                rqtPlanGestion.AccessToken = AccessToken;
                rqtPlanGestion.ClientTag = ClientTag;
                rqtPlanGestion.LoadOptions = new string[] { "Sel_ObjetivoOperativo" };
                rqtPlanGestion.CtrPlanGestion = new ePlanGestion
                {
                    TypeOperacion = _ePlanGestion.TypeOperacion,
                    PeriObjEstr = _ePlanGestion.PeriObjEstr,
                    CodiObjEstr = _ePlanGestion.CodiObjEstr,

                    CodiObjOper = _ePlanGestion.CodiObjOper,
                    DescObjOper = _ePlanGestion.DescObjOper,
                    AbreObjOper = _ePlanGestion.AbreObjOper,
                    EstaObjOper = _ePlanGestion.EstaObjOper
                };

                PlanGestionResponse response = PlanGestionServiceClient.GetObetivoOperativo(rqtPlanGestion, _Items);

                if (rqtPlanGestion.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                return response.ListaObetivoOperativo;
            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.Message);  //string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }
        }

#endregion

#region Class: Proyecto

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public Int64 SetProyecto(ePlanGestion _ePlanGestion)
        {
            try
            {
                PlanGestionRequest rqtPlanGestion = new PlanGestionRequest();
                rqtPlanGestion.RequestId = NewRequestId;
                rqtPlanGestion.AccessToken = AccessToken;
                rqtPlanGestion.ClientTag = ClientTag;
                rqtPlanGestion.LoadOptions = new string[] { "Man_Proyecto" };
                rqtPlanGestion.CtrPlanGestion = new ePlanGestion
                {
                    TypeOperacion = _ePlanGestion.TypeOperacion,
                    PeriObjEstr = _ePlanGestion.PeriObjEstr,
                    CodiObjEstr = _ePlanGestion.CodiObjEstr,

                    CodiObjOper = _ePlanGestion.CodiObjOper,

                    CodiProy = _ePlanGestion.CodiProy,
                    DescProy = _ePlanGestion.DescProy,
                    AbreProy = _ePlanGestion.AbreProy,
                    EstaProy = _ePlanGestion.EstaProy
                };

                PlanGestionResponse response = PlanGestionServiceClient.SetProyecto(rqtPlanGestion);

                if (rqtPlanGestion.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                return response.AddProyecto;
            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.Message);  //string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<ePlanGestion> GetProyecto(ePlanGestion _ePlanGestion, String _Items)
        {
            try
            {
                PlanGestionRequest rqtPlanGestion = new PlanGestionRequest();
                rqtPlanGestion.RequestId = NewRequestId;
                rqtPlanGestion.AccessToken = AccessToken;
                rqtPlanGestion.ClientTag = ClientTag;
                rqtPlanGestion.LoadOptions = new string[] { "Sel_Proyecto" };
                rqtPlanGestion.CtrPlanGestion = new ePlanGestion
                {
                    TypeOperacion = _ePlanGestion.TypeOperacion,
                    PeriObjEstr = _ePlanGestion.PeriObjEstr,
                    CodiObjEstr = _ePlanGestion.CodiObjEstr,

                    CodiObjOper = _ePlanGestion.CodiObjOper,

                    CodiProy = _ePlanGestion.CodiProy,
                    DescProy = _ePlanGestion.DescProy,
                    AbreProy = _ePlanGestion.AbreProy,
                    EstaProy = _ePlanGestion.EstaProy
                };

                PlanGestionResponse response = PlanGestionServiceClient.GetProyecto(rqtPlanGestion, _Items);

                if (rqtPlanGestion.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                return response.ListaProyecto;
            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.Message);  //string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }
        }

#endregion

#region Class: Actividad

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public Int64 SetActividad(ePlanGestion _ePlanGestion)
        {
            try
            {
                PlanGestionRequest rqtPlanGestion = new PlanGestionRequest();
                rqtPlanGestion.RequestId = NewRequestId;
                rqtPlanGestion.AccessToken = AccessToken;
                rqtPlanGestion.ClientTag = ClientTag;
                rqtPlanGestion.LoadOptions = new string[] { "Man_Actividad" };
                rqtPlanGestion.CtrPlanGestion = new ePlanGestion
                {
                    TypeOperacion = _ePlanGestion.TypeOperacion,
                    PeriObjEstr = _ePlanGestion.PeriObjEstr,
                    CodiObjEstr = _ePlanGestion.CodiObjEstr,

                    CodiObjOper = _ePlanGestion.CodiObjOper,

                    CodiProy = _ePlanGestion.CodiProy,

                    CodiActi = _ePlanGestion.CodiActi,
                    DescActi = _ePlanGestion.DescActi,
                    AbreActi = _ePlanGestion.AbreActi,
                    EstaActi = _ePlanGestion.EstaActi,
                    UnidMedMeta = _ePlanGestion.UnidMedMeta,
                    NumeItemMeta = _ePlanGestion.NumeItemMeta,
                    PesoPondMeta = _ePlanGestion.PesoPondMeta,
                    CodiUsu = _ePlanGestion.CodiUsu,
                    CompEne = _ePlanGestion.CompEne,
                    CompFeb = _ePlanGestion.CompFeb,
                    CompMar = _ePlanGestion.CompMar,
                    CompAbr = _ePlanGestion.CompAbr,
                    CompMay = _ePlanGestion.CompMay,
                    CompJun = _ePlanGestion.CompJun,
                    CompJul = _ePlanGestion.CompJul,
                    CompAgo = _ePlanGestion.CompAgo,
                    CompSet = _ePlanGestion.CompSet,
                    CompOct = _ePlanGestion.CompOct,
                    CompNov = _ePlanGestion.CompNov,
                    CompDic = _ePlanGestion.CompDic,
                    AvanEne = _ePlanGestion.AvanEne,
                    AvanFeb = _ePlanGestion.AvanFeb,
                    AvanMar = _ePlanGestion.AvanMar,
                    AvanAbr = _ePlanGestion.AvanAbr,
                    AvanMay = _ePlanGestion.AvanMay,
                    AvanJun = _ePlanGestion.AvanJun,
                    AvanJul = _ePlanGestion.AvanJul,
                    AvanAgo = _ePlanGestion.AvanAgo,
                    AvanSet = _ePlanGestion.AvanSet,
                    AvanOct = _ePlanGestion.AvanOct,
                    AvanNov = _ePlanGestion.AvanNov,
                    AvanDic = _ePlanGestion.AvanDic
                };

                PlanGestionResponse response = PlanGestionServiceClient.SetActividad(rqtPlanGestion);

                if (rqtPlanGestion.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                return response.AddActividad;
            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.Message);  //string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<ePlanGestion> GetActividad(ePlanGestion _ePlanGestion, String _Items)
        {
            try
            {
                PlanGestionRequest rqtPlanGestion = new PlanGestionRequest();
                rqtPlanGestion.RequestId = NewRequestId;
                rqtPlanGestion.AccessToken = AccessToken;
                rqtPlanGestion.ClientTag = ClientTag;
                rqtPlanGestion.LoadOptions = new string[] { "Sel_Actividad" };
                rqtPlanGestion.CtrPlanGestion = new ePlanGestion
                {
                    TypeOperacion = _ePlanGestion.TypeOperacion,
                    PeriObjEstr = _ePlanGestion.PeriObjEstr,
                    CodiObjEstr = _ePlanGestion.CodiObjEstr,

                    CodiObjOper = _ePlanGestion.CodiObjOper,

                    CodiProy = _ePlanGestion.CodiProy,

                    CodiActi = _ePlanGestion.CodiActi,
                    DescActi = _ePlanGestion.DescActi,
                    AbreActi = _ePlanGestion.AbreActi,
                    EstaActi = _ePlanGestion.EstaActi,
                    UnidMedMeta = _ePlanGestion.UnidMedMeta,
                    NumeItemMeta = _ePlanGestion.NumeItemMeta,
                    PesoPondMeta = _ePlanGestion.PesoPondMeta,
                    CodiUsu = _ePlanGestion.CodiUsu,
                    CompEne = _ePlanGestion.CompEne,
                    CompFeb = _ePlanGestion.CompFeb,
                    CompMar = _ePlanGestion.CompMar,
                    CompMay = _ePlanGestion.CompMay,
                    CompJun = _ePlanGestion.CompJun,
                    CompJul = _ePlanGestion.CompJul,
                    CompAgo = _ePlanGestion.CompAgo,
                    CompSet = _ePlanGestion.CompSet,
                    CompOct = _ePlanGestion.CompOct,
                    CompNov = _ePlanGestion.CompNov,
                    CompDic = _ePlanGestion.CompDic,
                    AvanEne = _ePlanGestion.AvanEne,
                    AvanFeb = _ePlanGestion.AvanFeb,
                    AvanMar = _ePlanGestion.AvanMar,
                    AvanMay = _ePlanGestion.AvanMay,
                    AvanJun = _ePlanGestion.AvanJun,
                    AvanJul = _ePlanGestion.AvanJul,
                    AvanAgo = _ePlanGestion.AvanAgo,
                    AvanSet = _ePlanGestion.AvanSet,
                    AvanOct = _ePlanGestion.AvanOct,
                    AvanNov = _ePlanGestion.AvanNov,
                    AvanDic = _ePlanGestion.AvanDic
                };

                PlanGestionResponse response = PlanGestionServiceClient.GetActividad(rqtPlanGestion, _Items);

                if (rqtPlanGestion.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                return response.ListaActividad;
            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.Message);  //string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }
        }

#endregion

#region Class: Comentario de Avance

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public Int64 SetComentarioAvance(ePlanGestion _ePlanGestion)
        {
            try
            {
                PlanGestionRequest rqtPlanGestion = new PlanGestionRequest();
                rqtPlanGestion.RequestId = NewRequestId;
                rqtPlanGestion.AccessToken = AccessToken;
                rqtPlanGestion.ClientTag = ClientTag;
                rqtPlanGestion.LoadOptions = new string[] { "Man_ComentarioAvance" };
                rqtPlanGestion.CtrPlanGestion = new ePlanGestion
                {
                    TypeOperacion = _ePlanGestion.TypeOperacion,
                    PeriObjEstr = _ePlanGestion.PeriObjEstr,
                    CodiObjEstr = _ePlanGestion.CodiObjEstr,

                    CodiObjOper = _ePlanGestion.CodiObjOper,

                    CodiProy = _ePlanGestion.CodiProy,

                    CodiActi = _ePlanGestion.CodiActi,

                    MesAvan = _ePlanGestion.MesAvan,
                    Coment = _ePlanGestion.Coment,
                    EstaComent = _ePlanGestion.EstaComent,
                };

                PlanGestionResponse response = PlanGestionServiceClient.SetComentarioAvance(rqtPlanGestion);

                if (rqtPlanGestion.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                return response.AddComentarioAvance;
            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.Message);  //string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<ePlanGestion> GetComentarioAvance(ePlanGestion _ePlanGestion, String _Items)
        {
            try
            {
                PlanGestionRequest rqtPlanGestion = new PlanGestionRequest();
                rqtPlanGestion.RequestId = NewRequestId;
                rqtPlanGestion.AccessToken = AccessToken;
                rqtPlanGestion.ClientTag = ClientTag;
                rqtPlanGestion.LoadOptions = new string[] { "Sel_ComentarioAvance" };
                rqtPlanGestion.CtrPlanGestion = new ePlanGestion
                {
                    TypeOperacion = _ePlanGestion.TypeOperacion,
                    PeriObjEstr = _ePlanGestion.PeriObjEstr,
                    CodiObjEstr = _ePlanGestion.CodiObjEstr,

                    CodiObjOper = _ePlanGestion.CodiObjOper,

                    CodiProy = _ePlanGestion.CodiProy,

                    CodiActi = _ePlanGestion.CodiActi,

                    MesAvan = _ePlanGestion.MesAvan,
                    Coment = _ePlanGestion.Coment,
                    EstaComent = _ePlanGestion.EstaComent,
                };

                PlanGestionResponse response = PlanGestionServiceClient.GetComentarioAvance(rqtPlanGestion, _Items);

                if (rqtPlanGestion.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                return response.ListaComentarioAvance;
            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.Message);  //string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }
        }

#endregion


        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<ePlanGestion> GetInforme(ePlanGestion _ePlanGestion)
        {
            try
            {
                PlanGestionRequest rqtPlanGestion = new PlanGestionRequest();
                rqtPlanGestion.RequestId = NewRequestId;
                rqtPlanGestion.AccessToken = AccessToken;
                rqtPlanGestion.ClientTag = ClientTag;
                rqtPlanGestion.LoadOptions = new string[] { "Sel_Informe" };
                rqtPlanGestion.CtrPlanGestion = new ePlanGestion 
                {
                    TypeOperacion = _ePlanGestion.TypeOperacion,
                    PeriObjEstr = _ePlanGestion.PeriObjEstr,
                    CodiObjEstr = _ePlanGestion.CodiObjEstr,
                    CodiObjOper = _ePlanGestion.CodiObjOper,
                    CodiProy = _ePlanGestion.CodiProy,
                    CodiActi = _ePlanGestion.CodiActi,
                    CodiUsu = _ePlanGestion.CodiUsu
                };

                PlanGestionResponse response = PlanGestionServiceClient.GetInforme(rqtPlanGestion);

                if (rqtPlanGestion.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                return response.ListaInforme;
            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.Message);  //string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);  
            }
        }

    }
}