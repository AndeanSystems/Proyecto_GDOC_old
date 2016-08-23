using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Linq;

//using BusinessObject.Entidades;
//using DataObjects.Dao;
//using DataObjects.Interfaces;
//using DataObjects.Sources.AdoNet.SqlServer;
using Service;
//using Service.Criteria;
//using Service.Criteria.Entity;
//using Service.Message.Entity.Response;
//using Service.Message.Entity.Request;
//using Service.DataTransferObjects.Mapper;
using Service.Service.Interfaces;
using Service.Message.Resquest_Response;
using Business;
using Entity.Entities;

namespace Service.Service.Implementations
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class PlanGestionService : IPlanGestionService
    {
        private static bPlanGestion sPlanGestionDao = new bPlanGestion();


#region Class: Objetivo Estrategico

        public PlanGestionResponse SetObetivoEstrategico(PlanGestionRequest RqtListaPlanGestion)
        {
            PlanGestionResponse RpsPlanGestion = new PlanGestionResponse();
            RpsPlanGestion.CorrelationId = RqtListaPlanGestion.RequestId;

            ePlanGestion CtrPlanGes = RqtListaPlanGestion.CtrPlanGestion as ePlanGestion;

            if (RqtListaPlanGestion.LoadOptions.Contains("Man_ObjetivoEstrategico"))
            {
                Int64 sIPlanGestion = 0;
                ePlanGestion sPlanGestion = new ePlanGestion();

                sPlanGestion.TypeOperacion = CtrPlanGes.TypeOperacion;
                sPlanGestion.PeriObjEstr = CtrPlanGes.PeriObjEstr;
                sPlanGestion.CodiObjEstr = CtrPlanGes.CodiObjEstr;
                sPlanGestion.DescObjEstr = CtrPlanGes.DescObjEstr;
                sPlanGestion.AbreObjEstr = CtrPlanGes.AbreObjEstr;
                sPlanGestion.EstaObjEstr = CtrPlanGes.EstaObjEstr;

                sIPlanGestion = sPlanGestionDao.SetObetivoEstrategico(sPlanGestion);
                RpsPlanGestion.AddObetivoEstrategico = sIPlanGestion;

            }
            return RpsPlanGestion;
        }

        public PlanGestionResponse GetObetivoEstrategico(PlanGestionRequest RqtListaPlanGestion, String _Items)
        {
            PlanGestionResponse RpsPlanGestion = new PlanGestionResponse();
            RpsPlanGestion.CorrelationId = RqtListaPlanGestion.RequestId;

            ePlanGestion CtrPlanGestion = RqtListaPlanGestion.CtrPlanGestion as ePlanGestion;

            if (RqtListaPlanGestion.LoadOptions.Contains("Sel_ObjetivoEstrategico"))
            {
                IList<ePlanGestion> ListaPlanGestion;
                ePlanGestion sPlanGestion = new ePlanGestion();

                sPlanGestion.TypeOperacion = CtrPlanGestion.TypeOperacion;
                sPlanGestion.PeriObjEstr = CtrPlanGestion.PeriObjEstr;
                sPlanGestion.CodiObjEstr = CtrPlanGestion.CodiObjEstr;
                sPlanGestion.DescObjEstr = CtrPlanGestion.DescObjEstr;
                sPlanGestion.AbreObjEstr = CtrPlanGestion.AbreObjEstr;
                sPlanGestion.EstaObjEstr = CtrPlanGestion.EstaObjEstr;

                ListaPlanGestion = sPlanGestionDao.GetObetivoEstrategico(sPlanGestion, _Items);
                RpsPlanGestion.ListaObetivoEstrategico = ListaPlanGestion;
            }

            return RpsPlanGestion;
        }

#endregion

#region Class: Objetivo Operativo

        public PlanGestionResponse SetObetivoOperativo(PlanGestionRequest RqtListaPlanGestion)
        {
            PlanGestionResponse RpsPlanGestion = new PlanGestionResponse();
            RpsPlanGestion.CorrelationId = RqtListaPlanGestion.RequestId;

            ePlanGestion CtrPlanGes = RqtListaPlanGestion.CtrPlanGestion as ePlanGestion;

            if (RqtListaPlanGestion.LoadOptions.Contains("Man_ObjetivoOperativo"))
            {
                Int64 sIPlanGestion = 0;
                ePlanGestion sPlanGestion = new ePlanGestion();

                sPlanGestion.TypeOperacion = CtrPlanGes.TypeOperacion;
                sPlanGestion.PeriObjEstr = CtrPlanGes.PeriObjEstr;
                sPlanGestion.CodiObjEstr = CtrPlanGes.CodiObjEstr;

                sPlanGestion.CodiObjOper = CtrPlanGes.CodiObjOper;
                sPlanGestion.DescObjOper = CtrPlanGes.DescObjOper;
                sPlanGestion.AbreObjOper = CtrPlanGes.AbreObjOper;
                sPlanGestion.EstaObjOper = CtrPlanGes.EstaObjOper;

                sIPlanGestion = sPlanGestionDao.SetObetivoOperativo(sPlanGestion);
                RpsPlanGestion.AddObetivoOperativo = sIPlanGestion;

            }
            return RpsPlanGestion;
        }

        public PlanGestionResponse GetObetivoOperativo(PlanGestionRequest RqtListaPlanGestion, String _Items)
        {
            PlanGestionResponse RpsPlanGestion = new PlanGestionResponse();
            RpsPlanGestion.CorrelationId = RqtListaPlanGestion.RequestId;

            ePlanGestion CtrPlanGestion = RqtListaPlanGestion.CtrPlanGestion as ePlanGestion;

            if (RqtListaPlanGestion.LoadOptions.Contains("Sel_ObjetivoOperativo"))
            {
                IList<ePlanGestion> ListaPlanGestion;
                ePlanGestion sPlanGestion = new ePlanGestion();

                sPlanGestion.TypeOperacion = CtrPlanGestion.TypeOperacion;
                sPlanGestion.PeriObjEstr = CtrPlanGestion.PeriObjEstr;
                sPlanGestion.CodiObjEstr = CtrPlanGestion.CodiObjEstr;

                sPlanGestion.CodiObjOper = CtrPlanGestion.CodiObjOper;
                sPlanGestion.DescObjOper = CtrPlanGestion.DescObjOper;
                sPlanGestion.AbreObjOper = CtrPlanGestion.AbreObjOper;
                sPlanGestion.EstaObjOper = CtrPlanGestion.EstaObjOper;

                ListaPlanGestion = sPlanGestionDao.GetObetivoOperativo(sPlanGestion, _Items);
                RpsPlanGestion.ListaObetivoOperativo = ListaPlanGestion;
            }

            return RpsPlanGestion;
        }

#endregion

#region Class: Proyecto

        public PlanGestionResponse SetProyecto(PlanGestionRequest RqtListaPlanGestion)
        {
            PlanGestionResponse RpsPlanGestion = new PlanGestionResponse();
            RpsPlanGestion.CorrelationId = RqtListaPlanGestion.RequestId;

            ePlanGestion CtrPlanGes = RqtListaPlanGestion.CtrPlanGestion as ePlanGestion;

            if (RqtListaPlanGestion.LoadOptions.Contains("Man_Proyecto"))
            {
                Int64 sIPlanGestion = 0;
                ePlanGestion sPlanGestion = new ePlanGestion();

                sPlanGestion.TypeOperacion = CtrPlanGes.TypeOperacion;
                sPlanGestion.PeriObjEstr = CtrPlanGes.PeriObjEstr;
                sPlanGestion.CodiObjEstr = CtrPlanGes.CodiObjEstr;

                sPlanGestion.CodiObjOper = CtrPlanGes.CodiObjOper;

                sPlanGestion.CodiProy = CtrPlanGes.CodiProy;
                sPlanGestion.DescProy = CtrPlanGes.DescProy;
                sPlanGestion.AbreProy = CtrPlanGes.AbreProy;
                sPlanGestion.EstaProy = CtrPlanGes.EstaProy;

                sIPlanGestion = sPlanGestionDao.SetProyecto(sPlanGestion);
                RpsPlanGestion.AddProyecto = sIPlanGestion;

            }
            return RpsPlanGestion;
        }

        public PlanGestionResponse GetProyecto(PlanGestionRequest RqtListaPlanGestion, String _Items)
        {
            PlanGestionResponse RpsPlanGestion = new PlanGestionResponse();
            RpsPlanGestion.CorrelationId = RqtListaPlanGestion.RequestId;

            ePlanGestion CtrPlanGestion = RqtListaPlanGestion.CtrPlanGestion as ePlanGestion;

            if (RqtListaPlanGestion.LoadOptions.Contains("Sel_Proyecto"))
            {
                IList<ePlanGestion> ListaPlanGestion;
                ePlanGestion sPlanGestion = new ePlanGestion();

                sPlanGestion.TypeOperacion = CtrPlanGestion.TypeOperacion;
                sPlanGestion.PeriObjEstr = CtrPlanGestion.PeriObjEstr;
                sPlanGestion.CodiObjEstr = CtrPlanGestion.CodiObjEstr;

                sPlanGestion.CodiObjOper = CtrPlanGestion.CodiObjOper;

                sPlanGestion.CodiProy = CtrPlanGestion.CodiProy;
                sPlanGestion.DescProy = CtrPlanGestion.DescProy;
                sPlanGestion.AbreProy = CtrPlanGestion.AbreProy;
                sPlanGestion.EstaProy = CtrPlanGestion.EstaProy;

                ListaPlanGestion = sPlanGestionDao.GetProyecto(sPlanGestion, _Items);
                RpsPlanGestion.ListaProyecto = ListaPlanGestion;
            }

            return RpsPlanGestion;
        }

#endregion

#region Class: Actividad

        public PlanGestionResponse SetActividad(PlanGestionRequest RqtListaPlanGestion)
        {
            PlanGestionResponse RpsPlanGestion = new PlanGestionResponse();
            RpsPlanGestion.CorrelationId = RqtListaPlanGestion.RequestId;

            ePlanGestion CtrPlanGes = RqtListaPlanGestion.CtrPlanGestion as ePlanGestion;

            if (RqtListaPlanGestion.LoadOptions.Contains("Man_Actividad"))
            {
                Int64 sIPlanGestion = 0;
                ePlanGestion sPlanGestion = new ePlanGestion();

                sPlanGestion.TypeOperacion = CtrPlanGes.TypeOperacion;
                sPlanGestion.PeriObjEstr = CtrPlanGes.PeriObjEstr;
                sPlanGestion.CodiObjEstr = CtrPlanGes.CodiObjEstr;

                sPlanGestion.CodiObjOper = CtrPlanGes.CodiObjOper;

                sPlanGestion.CodiProy = CtrPlanGes.CodiProy;

                sPlanGestion.CodiActi = CtrPlanGes.CodiActi;
                sPlanGestion.DescActi = CtrPlanGes.DescActi;
                sPlanGestion.AbreActi = CtrPlanGes.AbreActi;
                sPlanGestion.EstaActi = CtrPlanGes.EstaActi;

                sPlanGestion.UnidMedMeta = CtrPlanGes.UnidMedMeta;
                sPlanGestion.NumeItemMeta = CtrPlanGes.NumeItemMeta;
                sPlanGestion.PesoPondMeta = CtrPlanGes.PesoPondMeta;
                sPlanGestion.CompEne = CtrPlanGes.CompEne;
                sPlanGestion.CompFeb = CtrPlanGes.CompFeb;
                sPlanGestion.CompMar = CtrPlanGes.CompMar;
                sPlanGestion.CompAbr = CtrPlanGes.CompAbr;
                sPlanGestion.CompMay = CtrPlanGes.CompMay;
                sPlanGestion.CompJun = CtrPlanGes.CompJun;
                sPlanGestion.CompJul = CtrPlanGes.CompJul;
                sPlanGestion.CompAgo = CtrPlanGes.CompAgo;
                sPlanGestion.CompSet = CtrPlanGes.CompSet;
                sPlanGestion.CompOct = CtrPlanGes.CompOct;
                sPlanGestion.CompNov = CtrPlanGes.CompNov;
                sPlanGestion.CompDic = CtrPlanGes.CompDic;
                sPlanGestion.AvanEne = CtrPlanGes.AvanEne;
                sPlanGestion.AvanFeb = CtrPlanGes.AvanFeb;
                sPlanGestion.AvanMar = CtrPlanGes.AvanMar;
                sPlanGestion.AvanAbr = CtrPlanGes.AvanAbr;
                sPlanGestion.AvanMay = CtrPlanGes.AvanMay;
                sPlanGestion.AvanJun = CtrPlanGes.AvanJun;
                sPlanGestion.AvanJul = CtrPlanGes.AvanJul;
                sPlanGestion.AvanAgo = CtrPlanGes.AvanAgo;
                sPlanGestion.AvanSet = CtrPlanGes.AvanSet;
                sPlanGestion.AvanOct = CtrPlanGes.AvanOct;
                sPlanGestion.AvanNov = CtrPlanGes.AvanNov;
                sPlanGestion.AvanDic = CtrPlanGes.AvanDic;

                sIPlanGestion = sPlanGestionDao.SetActividad(sPlanGestion);
                RpsPlanGestion.AddActividad = sIPlanGestion;

            }
            return RpsPlanGestion;
        }

        public PlanGestionResponse GetActividad(PlanGestionRequest RqtListaPlanGestion, String _Items)
        {
            PlanGestionResponse RpsPlanGestion = new PlanGestionResponse();
            RpsPlanGestion.CorrelationId = RqtListaPlanGestion.RequestId;

            ePlanGestion CtrPlanGestion = RqtListaPlanGestion.CtrPlanGestion as ePlanGestion;

            if (RqtListaPlanGestion.LoadOptions.Contains("Sel_Actividad"))
            {
                IList<ePlanGestion> ListaPlanGestion;
                ePlanGestion sPlanGestion = new ePlanGestion();

                sPlanGestion.TypeOperacion = CtrPlanGestion.TypeOperacion;
                sPlanGestion.PeriObjEstr = CtrPlanGestion.PeriObjEstr;
                sPlanGestion.CodiObjEstr = CtrPlanGestion.CodiObjEstr;

                sPlanGestion.CodiObjOper = CtrPlanGestion.CodiObjOper;

                sPlanGestion.CodiProy = CtrPlanGestion.CodiProy;

                sPlanGestion.CodiActi = CtrPlanGestion.CodiActi;
                sPlanGestion.DescActi = CtrPlanGestion.DescActi;
                sPlanGestion.AbreActi = CtrPlanGestion.AbreActi;
                sPlanGestion.EstaActi = CtrPlanGestion.EstaActi;

                sPlanGestion.UnidMedMeta = CtrPlanGestion.UnidMedMeta;
                sPlanGestion.NumeItemMeta = CtrPlanGestion.NumeItemMeta;
                sPlanGestion.PesoPondMeta = CtrPlanGestion.PesoPondMeta;
                sPlanGestion.CompEne = CtrPlanGestion.CompEne;
                sPlanGestion.CompFeb = CtrPlanGestion.CompFeb;
                sPlanGestion.CompMar = CtrPlanGestion.CompMar;
                sPlanGestion.CompAbr = CtrPlanGestion.CompAbr;
                sPlanGestion.CompMay = CtrPlanGestion.CompMay;
                sPlanGestion.CompJun = CtrPlanGestion.CompJun;
                sPlanGestion.CompJul = CtrPlanGestion.CompJul;
                sPlanGestion.CompAgo = CtrPlanGestion.CompAgo;
                sPlanGestion.CompSet = CtrPlanGestion.CompSet;
                sPlanGestion.CompOct = CtrPlanGestion.CompOct;
                sPlanGestion.CompNov = CtrPlanGestion.CompNov;
                sPlanGestion.CompDic = CtrPlanGestion.CompDic;
                sPlanGestion.AvanEne = CtrPlanGestion.AvanEne;
                sPlanGestion.AvanFeb = CtrPlanGestion.AvanFeb;
                sPlanGestion.AvanMar = CtrPlanGestion.AvanMar;
                sPlanGestion.AvanAbr = CtrPlanGestion.AvanAbr;
                sPlanGestion.AvanMay = CtrPlanGestion.AvanMay;
                sPlanGestion.AvanJun = CtrPlanGestion.AvanJun;
                sPlanGestion.AvanJul = CtrPlanGestion.AvanJul;
                sPlanGestion.AvanAgo = CtrPlanGestion.AvanAgo;
                sPlanGestion.AvanSet = CtrPlanGestion.AvanSet;
                sPlanGestion.AvanOct = CtrPlanGestion.AvanOct;
                sPlanGestion.AvanNov = CtrPlanGestion.AvanNov;
                sPlanGestion.AvanDic = CtrPlanGestion.AvanDic;

                ListaPlanGestion = sPlanGestionDao.GetActividad(sPlanGestion, _Items);
                RpsPlanGestion.ListaActividad = ListaPlanGestion;
            }

            return RpsPlanGestion;
        }

#endregion

#region Class: Comentario de Avance

        public PlanGestionResponse SetComentarioAvance(PlanGestionRequest RqtListaPlanGestion)
        {
            PlanGestionResponse RpsPlanGestion = new PlanGestionResponse();
            RpsPlanGestion.CorrelationId = RqtListaPlanGestion.RequestId;

            ePlanGestion CtrPlanGes = RqtListaPlanGestion.CtrPlanGestion as ePlanGestion;

            if (RqtListaPlanGestion.LoadOptions.Contains("Man_ComentarioAvance"))
            {
                Int64 sIPlanGestion = 0;
                ePlanGestion sPlanGestion = new ePlanGestion();

                sPlanGestion.TypeOperacion = CtrPlanGes.TypeOperacion;
                sPlanGestion.PeriObjEstr = CtrPlanGes.PeriObjEstr;
                sPlanGestion.CodiObjEstr = CtrPlanGes.CodiObjEstr;

                sPlanGestion.CodiObjOper = CtrPlanGes.CodiObjOper;

                sPlanGestion.CodiProy = CtrPlanGes.CodiProy;

                sPlanGestion.CodiActi = CtrPlanGes.CodiActi;

                sPlanGestion.MesAvan = CtrPlanGes.MesAvan;
                sPlanGestion.Coment = CtrPlanGes.Coment;
                sPlanGestion.EstaComent = CtrPlanGes.EstaComent;

                sIPlanGestion = sPlanGestionDao.SetComentarioAvance(sPlanGestion);
                RpsPlanGestion.AddComentarioAvance = sIPlanGestion;

            }
            return RpsPlanGestion;
        }

        public PlanGestionResponse GetComentarioAvance(PlanGestionRequest RqtListaPlanGestion, String _Items)
        {
            PlanGestionResponse RpsPlanGestion = new PlanGestionResponse();
            RpsPlanGestion.CorrelationId = RqtListaPlanGestion.RequestId;

            ePlanGestion CtrPlanGestion = RqtListaPlanGestion.CtrPlanGestion as ePlanGestion;

            if (RqtListaPlanGestion.LoadOptions.Contains("Sel_ComentarioAvance"))
            {
                IList<ePlanGestion> ListaPlanGestion;
                ePlanGestion sPlanGestion = new ePlanGestion();

                sPlanGestion.TypeOperacion = CtrPlanGestion.TypeOperacion;
                sPlanGestion.PeriObjEstr = CtrPlanGestion.PeriObjEstr;
                sPlanGestion.CodiObjEstr = CtrPlanGestion.CodiObjEstr;

                sPlanGestion.CodiObjOper = CtrPlanGestion.CodiObjOper;

                sPlanGestion.CodiProy = CtrPlanGestion.CodiProy;

                sPlanGestion.CodiActi = CtrPlanGestion.CodiActi;

                sPlanGestion.MesAvan = CtrPlanGestion.MesAvan;
                sPlanGestion.Coment = CtrPlanGestion.Coment;
                sPlanGestion.EstaComent = CtrPlanGestion.EstaComent;

                ListaPlanGestion = sPlanGestionDao.GetComentarioAvance(sPlanGestion, _Items);
                RpsPlanGestion.ListaComentarioAvance = ListaPlanGestion;
            }

            return RpsPlanGestion;
        }

#endregion

#region Class: Informe

        public PlanGestionResponse GetInforme(PlanGestionRequest RqtListaPlanGestion)
        {
            PlanGestionResponse RpsPlanGestion = new PlanGestionResponse();
            RpsPlanGestion.CorrelationId = RqtListaPlanGestion.RequestId;

            ePlanGestion CtrPlanGestion = RqtListaPlanGestion.CtrPlanGestion as ePlanGestion;

            if (RqtListaPlanGestion.LoadOptions.Contains("Sel_Informe"))
            {
                IList<ePlanGestion> ListaPlanGestion;
                ePlanGestion sPlanGestion = new ePlanGestion();

                sPlanGestion.TypeOperacion = CtrPlanGestion.TypeOperacion;
                sPlanGestion.PeriObjEstr = CtrPlanGestion.PeriObjEstr;
                sPlanGestion.CodiObjEstr = CtrPlanGestion.CodiObjEstr;

                sPlanGestion.CodiObjOper = CtrPlanGestion.CodiObjOper;

                sPlanGestion.CodiProy = CtrPlanGestion.CodiProy;

                sPlanGestion.CodiActi = CtrPlanGestion.CodiActi;

                sPlanGestion.CodiUsu = CtrPlanGestion.CodiUsu;

                ListaPlanGestion = sPlanGestionDao.GetInforme(sPlanGestion);
                RpsPlanGestion.ListaInforme = ListaPlanGestion;
            }

            return RpsPlanGestion;
        }
        /*
        public PlanGestionResponse GetObetivoEstrategicoList(PlanGestionRequest RqtListaPlanGestion)
        {
            PlanGestionResponse RpsPlanGestion = new PlanGestionResponse();
            RpsPlanGestion.CorrelationId = RqtListaPlanGestion.RequestId;

            ePlanGestion CtrPlanGestion = RqtListaPlanGestion.CtrPlanGestion as ePlanGestion;

            if (RqtListaPlanGestion.LoadOptions.Contains("Sel_ObjetivoEstrategicoList"))
            {
                IList<ePlanGestion> ListaPlanGestion;
                ePlanGestion sPlanGestion = new ePlanGestion();

                
                sPlanGestion.PeriObjEstr = CtrPlanGestion.PeriObjEstr;               

                ListaPlanGestion = sPlanGestionDao.GetObetivoEstrategicoList(sPlanGestion);
                RpsPlanGestion.ListaPlanGestion = ListaPlanGestion.Select(c => Mapper.ToDataTO_ObetivoEstrategico(c)).ToList();
            }

            return RpsPlanGestion;
        }

        public PlanGestionResponse GetObetivoOperativoList(PlanGestionRequest RqtListaPlanGestion)
        {
            PlanGestionResponse RpsPlanGestion = new PlanGestionResponse();
            RpsPlanGestion.CorrelationId = RqtListaPlanGestion.RequestId;

            ePlanGestion CtrPlanGestion = RqtListaPlanGestion.CtrPlanGestion as ePlanGestion;

            if (RqtListaPlanGestion.LoadOptions.Contains("Sel_ObjetivoOperativoList"))
            {
                IList<ePlanGestion> ListaPlanGestion;
                ePlanGestion sPlanGestion = new ePlanGestion();
                
                sPlanGestion.PeriObjEstr = CtrPlanGestion.PeriObjEstr;
                sPlanGestion.CodiObjEstr = CtrPlanGestion.CodiObjEstr;                

                ListaPlanGestion = sPlanGestionDao.GetObetivoOperativoList(sPlanGestion);
                RpsPlanGestion.ListaPlanGestion = ListaPlanGestion.Select(c => Mapper.ToDataTO_ObetivoOperativo(c)).ToList();
            }

            return RpsPlanGestion;
        }

        public PlanGestionResponse GetProyectoList(PlanGestionRequest RqtListaPlanGestion)
        {
            PlanGestionResponse RpsPlanGestion = new PlanGestionResponse();
            RpsPlanGestion.CorrelationId = RqtListaPlanGestion.RequestId;

            ePlanGestion CtrPlanGestion = RqtListaPlanGestion.CtrPlanGestion as ePlanGestion;

            if (RqtListaPlanGestion.LoadOptions.Contains("Sel_ProyectoList"))
            {
                IList<ePlanGestion> ListaPlanGestion;
                ePlanGestion sPlanGestion = new ePlanGestion();

                sPlanGestion.PeriObjEstr = CtrPlanGestion.PeriObjEstr;
                sPlanGestion.CodiObjEstr = CtrPlanGestion.CodiObjEstr;
                sPlanGestion.CodiObjOper = CtrPlanGestion.CodiObjOper;
               
                ListaPlanGestion = sPlanGestionDao.GetProyectoList(sPlanGestion);
                RpsPlanGestion.ListaPlanGestion = ListaPlanGestion.Select(c => Mapper.ToDataTO_Proyecto(c)).ToList();
            }

            return RpsPlanGestion;
        }
        */
#endregion

    }
}
