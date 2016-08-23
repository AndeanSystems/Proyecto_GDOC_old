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
    public class DigitalizacionService : IDigitalizacionService
    {

        private static bDocDig sDocDigDao = new bDocDig();
        private static bDocDigTD sDocDigTDDao = new bDocDigTD();
        private static bDocAdj sDocAdjDao = new bDocAdj();
        private static bDocDigRef sDocDigRefDao = new bDocDigRef();
        private static bLDocDig sLDocDigDao = new bLDocDig();
        private static bLDocDigRef LDocDigRefDao = new bLDocDigRef();
        private static bDocumentoElectronico sDocumentoElectronicoDao = new bDocumentoElectronico();
        private static bLDocElec sLDocElecDao = new bLDocElec();
        private static bLogOperacion sLogOperacionDao = new bLogOperacion();
        private static bMensajeAlerta sMensajeAlertaDao = new bMensajeAlerta();
        private static bListMensAler sListMensAlerDao = new bListMensAler();
        private static bMesaVirtual sMesaVirtualDao = new bMesaVirtual();
        private static bInserMesaVirtual InserMesaVirtualDao = new bInserMesaVirtual();
        private static bComentMesa ComentMesaDao = new bComentMesa();
        private static bConsComenMV ConsComenMVDao = new bConsComenMV();



#region Class: Documento Digital - Referencias

        public DocDigResponse SetDocDigAdd(ref DocDigRequest RqtDocDig)
        {
            DocDigResponse RpsDocDig = new DocDigResponse();
            RpsDocDig.CorrelationId = RqtDocDig.RequestId;

            eDocDig CtrDocDig = RqtDocDig.CtrDocDig as eDocDig;

            if (RqtDocDig.LoadOptions.Contains("DocDigAdd"))
            {
                Int64 sIDocDig = 0;
                eDocDig sDocDig = new eDocDig();

                sDocDig.CodiDocuDigi = CtrDocDig.CodiDocuDigi;
                sDocDig.Type = CtrDocDig.Type;
                sDocDig.TituDocuDigi = CtrDocDig.TituDocuDigi;
                sDocDig.AsunDocuDigi = CtrDocDig.AsunDocuDigi;
                sDocDig.NombOrig = CtrDocDig.NombOrig;
                sDocDig.RutaFisi = CtrDocDig.RutaFisi;
                sDocDig.TamaDocu = CtrDocDig.TamaDocu;
                sDocDig.ExteDocu = CtrDocDig.ExteDocu;
                sDocDig.NombFisi = CtrDocDig.NombFisi;
                sDocDig.ClasDocu = CtrDocDig.ClasDocu;
                sDocDig.EstDocuDigi = CtrDocDig.EstDocuDigi;
                sDocDig.FechEmiDocu = CtrDocDig.FechEmiDocu;
                sDocDig.FechRece = CtrDocDig.FechRece;
                sDocDig.FechRegi = CtrDocDig.FechRegi;
                sDocDig.FechActu = CtrDocDig.FechActu;
                sDocDig.AcceDocuDigi = CtrDocDig.AcceDocuDigi;
                sDocDig.CodiTipoDocu = CtrDocDig.CodiTipoDocu;
                sDocDig.NumDocuDigi = CtrDocDig.NumDocuDigi;
                sDocDig.CodUsu = CtrDocDig.CodUsu;
                sDocDig.Comentario = CtrDocDig.Comentario;

                sIDocDig = sDocDigDao.SetDocDigAdd(sDocDig);

                if (sDocDig.CodiDocuDigi > 0)
                {
                    RqtDocDig.CtrDocDig.CodiDocuDigi = sDocDig.CodiDocuDigi;
                    RqtDocDig.CtrDocDig.NumDocuDigi = sDocDig.NumDocuDigi;
                }
    
                RpsDocDig.AddDocDig = sIDocDig;
            }

            return RpsDocDig;
        }

        public LDocDigResponse GetDocDigital(DocDigRequest RqtDocDig)
        {
            LDocDigResponse RpsDocDig = new LDocDigResponse();
            RpsDocDig.CorrelationId = RqtDocDig.RequestId;

            eDocDig CtrDocDig = RqtDocDig.CtrDocDig as eDocDig;

            if (RqtDocDig.LoadOptions.Contains("ListaDocDig"))
            {
                IList<eDocDig> ListaDocDigital;
                eDocDig sDocDig = new eDocDig();

                sDocDig.EstDocuDigi = CtrDocDig.EstDocuDigi;
                sDocDig.CodiDocuDigi = CtrDocDig.CodiDocuDigi;
                sDocDig.NumDocuDigi = CtrDocDig.NumDocuDigi;
                //sDocElec.User.Codigo = CtrDocElec.Usur.Codigo;
                sDocDig.User = new eUsuario
                {
                    Codigo = CtrDocDig.User.Codigo
                };


                ListaDocDigital = sLDocDigDao.GetDocDigital(sDocDig);
                RpsDocDig.ListaDocDig = ListaDocDigital;
            }

            return RpsDocDig;
        }


    #region Class: Referencias

        public DocDigRefResponse SetDocDigRefAdd(DocDigRefRequest RqtDocDig)
        {
            DocDigRefResponse RpsDocDig = new DocDigRefResponse();
            RpsDocDig.CorrelationId = RqtDocDig.RequestId;

            eDocDigRef CtrDocDigRef = RqtDocDig.CtrDocDigRef as eDocDigRef;


            if (RqtDocDig.LoadOptions.Contains("DocDigRefAdd"))
            {
                Int64 sIDocDigRef = 0;
                eDocDigRef sDocDig = new eDocDigRef();

                sDocDig.CodiInde = CtrDocDigRef.CodiInde;
                sDocDig.Type = CtrDocDigRef.Type;
                sDocDig.DescInde = CtrDocDigRef.DescInde;
                sDocDig.EstaInde = CtrDocDigRef.EstaInde;
                sDocDig.CodiOper = CtrDocDigRef.CodiOper;
                sDocDig.TipoOper = CtrDocDigRef.TipoOper;

                sIDocDigRef = sDocDigRefDao.SetRefDigital(sDocDig);
                RpsDocDig.AddDocDigRef = sIDocDigRef;
            }

            return RpsDocDig;
        }

        public LDocDigRefResponse GetDocDigRef(DocDigRefRequest RqtDocDigRef)
        {
            LDocDigRefResponse RpsDocDigRef = new LDocDigRefResponse();
            RpsDocDigRef.CorrelationId = RqtDocDigRef.RequestId;

            eDocDigRef CtrDocDigRef = RqtDocDigRef.CtrDocDigRef as eDocDigRef;

            if (RqtDocDigRef.LoadOptions.Contains("DogDigRefLista"))
            {
                IList<eDocDigRef> ListaRefDigital;
                eDocDigRef sDocDigRef = new eDocDigRef();

                //sExample.Codigo = CtrExample.Codigo;
                sDocDigRef.EstaInde = CtrDocDigRef.EstaInde;
                sDocDigRef.CodiOper = CtrDocDigRef.CodiOper;

                ListaRefDigital = LDocDigRefDao.GetDocDigRef(sDocDigRef);
                RpsDocDigRef.ListaRefDigital = ListaRefDigital;
            }


            return RpsDocDigRef;


        }

    #endregion


#endregion

#region Class: Tipo de Documentos

        public DocDigDTResponse GetListaTipoDoc(DocDigDTRequest RqtListaTipoDoc)
            {
                DocDigDTResponse RpsDocDigTD = new DocDigDTResponse();
                RpsDocDigTD.CorrelationId = RqtListaTipoDoc.RequestId;

                eDocDigListTD CtrDocDigTD = RqtListaTipoDoc.CtrDocDigTD as eDocDigListTD;

                if (RqtListaTipoDoc.LoadOptions.Contains("DogDigLista"))
                {
                    IList<eDocDigListTD> ListaTipDoc;
                    eDocDigListTD sDocDigListTD = new eDocDigListTD();

                     //sExample.Codigo = CtrExample.Codigo;
                    sDocDigListTD.EstTipoDocumento = CtrDocDigTD.EstTipoDocumento;

                    ListaTipDoc = sDocDigTDDao.GetListaTipoDoc(sDocDigListTD);
                    RpsDocDigTD.ListaDogDig = ListaTipDoc;
                }
                

                return RpsDocDigTD;
            }

#endregion 

#region Class: DocAdj

        public DocAdjResponse SetDocAdj(DocAdjRequest RqtDocAdj)
        {
            DocAdjResponse RpsDocAdj = new DocAdjResponse();
            RpsDocAdj.CorrelationId = RqtDocAdj.RequestId;

            eDocAdj CtrDocAdj = RqtDocAdj.CtrDocAdj as eDocAdj;

            if (RqtDocAdj.LoadOptions.Contains("DocAdjAdd"))
            {
                Int64 sIDocAdj = 0;
                eDocAdj sDocAdj = new eDocAdj();
                //sDocAdj.Type = CtrDocAdj.Type;
                sDocAdj.CodiAdj = CtrDocAdj.CodiAdj;
                sDocAdj.CodiOper = CtrDocAdj.CodiOper;
                //sDocAdj.CodiTipoDocu = CtrDocAdj.CodiTipoDocu;
                sDocAdj.TipoOper = CtrDocAdj.TipoOper;
                sDocAdj.CodiDocAdju = CtrDocAdj.CodiDocAdju;
                sDocAdj.TipoDocAdju = CtrDocAdj.TipoDocAdju;
                sDocAdj.CodiComenMesaV = CtrDocAdj.CodiComenMesaV;
                sDocAdj.EstDocuAdju = CtrDocAdj.EstDocuAdju;

                sIDocAdj = sDocAdjDao.SetDocAdj(sDocAdj);
                RpsDocAdj.AddDocAdj = sIDocAdj;
            }

            return RpsDocAdj;
        }

        public LDocAdjResponse GetDocAdj(DocAdjRequest RqtDocAdj)
        {
            LDocAdjResponse RpsDocAdj = new LDocAdjResponse();
            RpsDocAdj.CorrelationId = RqtDocAdj.RequestId;

            eDocAdj CtrDocAdj = RqtDocAdj.CtrDocAdj as eDocAdj;

            if (RqtDocAdj.LoadOptions.Contains("DocAdjList"))
            {
                IList<eDocAdj> ListaAdj;
                eDocAdj sDocAdj = new eDocAdj();
                sDocAdj.CodiOper = CtrDocAdj.CodiOper;
                sDocAdj.CodiComenMesaV = CtrDocAdj.CodiComenMesaV;

                ListaAdj = sDocAdjDao.GetDocAdj(sDocAdj);
                RpsDocAdj.ListAdj = ListaAdj; 
            }

            return RpsDocAdj;
        }

        public DocAdjResponse SetAnulaDocAdj(DocAdjRequest RqtDocAdj)
        {
            DocAdjResponse RpsDocAdj = new DocAdjResponse();
            RpsDocAdj.CorrelationId = RqtDocAdj.RequestId;

            eDocAdj CtrDocAdj = RqtDocAdj.CtrDocAdj as eDocAdj;

            if (RqtDocAdj.LoadOptions.Contains("DocAdjAnula"))
            {
                Int64 sIDocAdj = 0;
                eDocAdj sDocAdj = new eDocAdj();
                
                sDocAdj.CodiOper = CtrDocAdj.CodiOper;
                sDocAdj.CodiComenMesaV = CtrDocAdj.CodiComenMesaV;

                sIDocAdj = sDocAdjDao.SetAnulaDocAdj(sDocAdj);
                RpsDocAdj.AddDocAdj = sIDocAdj;
            }

            return RpsDocAdj;
        }
        
#endregion

#region Class: Documento Electronico

        public DocumentoElectronicoResponse SetDocumentoElectronicoEnviar(ref DocumentoElectronicoRequest RqtDocumentoElectronico)
        {
            DocumentoElectronicoResponse RpsDocumentoElectronico = new DocumentoElectronicoResponse();
            RpsDocumentoElectronico.CorrelationId = RqtDocumentoElectronico.RequestId;

            eDocumentoElectronico CtrDocumentoElectronico = RqtDocumentoElectronico.CtrDocumentoElectronico as eDocumentoElectronico;

            if (RqtDocumentoElectronico.LoadOptions.Contains("DocumentoElectronicoEnviar"))
            {
                Int64 sIDocumentoElectronico = 0;
                eDocumentoElectronico sDocumentoElectronico = new eDocumentoElectronico();

                sDocumentoElectronico.CodiOper = CtrDocumentoElectronico.CodiOper;
                sDocumentoElectronico.CodiDocuElec = CtrDocumentoElectronico.CodiDocuElec;
                sDocumentoElectronico.Type = CtrDocumentoElectronico.Type;
                sDocumentoElectronico.TipoComu = CtrDocumentoElectronico.TipoComu;
                sDocumentoElectronico.AsunDocuElec = CtrDocumentoElectronico.AsunDocuElec;
                sDocumentoElectronico.FechEmi = CtrDocumentoElectronico.FechEmi;
                sDocumentoElectronico.FechEnvi = CtrDocumentoElectronico.FechEnvi;
                sDocumentoElectronico.PrioDocuElec = CtrDocumentoElectronico.PrioDocuElec;
                sDocumentoElectronico.MensDocuElec = CtrDocumentoElectronico.MensDocuElec;
                sDocumentoElectronico.FechVige = CtrDocumentoElectronico.FechVige;
                sDocumentoElectronico.EstDocuElec = CtrDocumentoElectronico.EstDocuElec;
                sDocumentoElectronico.CateDocuElec = CtrDocumentoElectronico.CateDocuElec;
                sDocumentoElectronico.FechCie = CtrDocumentoElectronico.FechCie;
                sDocumentoElectronico.TipoAcc = CtrDocumentoElectronico.TipoAcc;
                sDocumentoElectronico.CodiTipoDocu = CtrDocumentoElectronico.CodiTipoDocu;
                sDocumentoElectronico.NumDocuElec = CtrDocumentoElectronico.NumDocuElec;
                sDocumentoElectronico.CodUsu = CtrDocumentoElectronico.CodUsu;
                sDocumentoElectronico.Memo = CtrDocumentoElectronico.Memo;

                sIDocumentoElectronico = sDocumentoElectronicoDao.SetDocumentoElectronicoEnviar(sDocumentoElectronico);
                if (sDocumentoElectronico.CodiOper > 0)
                {
                    RqtDocumentoElectronico.CtrDocumentoElectronico.CodiOper = sDocumentoElectronico.CodiOper;
                    RqtDocumentoElectronico.CtrDocumentoElectronico.NumDocuElec = sDocumentoElectronico.NumDocuElec;
                }
                RpsDocumentoElectronico.EnviarDocumentoElectronico = sIDocumentoElectronico;
            }

            return RpsDocumentoElectronico;
        }

        public LDocElecResponse GetDocElec(DocumentoElectronicoRequest RqtDocElec)
        {
            LDocElecResponse RpsDocElec = new LDocElecResponse();
            RpsDocElec.CorrelationId = RqtDocElec.RequestId;

            eDocumentoElectronico CtrDocElec = RqtDocElec.CtrDocumentoElectronico as eDocumentoElectronico;

            if (RqtDocElec.LoadOptions.Contains("ListaDocElec"))
            {
                IList<eDocumentoElectronico> ListaDocElectronico;
                eDocumentoElectronico sDocElec = new eDocumentoElectronico();

                sDocElec.EstDocuElec = CtrDocElec.EstDocuElec;
                sDocElec.CodiOper = CtrDocElec.CodiOper;
                sDocElec.NumDocuElec = CtrDocElec.NumDocuElec;
                //sDocElec.User.Codigo = CtrDocElec.Usur.Codigo;
                sDocElec.User = new eUsuario
                {
                    Codigo = CtrDocElec.User.Codigo
                };


                ListaDocElectronico = sLDocElecDao.GetDocElec(sDocElec);
                RpsDocElec.ListaDocElecttonico = ListaDocElectronico;
            }

            return RpsDocElec;
        }

#endregion

#region Class: Log de Operacion

        public LogOperacionResponse SetLogOperacion(LogOperacionRequest RqtLogOperacion)
        {
            LogOperacionResponse RpsLogOperacion = new LogOperacionResponse();
            RpsLogOperacion.CorrelationId = RqtLogOperacion.RequestId;

            eLogOperacion CtrLogOper = RqtLogOperacion.CtrLogOper as eLogOperacion;

            if (RqtLogOperacion.LoadOptions.Contains("LogOperacionAdd"))
            {
                Int64 sILogOperacion = 0;

                eLogOperacion sLogOperacion = new eLogOperacion();

                sLogOperacion.Type = CtrLogOper.Type;
                sLogOperacion.CodiLogOper = CtrLogOper.CodiLogOper;
                sLogOperacion.FechEven = CtrLogOper.FechEven;
                sLogOperacion.TipoOper = CtrLogOper.TipoOper;
                sLogOperacion.CodiOper = CtrLogOper.CodiOper;
                sLogOperacion.CodiEven = CtrLogOper.CodiEven;
                sLogOperacion.CodiUsu = CtrLogOper.CodiUsu;
                sLogOperacion.CodiCnx = CtrLogOper.CodiCnx;

                sILogOperacion = sLogOperacionDao.SetLogOperacion(sLogOperacion);
                RpsLogOperacion.AddLogOperacion = sILogOperacion;

            }
            return RpsLogOperacion;

        }

#endregion

#region Class: Mensajes de Alerta

        public MensajeAlertaResponse SetMensajeAlerta(MensajeAlertaRequest RqtMensajeAlerta)
        {
            MensajeAlertaResponse RpsMensajeAlerta = new MensajeAlertaResponse();
            RpsMensajeAlerta.CorrelationId = RqtMensajeAlerta.RequestId;

            eMensajeAlerta CtrMenAlert = RqtMensajeAlerta.CtrMenAlert as eMensajeAlerta;

            if (RqtMensajeAlerta.LoadOptions.Contains("MensajeAlertaAdd"))
            {
                Int64 sIMensajeAlerta = 0;

                eMensajeAlerta sMensajeAlerta = new eMensajeAlerta();

                sMensajeAlerta.Type = CtrMenAlert.Type;
                sMensajeAlerta.CodiOper = CtrMenAlert.CodiOper;
                sMensajeAlerta.TipoOper = CtrMenAlert.TipoOper;
                sMensajeAlerta.FechAler = CtrMenAlert.FechAler;
                sMensajeAlerta.TipoAler = CtrMenAlert.TipoAler;
                sMensajeAlerta.CodiEven = CtrMenAlert.CodiEven;
                sMensajeAlerta.EstMensAler = CtrMenAlert.EstMensAler;
                sMensajeAlerta.CodiUsu = CtrMenAlert.CodiUsu;

                sIMensajeAlerta = sMensajeAlertaDao.SetMensajeAlerta(sMensajeAlerta);
                RpsMensajeAlerta.AddMensajeAlerta = sIMensajeAlerta;
            }

            return RpsMensajeAlerta;
        }

        public LMensajeAlertaResponse GetMensajAlerta(MensajeAlertaRequest RqtMensAlert)
        {
            LMensajeAlertaResponse RpsMensjAlert = new LMensajeAlertaResponse();
            RpsMensjAlert.CorrelationId = RqtMensAlert.RequestId;

            eMensajeAlerta CtrMenAlert = RqtMensAlert.CtrMenAlert as eMensajeAlerta;

            if (RqtMensAlert.LoadOptions.Contains("MensajeAlertaLista"))
            {
                IList<eMensajeAlerta> ListMensjAlert;
                eMensajeAlerta sMensajeAlerta = new eMensajeAlerta();

                sMensajeAlerta.EstMensAler = CtrMenAlert.EstMensAler;
                sMensajeAlerta.CodiOper = CtrMenAlert.CodiOper;
                sMensajeAlerta.CodiUsu = CtrMenAlert.CodiUsu;
                sMensajeAlerta.FechAler = CtrMenAlert.FechAler;
                sMensajeAlerta.FechAler2 = CtrMenAlert.FechAler2;

                ListMensjAlert = sListMensAlerDao.GetListMensajAlert(sMensajeAlerta);
                RpsMensjAlert.ListaAlerta = ListMensjAlert;
            }

            return RpsMensjAlert;
        }

#endregion

#region Class: Mesa Virtual

        public MesaVirtualResponse GetListMesaVirtual(MesaVirtualRequest RqtListMesVir)
        {
            MesaVirtualResponse RpsMVList = new MesaVirtualResponse();
            RpsMVList.CorrelationId = RqtListMesVir.RequestId;

            eMesaVirtual CtrMesaVir = RqtListMesVir.CtrMesaVir as eMesaVirtual;

            if (RqtListMesVir.LoadOptions.Contains("MesaVirtualLista"))
            {
                IList<eMesaVirtual> ListMesaVirtual;
                eMesaVirtual sMesaVirtual = new eMesaVirtual();

                sMesaVirtual.CodiUsu = CtrMesaVir.CodiUsu;
                sMesaVirtual.CodiOper = CtrMesaVir.CodiOper;
                sMesaVirtual.NumOper = CtrMesaVir.NumOper;

                ListMesaVirtual = sMesaVirtualDao.GetMesaVirtual(sMesaVirtual);
                RpsMVList.ListaMesaVirtual = ListMesaVirtual;
            }

            return RpsMVList;
        }

        public InsertMesaVResponse SetMesaVirtual(ref MesaVirtualRequest RqtListMesVir)
        {
            InsertMesaVResponse RpsMesaVirtual = new InsertMesaVResponse();
            RpsMesaVirtual.CorrelationId = RqtListMesVir.RequestId;

            eMesaVirtual CtrMesaVir = RqtListMesVir.CtrMesaVir as eMesaVirtual;

            if (RqtListMesVir.LoadOptions.Contains("MesaVirtualAdd"))
            {
                Int64 sIMesaVirtual = 0;
                eMesaVirtual sMesaVirtual = new eMesaVirtual();
                sMesaVirtual.Type = CtrMesaVir.Type;
                sMesaVirtual.CodiOper = CtrMesaVir.CodiOper;
                sMesaVirtual.Fecha = CtrMesaVir.Fecha;
                sMesaVirtual.FechaFin = CtrMesaVir.FechaFin;
                sMesaVirtual.Estado = CtrMesaVir.Estado;
                sMesaVirtual.Titulo = CtrMesaVir.Titulo;
                sMesaVirtual.Prioridad = CtrMesaVir.Prioridad;
                sMesaVirtual.Notifica = CtrMesaVir.Notifica;
                sMesaVirtual.DesMesaVir = CtrMesaVir.DesMesaVir;
                sMesaVirtual.Acceso = CtrMesaVir.Acceso;
                sMesaVirtual.ClaseMV = CtrMesaVir.ClaseMV;
                sMesaVirtual.NumOper = CtrMesaVir.NumOper;
                sMesaVirtual.CodiUsu = CtrMesaVir.CodiUsu;

                sIMesaVirtual = InserMesaVirtualDao.SetMesaVirtual(sMesaVirtual);

                if (sMesaVirtual.CodiOper > 0)
                {
                    RqtListMesVir.CtrMesaVir.CodiOper = sMesaVirtual.CodiOper;
                    RqtListMesVir.CtrMesaVir.NumOper = sMesaVirtual.NumOper;
                }

                RpsMesaVirtual.addMesaVirtual = sIMesaVirtual;
            }
            return RpsMesaVirtual;

        }

        public InsertMesaVResponse SetMesaComent(ref MesaVirtualRequest RqtComentVir)//comentario mesa virtual
        {
            InsertMesaVResponse RpsMVComent = new InsertMesaVResponse();
            RpsMVComent.CorrelationId = RqtComentVir.RequestId;

            eMesaVirtual CtrMesaVir = RqtComentVir.CtrMesaVir as eMesaVirtual;

            if (RqtComentVir.LoadOptions.Contains("MesaComentarioAdd"))
            {
                Int64 sIMesaVirtual = 0;
                eMesaVirtual sMesaVirtual = new eMesaVirtual();

                sMesaVirtual.Type = CtrMesaVir.Type;
                sMesaVirtual.CodiMesaComent = CtrMesaVir.CodiMesaComent;
                sMesaVirtual.Asunto = CtrMesaVir.Asunto;
                sMesaVirtual.Fecha = CtrMesaVir.Fecha;
                sMesaVirtual.Estado = CtrMesaVir.Estado;
                sMesaVirtual.CodiOper = CtrMesaVir.CodiOper;
                sMesaVirtual.CodiUsu = CtrMesaVir.CodiUsu;

                sIMesaVirtual = ComentMesaDao.SetComentMesa(sMesaVirtual);

                if (sMesaVirtual.CodiMesaComent > 0)
                    RqtComentVir.CtrMesaVir.CodiMesaComent = sMesaVirtual.CodiMesaComent;

                RpsMVComent.addMesaVirtual = sIMesaVirtual;
            }
            return RpsMVComent;
        }

        public MesaVirtualResponse GetListMesaComent(MesaVirtualRequest RqtListMesCom)
        {
            MesaVirtualResponse RpsMVCList = new MesaVirtualResponse();
            RpsMVCList.CorrelationId = RqtListMesCom.RequestId;

            eMesaVirtual CtrMesaVir = RqtListMesCom.CtrMesaVir as eMesaVirtual;

            if (RqtListMesCom.LoadOptions.Contains("MesaComentarioLista"))
            {
                IList<eMesaVirtual> ListMesaVirtualComen;
                eMesaVirtual sMesaVirtual = new eMesaVirtual();

                sMesaVirtual.CodiOper = CtrMesaVir.CodiOper;
                sMesaVirtual.CodiUsu = CtrMesaVir.CodiUsu;

                ListMesaVirtualComen = ConsComenMVDao.GetComenMesa(sMesaVirtual);
                RpsMVCList.ListaMesaVirtual = ListMesaVirtualComen;
            }

            return RpsMVCList;
        }
#endregion


    }
}
