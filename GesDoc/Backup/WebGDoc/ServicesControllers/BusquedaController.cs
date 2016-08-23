using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ServiceModel;
using WebGdoc.BusquedaServRef;
using Entity.Entities;


namespace WebGdoc.ServicesControllers
{
    public class BusquedaController : ControllerBase
    {
        //Usar esto para listar documentos digitales
        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<eBuscarDocumentos> GetDocumentosDigitales(eBuscarDocumentos oDocDig)
        {
            try
            {
                BuscarDocumentoRequest rqtDocDigitales = new BuscarDocumentoRequest();
                rqtDocDigitales.RequestId = NewRequestId;
                rqtDocDigitales.AccessToken = AccessToken;
                rqtDocDigitales.ClientTag = ClientTag;
                rqtDocDigitales.LoadOptions = new string[] { "TipoDocumentoDigital" };
                rqtDocDigitales.CtrDocDigTD = new eBuscarDocumentos
                {
                    
                    sDocDig = new eDocDig
                    {
                        AsunDocuDigi = oDocDig.sDocDig.AsunDocuDigi,
                        ClasDocu = oDocDig.sDocDig.ClasDocu,
                        FechRegi = oDocDig.sDocDig.FechRegi,
                    },
                    FecReg2 = oDocDig.FecReg2,
                    CodiUsuRem = oDocDig.CodiUsuRem,
                    CodiUsuDes = oDocDig.CodiUsuDes,
                    TipoBusq = oDocDig.TipoBusq,
                };
                BuscarDocumentoResponse response = BusquedaServiceClient.GetDocumentoDigital(rqtDocDigitales);

                if (rqtDocDigitales.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                return response.BListaDocDig;
            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<eBuscarDocumentos> GetDocumentosElectronicos(eBuscarDocumentos oDocElect)
        {
            try
            {
                BuscarDocumentoRequest rqtDocElectronicos = new BuscarDocumentoRequest();
                rqtDocElectronicos.RequestId = NewRequestId;
                rqtDocElectronicos.AccessToken = AccessToken;
                rqtDocElectronicos.ClientTag = ClientTag;
                rqtDocElectronicos.LoadOptions = new string[] { "TipoDocumentoElectronico" };
                rqtDocElectronicos.CtrDocDigTD = new eBuscarDocumentos 
                {
                    sDocElect = new eDocumentoElectronico
                    {
                        AsunDocuElec = oDocElect.sDocElect.AsunDocuElec,
                        CodiTipoDocu = oDocElect.sDocElect.CodiTipoDocu,
                        FechEmi = oDocElect.sDocElect.FechEmi,
                    },
                    FecReg2 = oDocElect.FecReg2,
                    CodiUsuRem = oDocElect.CodiUsuRem,
                    CodiUsuDes = oDocElect.CodiUsuDes,
                    TipoBusq = oDocElect.TipoBusq,
                };
                BuscarDocumentoResponse response = BusquedaServiceClient.GetDocumentoElectronico(rqtDocElectronicos);

                if (rqtDocElectronicos.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                return response.BListaDocElect;
            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<eBuscarDocumentos> GetMesaVirtual(eBuscarDocumentos oMesaVirtual)
        {
            try
            {
                BuscarDocumentoRequest rqtMesaVirtual = new BuscarDocumentoRequest();
                rqtMesaVirtual.RequestId = NewRequestId;
                rqtMesaVirtual.AccessToken = AccessToken;
                rqtMesaVirtual.ClientTag = ClientTag;
                rqtMesaVirtual.LoadOptions = new string[] { "TipoMesaVirtual" };
                rqtMesaVirtual.CtrDocDigTD = new eBuscarDocumentos
                {
                    sMesaVirtual = new eMesaVirtual
                    {
                        Asunto = oMesaVirtual.sMesaVirtual.Asunto,
                        ClaseMV = oMesaVirtual.sMesaVirtual.ClaseMV,
                        Fecha = oMesaVirtual.sMesaVirtual.Fecha,
                    },
                    FecReg2 = oMesaVirtual.FecReg2,
                    CodiUsuRem = oMesaVirtual.CodiUsuRem,
                    CodiUsuDes = oMesaVirtual.CodiUsuDes,
                    TipoBusq = oMesaVirtual.TipoBusq,
                };
                BuscarDocumentoResponse response = BusquedaServiceClient.GetMesaVirtual(rqtMesaVirtual);

                if (rqtMesaVirtual.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                return response.BListaMesaVirtual;
            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<eMesaVirtual> GetBandejaMV(eMesaVirtual oMesVirt)
        {
            try
            {
                MesaVirtualRequest rqtMesVirt = new MesaVirtualRequest();
                rqtMesVirt.RequestId = NewRequestId;
                rqtMesVirt.AccessToken = AccessToken;
                rqtMesVirt.ClientTag = ClientTag;
                rqtMesVirt.LoadOptions = new string[] { "BandejaMVLista" };
                rqtMesVirt.CtrMesaVir = new eMesaVirtual
                {
                    Type = oMesVirt.Type,
                    CodiUsu = oMesVirt.CodiUsu,
                    TipoPart = oMesVirt.TipoPart,
                    Estado = oMesVirt.Estado,
                    ClaseMV = oMesVirt.ClaseMV,
                    Asunto = oMesVirt.Asunto,
                    Periodo = oMesVirt.Periodo,
                    Fecha = oMesVirt.Fecha,
                    Prioridad = oMesVirt.Prioridad
                };

                MesaVirtualResponse response = BusquedaServiceClient.GetBandejaMV(rqtMesVirt);

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

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<eOperaciones> GetBandejaDoc(eOperaciones oOperCrit)
        {
            try
            {
                OperacionRequest rqtBandejaDoc = new OperacionRequest();
                rqtBandejaDoc.RequestId = NewRequestId;
                rqtBandejaDoc.AccessToken = AccessToken;
                rqtBandejaDoc.ClientTag = ClientTag;
                rqtBandejaDoc.LoadOptions = new string[] { "BandejaDocList" };
                rqtBandejaDoc.CtrOper = new eOperaciones
                {
                    Type = oOperCrit.Type,
                    CodUsu = oOperCrit.CodUsu,
                    Fecha = oOperCrit.Fecha,
                    TipoPart = oOperCrit.TipoPart,
                    TipoComu = oOperCrit.TipoComu,
                    TipoOper = oOperCrit.TipoOper,
                    AsunOper = oOperCrit.AsunOper,
                    PrioDoc = oOperCrit.PrioDoc,
                    Periodo = oOperCrit.Periodo,
                    NumOper = oOperCrit.NumOper
                };

                OperacionResponse response = BusquedaServiceClient.GetBandejaDoc(rqtBandejaDoc);

                if (rqtBandejaDoc.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                return response.OperacionLista;
            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }

        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<eBuscarLogOperacion> GetLogOper(eBuscarLogOperacion oLogCrit)
        {
            try
            {
                BuscarLogOperRequest rqtLogOper = new BuscarLogOperRequest();
                rqtLogOper.RequestId = NewRequestId;
                rqtLogOper.AccessToken = AccessToken;
                rqtLogOper.ClientTag = ClientTag;
                rqtLogOper.LoadOptions = new string[] { "BuscarLogOper" };
                rqtLogOper.CtrBLogOper = new eBuscarLogOperacion
                {
                    TipoBusq = oLogCrit.TipoBusq,
                    NumDocu = oLogCrit.NumDocu
                };

                BuscarLogOperResponse response = BusquedaServiceClient.GetBuscarLogOper(rqtLogOper);

                if (rqtLogOper.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                return response.BListaLogOper;
            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }

        }



        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<eMesaVirtual> GetTipoMV(eMesaVirtual oMesVirt)
        {
            try
            {
                MesaVirtualRequest rqtMesVirt = new MesaVirtualRequest();
                rqtMesVirt.RequestId = NewRequestId;
                rqtMesVirt.AccessToken = AccessToken;
                rqtMesVirt.ClientTag = ClientTag;
                rqtMesVirt.LoadOptions = new string[] { "TipoMesa" };
                rqtMesVirt.CtrMesaVir = new eMesaVirtual
                {
                    Estado = oMesVirt.Estado
                };

                MesaVirtualResponse response = BusquedaServiceClient.GetTipoMesaVirtual(rqtMesVirt);

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

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<eBuscarDocumentos> GetDocumentoAdjunto(eBuscarDocumentos oDocAdj)
        {
            try
            {
                BuscarDocumentoRequest rqtDocAdjunto = new BuscarDocumentoRequest();
                rqtDocAdjunto.RequestId = NewRequestId;
                rqtDocAdjunto.AccessToken = AccessToken;
                rqtDocAdjunto.ClientTag = ClientTag;
                rqtDocAdjunto.LoadOptions = new string[] { "TipoDocumentoAdjunto" };
                rqtDocAdjunto.CtrDocDigTD = new eBuscarDocumentos
                {
                    TipoBusq = oDocAdj.TipoBusq,
                    
                    sDocDig = new eDocDig
                    {
                        CodiDocuDigi = oDocAdj.sDocDig.CodiDocuDigi,
                        NumDocuDigi = oDocAdj.sDocDig.NumDocuDigi,
                        CodiTipoDocu = oDocAdj.sDocDig.CodiTipoDocu,
                        TituDocuDigi = oDocAdj.sDocDig.TituDocuDigi,
                        AsunDocuDigi = oDocAdj.sDocDig.AsunDocuDigi,
                        NombOrig = oDocAdj.sDocDig.NombOrig,
                        NombFisi = oDocAdj.sDocDig.NombFisi
                    },
                };
                BuscarDocumentoResponse response = BusquedaServiceClient.GetDocumentoAdjunto(rqtDocAdjunto);

                if (rqtDocAdjunto.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                return response.BListaDocumentoAdjunto;
            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<eUbigeo> GetUbigeo(eUbigeo oUbigeo)
        {
            try
            {
                UbigeoRequest rqtUbigeo = new UbigeoRequest();
                rqtUbigeo.RequestId = NewRequestId;
                rqtUbigeo.AccessToken = AccessToken;
                rqtUbigeo.ClientTag = ClientTag;
                rqtUbigeo.LoadOptions = new string[] { "UbigeoList" };
                rqtUbigeo.CtrUbigeo = new eUbigeo
                {
                    TipoCod = oUbigeo.TipoCod,
                    Cod_Dpto = oUbigeo.Cod_Dpto,
                    Cod_Prov = oUbigeo.Cod_Prov
                };
                UbigeoResponse response = BusquedaServiceClient.GetUbigeo(rqtUbigeo);

                if (rqtUbigeo.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                return response.ListaUbigeo;
            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }
        }
    }
}
