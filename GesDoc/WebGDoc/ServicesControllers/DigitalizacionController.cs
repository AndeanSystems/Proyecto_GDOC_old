using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ServiceModel;
using WebGdoc.DigitalizacionServRef;
using Entity.Entities;

namespace WebGdoc.ServicesControllers
{
    public class DigitalizacionController : ControllerBase
    {
#region Class: Documento Digital

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public Int64 SetAddDocumentosDigitales(eDocDig oDocDig)
        {
            try
            {
                DocDigRequest rqtDocDig = new DocDigRequest();
                rqtDocDig.RequestId = NewRequestId;
                rqtDocDig.AccessToken = AccessToken;
                rqtDocDig.ClientTag = ClientTag;

                rqtDocDig.LoadOptions = new string[] { "DocDigAdd" };
                rqtDocDig.CtrDocDig = new eDocDig
                {
                    CodiDocuDigi = oDocDig.CodiDocuDigi,
                    Type = oDocDig.Type,
                    TituDocuDigi = oDocDig.TituDocuDigi,
                    AsunDocuDigi = oDocDig.AsunDocuDigi,
                    NombOrig = oDocDig.NombOrig,
                    RutaFisi = oDocDig.RutaFisi,
                    TamaDocu = oDocDig.TamaDocu,
                    ExteDocu = oDocDig.ExteDocu,
                    NombFisi = oDocDig.NombFisi,
                    ClasDocu = oDocDig.ClasDocu,
                    EstDocuDigi = oDocDig.EstDocuDigi,
                    FechEmiDocu = oDocDig.FechEmiDocu,
                    FechRece = oDocDig.FechRece,
                    FechRegi = oDocDig.FechRegi,
                    FechActu = oDocDig.FechActu,
                    AcceDocuDigi = oDocDig.AcceDocuDigi,
                    CodiTipoDocu = oDocDig.CodiTipoDocu,
                    NumDocuDigi = oDocDig.NumDocuDigi,
                    CodUsu = oDocDig.CodUsu,
                    Comentario = oDocDig.Comentario
                };

                DocDigResponse response = DigitalizacionServiceClient.SetDocDigAdd(ref rqtDocDig);

                if (rqtDocDig.CtrDocDig.CodiDocuDigi > 0)
                {
                    oDocDig.CodiDocuDigi = rqtDocDig.CtrDocDig.CodiDocuDigi;
                    oDocDig.NumDocuDigi = rqtDocDig.CtrDocDig.NumDocuDigi;
                }

                if (rqtDocDig.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                return response.AddDocDig;
            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<eDocDigListTD> GetTipoDocumDigital(eDocDigListTD oDocDigTD)
        {
            try
            {
                DocDigDTRequest rqtDocDigTD = new DocDigDTRequest();
                rqtDocDigTD.RequestId = NewRequestId;
                rqtDocDigTD.AccessToken = AccessToken;
                rqtDocDigTD.ClientTag = ClientTag;
                rqtDocDigTD.LoadOptions = new string[] { "DogDigLista" };
                rqtDocDigTD.CtrDocDigTD = new eDocDigListTD
                {
                    EstTipoDocumento = oDocDigTD.EstTipoDocumento
                };
                
                DocDigDTResponse responseTD = DigitalizacionServiceClient.GetListaTipoDoc(rqtDocDigTD);

                if(rqtDocDigTD.RequestId != responseTD.CorrelationId)
                    throw new ApplicationException("Error");

                return responseTD.ListaDogDig;

            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                message += ex.Message;
                throw new FaultException(message);
            
            }



        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public Int64 SetAddDocumentosAdjunto(eDocAdj oDocAdj)
        {
            try
            {
                DocAdjRequest rqtDocAdj = new DocAdjRequest();
                rqtDocAdj.RequestId = NewRequestId;
                rqtDocAdj.AccessToken = AccessToken;
                rqtDocAdj.ClientTag = ClientTag;

                rqtDocAdj.LoadOptions = new string[] { "DocAdjAdd" };
                rqtDocAdj.CtrDocAdj = new eDocAdj
                {
                    //Type = oDocAdj.Type,
                    CodiAdj = oDocAdj.CodiAdj,
                    CodiOper = oDocAdj.CodiOper,
                    //CodiTipoDocu = oDocAdj.CodiTipoDocu,
                    TipoOper = oDocAdj.TipoOper,
                    CodiDocAdju = oDocAdj.CodiDocAdju,
                    TipoDocAdju = oDocAdj.TipoDocAdju,
                    CodiComenMesaV = oDocAdj.CodiComenMesaV,
                    EstDocuAdju = oDocAdj.EstDocuAdju
                };

                DocAdjResponse response = DigitalizacionServiceClient.SetDocAdj(rqtDocAdj);

                if (rqtDocAdj.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                return response.AddDocAdj;
            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<eDocAdj> GetDocumentosAdjunto(eDocAdj oDocAdj)
        {
            try
            {
                DocAdjRequest rqtDocAdj = new DocAdjRequest();
                rqtDocAdj.RequestId = NewRequestId;
                rqtDocAdj.AccessToken = AccessToken;
                rqtDocAdj.ClientTag = ClientTag;

                rqtDocAdj.LoadOptions = new string[] { "DocAdjList" };
                rqtDocAdj.CtrDocAdj = new eDocAdj
                {
                    
                    CodiOper = oDocAdj.CodiOper,
                    CodiComenMesaV = oDocAdj.CodiComenMesaV   
                };

                LDocAdjResponse response = DigitalizacionServiceClient.GetDocAdj(rqtDocAdj);

                if (rqtDocAdj.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                return response.ListAdj;
            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public Int64 SetAnulaDocumentosAdjunto(eDocAdj oDocAdj)
        {
            try
            {
                DocAdjRequest rqtDocAdj = new DocAdjRequest();
                rqtDocAdj.RequestId = NewRequestId;
                rqtDocAdj.AccessToken = AccessToken;
                rqtDocAdj.ClientTag = ClientTag;

                rqtDocAdj.LoadOptions = new string[] { "DocAdjAnula" };
                rqtDocAdj.CtrDocAdj = new eDocAdj
                {
                   
                    CodiOper = oDocAdj.CodiOper,      
                    CodiComenMesaV = oDocAdj.CodiComenMesaV
                    
                };

                DocAdjResponse response = DigitalizacionServiceClient.SetAnulaDocAdj(rqtDocAdj);

                if (rqtDocAdj.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                return response.AddDocAdj;
            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }
        }
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public Int64 SetAddDocDigRef(eDocDigRef oDocDigRef)
        {
            try
            {
                DocDigRefRequest rqtDocDig = new DocDigRefRequest();
                rqtDocDig.RequestId = NewRequestId;
                rqtDocDig.AccessToken = AccessToken;
                rqtDocDig.ClientTag = ClientTag;

                rqtDocDig.LoadOptions = new string[] { "DocDigRefAdd" };
                rqtDocDig.CtrDocDigRef = new eDocDigRef
                {
                    CodiInde = oDocDigRef.CodiInde,
                     Type = oDocDigRef.Type,
                    DescInde = oDocDigRef.DescInde,
                    EstaInde = oDocDigRef.EstaInde,
                    CodiOper = oDocDigRef.CodiOper,
                    TipoOper = oDocDigRef.TipoOper
                };

                DocDigRefResponse response = DigitalizacionServiceClient.SetDocDigRefAdd(rqtDocDig);


                if (rqtDocDig.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                return response.AddDocDigRef;
            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }
        }


        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<eDocDigRef> GetDocDigRef(eDocDigRef oDocDigRef)
        {
            try
            {

                DocDigRefRequest rqtDocDigRef = new DocDigRefRequest();
                rqtDocDigRef.RequestId = NewRequestId;
                rqtDocDigRef.AccessToken = AccessToken;
                rqtDocDigRef.ClientTag = ClientTag;
                rqtDocDigRef.LoadOptions = new string[] { "DogDigRefLista" };
                rqtDocDigRef.CtrDocDigRef = new eDocDigRef
                {
                    EstaInde = oDocDigRef.EstaInde,
                    CodiOper = oDocDigRef.CodiOper
                };

                LDocDigRefResponse response = DigitalizacionServiceClient.GetDocDigRef(rqtDocDigRef);

                if (rqtDocDigRef.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                return response.ListaRefDigital;

            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);

            }
        }


        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<eDocDig> GetDocDigital(eDocDig oDocDig)
        {
            try
            {
                DocDigRequest rqtDocDigi = new DocDigRequest();
                rqtDocDigi.RequestId = NewRequestId;
                rqtDocDigi.AccessToken = AccessToken;
                rqtDocDigi.ClientTag = ClientTag;
                rqtDocDigi.LoadOptions = new string[] { "ListaDocDig" };
                rqtDocDigi.CtrDocDig = new eDocDig
                {
                    EstDocuDigi = oDocDig.EstDocuDigi,
                    CodiDocuDigi = oDocDig.CodiDocuDigi,
                    NumDocuDigi = oDocDig.NumDocuDigi,
                    User = new eUsuario
                    {
                        Codigo = oDocDig.User.Codigo
                    }
                };

                LDocDigResponse response = DigitalizacionServiceClient.GetDocDigital(rqtDocDigi);

                if (rqtDocDigi.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                return response.ListaDocDig;
            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }
        }

#endregion
        
#region Class: Documento Electronico

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public Int64 SetEnviarDocumentoElectronico(eDocumentoElectronico oDocumentoElectronico)
        {
            try
            {
                DocumentoElectronicoRequest rqtDocumentoElectronico = new DocumentoElectronicoRequest();
                rqtDocumentoElectronico.RequestId = NewRequestId;
                rqtDocumentoElectronico.AccessToken = AccessToken;
                rqtDocumentoElectronico.ClientTag = ClientTag;

                rqtDocumentoElectronico.LoadOptions = new string[] { "DocumentoElectronicoEnviar" };
                rqtDocumentoElectronico.CtrDocumentoElectronico = new eDocumentoElectronico
                {
                    CodiOper = oDocumentoElectronico.CodiOper,
                    CodiDocuElec = oDocumentoElectronico.CodiDocuElec,
                    Type = oDocumentoElectronico.Type,
                    TipoComu = oDocumentoElectronico.TipoComu,
                    AsunDocuElec = oDocumentoElectronico.AsunDocuElec,
                    FechEmi = oDocumentoElectronico.FechEmi,
                    FechEnvi = oDocumentoElectronico.FechEnvi,
                    PrioDocuElec = oDocumentoElectronico.PrioDocuElec,
                    MensDocuElec = oDocumentoElectronico.MensDocuElec,
                    FechVige = oDocumentoElectronico.FechVige,
                    EstDocuElec = oDocumentoElectronico.EstDocuElec,
                    CateDocuElec = oDocumentoElectronico.CateDocuElec,
                    FechCie = oDocumentoElectronico.FechCie,
                    TipoAcc = oDocumentoElectronico.TipoAcc,
                    CodiTipoDocu = oDocumentoElectronico.CodiTipoDocu,
                    NumDocuElec = oDocumentoElectronico.NumDocuElec,
                    CodUsu = oDocumentoElectronico.CodUsu,
                    Memo = oDocumentoElectronico.Memo
                };
                //prueba
                DocumentoElectronicoResponse response = DigitalizacionServiceClient.SetDocumentoElectronicoEnviar(ref rqtDocumentoElectronico);

                if (rqtDocumentoElectronico.CtrDocumentoElectronico.CodiOper > 0)
                {
                    oDocumentoElectronico.CodiOper = rqtDocumentoElectronico.CtrDocumentoElectronico.CodiOper;
                    oDocumentoElectronico.NumDocuElec = rqtDocumentoElectronico.CtrDocumentoElectronico.NumDocuElec;
                }
                if (rqtDocumentoElectronico.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                return response.EnviarDocumentoElectronico;
            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<eDocumentoElectronico> GetDocEle(eDocumentoElectronico oDocElect)
        {

            try
            {
                DocumentoElectronicoRequest rqtDocElect = new DocumentoElectronicoRequest();
                rqtDocElect.RequestId = NewRequestId;
                rqtDocElect.AccessToken = AccessToken;
                rqtDocElect.ClientTag = ClientTag;
                rqtDocElect.LoadOptions = new string[] { "ListaDocElec" };
                rqtDocElect.CtrDocumentoElectronico = new eDocumentoElectronico
                {
                    EstDocuElec = oDocElect.EstDocuElec,
                    CodiOper = oDocElect.CodiOper,
                    NumDocuElec = oDocElect.NumDocuElec,
                    User = new eUsuario
                    {
                        Codigo = oDocElect.User.Codigo
                    }

                };

                LDocElecResponse response = DigitalizacionServiceClient.GetDocElec(rqtDocElect);

                if (rqtDocElect.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                return response.ListaDocElecttonico;
            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }

        }

#endregion



        [DataObjectMethod(DataObjectMethodType.Insert)]
        public Int64 SetLogOperacion(eLogOperacion oLogOperacion)
        {
            try
            {
                LogOperacionRequest RqtLogOperacion = new LogOperacionRequest();

                RqtLogOperacion.RequestId = NewRequestId;
                RqtLogOperacion.AccessToken = AccessToken;
                RqtLogOperacion.ClientTag = ClientTag;
                RqtLogOperacion.LoadOptions = new string[] { "LogOperacionAdd" };
                RqtLogOperacion.CtrLogOper = new eLogOperacion
                {
                    Type = oLogOperacion.Type,
                    CodiLogOper = oLogOperacion.CodiLogOper,
                    FechEven = oLogOperacion.FechEven,
                    TipoOper = oLogOperacion.TipoOper,
                    CodiOper = oLogOperacion.CodiOper,
                    CodiEven = oLogOperacion.CodiEven,
                    CodiUsu = oLogOperacion.CodiUsu,
                    CodiCnx = oLogOperacion.CodiCnx
                };
                LogOperacionResponse response = DigitalizacionServiceClient.SetLogOperacion(RqtLogOperacion);

                if (RqtLogOperacion.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                return response.AddLogOperacion;

            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }

        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public Int64 SetMensajeAlerta(eMensajeAlerta oMensajeAlerta)
        {
            try
            {
                MensajeAlertaRequest RqtMensajeAlerta = new MensajeAlertaRequest();

                RqtMensajeAlerta.RequestId = NewRequestId;
                RqtMensajeAlerta.AccessToken = AccessToken;
                RqtMensajeAlerta.ClientTag = ClientTag;
                RqtMensajeAlerta.LoadOptions = new string[] { "MensajeAlertaAdd" };
                RqtMensajeAlerta.CtrMenAlert = new eMensajeAlerta
                {
                    Type = oMensajeAlerta.Type,
                    CodiOper = oMensajeAlerta.CodiOper,
                    TipoOper = oMensajeAlerta.TipoOper,
                    FechAler = oMensajeAlerta.FechAler,
                    TipoAler = oMensajeAlerta.TipoAler,
                    CodiEven = oMensajeAlerta.CodiEven,
                    EstMensAler = oMensajeAlerta.EstMensAler,
                    CodiUsu = oMensajeAlerta.CodiUsu
                };

                MensajeAlertaResponse response = DigitalizacionServiceClient.SetMensajeAlerta(RqtMensajeAlerta);

                if (RqtMensajeAlerta.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                return response.AddMensajeAlerta;

            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<eMensajeAlerta> GetMensajAlerta(eMensajeAlerta oMensajeAlerta)
        {

            try
            {
                MensajeAlertaRequest rqtMensajAlert = new MensajeAlertaRequest();
                rqtMensajAlert.RequestId = NewRequestId;
                rqtMensajAlert.AccessToken = AccessToken;
                rqtMensajAlert.ClientTag = ClientTag;
                rqtMensajAlert.LoadOptions = new string[] { "MensajeAlertaLista" };
                rqtMensajAlert.CtrMenAlert = new eMensajeAlerta
                {
                    EstMensAler = oMensajeAlerta.EstMensAler,
                    CodiOper = oMensajeAlerta.CodiOper,
                    CodiUsu = oMensajeAlerta.CodiUsu,
                    FechAler = oMensajeAlerta.FechAler,
                    FechAler2 = oMensajeAlerta.FechAler2
                };

                LMensajeAlertaResponse response = DigitalizacionServiceClient.GetMensajAlerta(rqtMensajAlert);

                if (rqtMensajAlert.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                return response.ListaAlerta;
            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }

        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public Int64 SetMesaVirtual(eMesaVirtual oMesaVirtual)
        {
            try
            {
                MesaVirtualRequest RqtMesaVirt = new MesaVirtualRequest();
                RqtMesaVirt.RequestId = NewRequestId;
                RqtMesaVirt.AccessToken = AccessToken;
                RqtMesaVirt.ClientTag = ClientTag;
                RqtMesaVirt.LoadOptions = new string[] { "MesaVirtualAdd" };
                RqtMesaVirt.CtrMesaVir = new eMesaVirtual
                {
                    Type = oMesaVirtual.Type,
                    Fecha = oMesaVirtual.Fecha,
                    FechaFin = oMesaVirtual.FechaFin,
                    Estado = oMesaVirtual.Estado,
                    Titulo = oMesaVirtual.Titulo,
                    Prioridad = oMesaVirtual.Prioridad,
                    Notifica = oMesaVirtual.Notifica,
                    DesMesaVir = oMesaVirtual.DesMesaVir,
                    Acceso = oMesaVirtual.Acceso,
                    ClaseMV = oMesaVirtual.ClaseMV,
                    NumOper = oMesaVirtual.NumOper,
                    CodiUsu = oMesaVirtual.CodiUsu
                };

                InsertMesaVResponse response = DigitalizacionServiceClient.SetMesaVirtual(ref RqtMesaVirt);

                if (RqtMesaVirt.CtrMesaVir.CodiOper > 0)
                {
                    oMesaVirtual.CodiOper = RqtMesaVirt.CtrMesaVir.CodiOper;
                    oMesaVirtual.NumOper = RqtMesaVirt.CtrMesaVir.NumOper;
                }

                if (RqtMesaVirt.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                return response.addMesaVirtual;
            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<eMesaVirtual> GetMesaVirtual(eMesaVirtual oMesVirt)
        {
            try
            {
                MesaVirtualRequest rqtMesVirt = new MesaVirtualRequest();
                rqtMesVirt.RequestId = NewRequestId;
                rqtMesVirt.AccessToken = AccessToken;
                rqtMesVirt.ClientTag = ClientTag;
                rqtMesVirt.LoadOptions = new string[] { "MesaVirtualLista" };
                rqtMesVirt.CtrMesaVir = new eMesaVirtual
                {
                    CodiUsu = oMesVirt.CodiUsu,
                    CodiOper = oMesVirt.CodiOper,
                    NumOper = oMesVirt.NumOper
                };

                MesaVirtualResponse response = DigitalizacionServiceClient.GetListMesaVirtual(rqtMesVirt);

                if (rqtMesVirt.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                return response.ListaMesaVirtual;
            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }

        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public Int64 SetMesaComentario(eMesaVirtual oMesaVirtual)
        {
            try
            {
                MesaVirtualRequest RqtMesaComent = new MesaVirtualRequest();
                RqtMesaComent.RequestId = NewRequestId;
                RqtMesaComent.AccessToken = AccessToken;
                RqtMesaComent.ClientTag = ClientTag;
                RqtMesaComent.LoadOptions = new string[] { "MesaComentarioAdd" };
                RqtMesaComent.CtrMesaVir = new eMesaVirtual
                {
                    Type = oMesaVirtual.Type,
                    CodiMesaComent = oMesaVirtual.CodiMesaComent,
                    Asunto = oMesaVirtual.Asunto,
                    Fecha = oMesaVirtual.Fecha,
                    Estado = oMesaVirtual.Estado,
                    CodiOper = oMesaVirtual.CodiOper,
                    CodiUsu = oMesaVirtual.CodiUsu
                };

                InsertMesaVResponse response = DigitalizacionServiceClient.SetMesaComent(ref RqtMesaComent);

                if (RqtMesaComent.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                if (RqtMesaComent.CtrMesaVir.CodiOper > 0)
                    oMesaVirtual.CodiMesaComent = RqtMesaComent.CtrMesaVir.CodiMesaComent;

                return response.addMesaVirtual;
            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<eMesaVirtual> GetMesaComentario(eMesaVirtual oMesVirt)
        {
            try
            {
                MesaVirtualRequest rqtMesComent = new MesaVirtualRequest();
                rqtMesComent.RequestId = NewRequestId;
                rqtMesComent.AccessToken = AccessToken;
                rqtMesComent.ClientTag = ClientTag;
                rqtMesComent.LoadOptions = new string[] { "MesaComentarioLista" };
                rqtMesComent.CtrMesaVir = new eMesaVirtual
                {
                    CodiOper = oMesVirt.CodiOper,
                    CodiUsu = oMesVirt.CodiUsu
                    
                };

                MesaVirtualResponse response = DigitalizacionServiceClient.GetListMesaComent(rqtMesComent);

                if (rqtMesComent.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                return response.ListaMesaVirtual;
            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }

        }



    }
}
