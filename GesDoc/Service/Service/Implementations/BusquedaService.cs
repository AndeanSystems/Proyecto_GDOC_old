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
    public class BusquedaService : IBusquedaService
    {
        private static bBuscarDocumentos sBuscarDocumento = new bBuscarDocumentos();
        private static bBandejaMV sBandejaMVDao = new bBandejaMV();
        private static bBandeja sBandejaDao = new bBandeja();
        private static bTipoMesaVirtual sTipoMesaVirtualDao = new bTipoMesaVirtual();
        private static bBuscarLogOperacion sLogOperDao = new bBuscarLogOperacion();
        private static bUbigeo sUbigeoDao = new bUbigeo();


#region Lista : Busqueda de Documentos Digitales

        public BuscarDocumentoResponse GetDocumentoDigital(BuscarDocumentoRequest RqtDocDig)
        {
            BuscarDocumentoResponse RpsDocumentoDigital = new BuscarDocumentoResponse();
            RpsDocumentoDigital.CorrelationId = RqtDocDig.RequestId;

            eBuscarDocumentos CtrDocumentoDigital = RqtDocDig.CtrDocDigTD as eBuscarDocumentos;

            if (RqtDocDig.LoadOptions.Contains("TipoDocumentoDigital"))
            {
                IList<eBuscarDocumentos> ListaDocumentoDigital;
                eBuscarDocumentos BDocumentoDig = new eBuscarDocumentos()
                {
                    sDocDig = new eDocDig
                    {
                        AsunDocuDigi = CtrDocumentoDigital.sDocDig.AsunDocuDigi,
                        ClasDocu = CtrDocumentoDigital.sDocDig.ClasDocu,
                        FechRegi = CtrDocumentoDigital.sDocDig.FechRegi,
                        
                    },
                    FecReg2 = CtrDocumentoDigital.FecReg2,
                    CodiUsuRem = CtrDocumentoDigital.CodiUsuRem,
                    CodiUsuDes = CtrDocumentoDigital.CodiUsuDes,
                    TipoBusq = CtrDocumentoDigital.TipoBusq,
                };
                ListaDocumentoDigital = sBuscarDocumento.GetBusDocDig(BDocumentoDig);
                RpsDocumentoDigital.BListaDocDig = ListaDocumentoDigital;
            }
            return RpsDocumentoDigital;
        }

#endregion


#region Lista : Busqueda de Documentos Electronicos

        public BuscarDocumentoResponse GetDocumentoElectronico(BuscarDocumentoRequest RqtDocElect)
        {
            BuscarDocumentoResponse RpsDocumentoElectronico = new BuscarDocumentoResponse();
            RpsDocumentoElectronico.CorrelationId = RqtDocElect.RequestId;
            eBuscarDocumentos CtrDocumentoElectronico = RqtDocElect.CtrDocDigTD as eBuscarDocumentos;
            if (RqtDocElect.LoadOptions.Contains("TipoDocumentoElectronico"))
            {
                IList<eBuscarDocumentos> ListaDocumentoElectronico;
                eBuscarDocumentos BDocumentoElect = new eBuscarDocumentos()
                {
                    sDocElect = new eDocumentoElectronico
                    {
                        AsunDocuElec = CtrDocumentoElectronico.sDocElect.AsunDocuElec,
                        CodiTipoDocu = CtrDocumentoElectronico.sDocElect.CodiTipoDocu,
                        FechEmi = CtrDocumentoElectronico.sDocElect.FechEmi,
                    },
                    FecReg2 = CtrDocumentoElectronico.FecReg2,
                    CodiUsuRem = CtrDocumentoElectronico.CodiUsuRem,
                    CodiUsuDes = CtrDocumentoElectronico.CodiUsuDes,
                    TipoBusq = CtrDocumentoElectronico.TipoBusq,
                };
                ListaDocumentoElectronico = sBuscarDocumento.GetBusDocElect(BDocumentoElect);
                RpsDocumentoElectronico.BListaDocElect = ListaDocumentoElectronico;
            }
            return RpsDocumentoElectronico;
        }

#endregion


#region Lista : Busqueda de Mesas Virtuales

        public BuscarDocumentoResponse GetMesaVirtual(BuscarDocumentoRequest RqtMesaVirtual)
        {
            BuscarDocumentoResponse RpsMesaVirtual = new BuscarDocumentoResponse();
            RpsMesaVirtual.CorrelationId = RqtMesaVirtual.RequestId;
            eBuscarDocumentos CtrMesaVirtual = RqtMesaVirtual.CtrDocDigTD as eBuscarDocumentos;
            if (RqtMesaVirtual.LoadOptions.Contains("TipoMesaVirtual"))
            {
                IList<eBuscarDocumentos> ListaMesaVirtual;
                eBuscarDocumentos BMesaVirtual = new eBuscarDocumentos()
                {
                    sMesaVirtual = new eMesaVirtual
                    {
                        Asunto  = CtrMesaVirtual.sMesaVirtual.Asunto ,
                        ClaseMV = CtrMesaVirtual.sMesaVirtual.ClaseMV,
                        Fecha = CtrMesaVirtual.sMesaVirtual.Fecha,
                    },
                    FecReg2 = CtrMesaVirtual.FecReg2,
                    CodiUsuRem = CtrMesaVirtual.CodiUsuRem,
                    CodiUsuDes = CtrMesaVirtual.CodiUsuDes,
                    TipoBusq = CtrMesaVirtual.TipoBusq,
                };
                ListaMesaVirtual = sBuscarDocumento.GetBusMesaVirtual(BMesaVirtual);
                RpsMesaVirtual.BListaMesaVirtual = ListaMesaVirtual;
            }
            return RpsMesaVirtual;
        }

#endregion


#region Lista : Busqueda en Bandeja Mesa Virtual

        public MesaVirtualResponse GetBandejaMV(MesaVirtualRequest RqtListMesVir)
        {
            MesaVirtualResponse RpsMVList = new MesaVirtualResponse();
            RpsMVList.CorrelationId = RqtListMesVir.RequestId;

            eMesaVirtual CtrMesaVir = RqtListMesVir.CtrMesaVir as eMesaVirtual;

            if (RqtListMesVir.LoadOptions.Contains("BandejaMVLista"))
            {
                IList<eMesaVirtual> ListBandejaMV;
                eMesaVirtual sMesaVirtual = new eMesaVirtual();

                sMesaVirtual.Type = CtrMesaVir.Type;
                sMesaVirtual.CodiUsu = CtrMesaVir.CodiUsu;
                sMesaVirtual.TipoPart = CtrMesaVir.TipoPart;
                sMesaVirtual.Estado = CtrMesaVir.Estado;
                sMesaVirtual.ClaseMV = CtrMesaVir.ClaseMV;
                sMesaVirtual.Asunto = CtrMesaVir.Asunto;
                sMesaVirtual.Periodo = CtrMesaVir.Periodo;
                sMesaVirtual.Fecha = CtrMesaVir.Fecha;
                sMesaVirtual.Prioridad = CtrMesaVir.Prioridad;

                ListBandejaMV = sBandejaMVDao.GetBandejaMV(sMesaVirtual);
                RpsMVList.ListaMesaVirtual = ListBandejaMV;
            }
            return RpsMVList;
        }

#endregion


#region Lista : Busqueda en Bandeja Documento Electronico

        public OperacionResponse GetBandejaDoc(OperacionRequest RqtListOper)
        {
            OperacionResponse RpsOperList = new OperacionResponse();
            RpsOperList.CorrelationId = RqtListOper.RequestId;

            eOperaciones CtrBandeja = RqtListOper.CtrOper as eOperaciones;

            if (RqtListOper.LoadOptions.Contains("BandejaDocList"))
            {
                IList<eOperaciones> ListOper;
                eOperaciones sOperacion = new eOperaciones();

                sOperacion.Type = CtrBandeja.Type;
                sOperacion.CodUsu = CtrBandeja.CodUsu;
                sOperacion.Fecha = CtrBandeja.Fecha;
                sOperacion.TipoPart = CtrBandeja.TipoPart;
                sOperacion.TipoComu = CtrBandeja.TipoComu;
                sOperacion.TipoOper = CtrBandeja.TipoOper;
                sOperacion.AsunOper = CtrBandeja.AsunOper;
                sOperacion.PrioDoc = CtrBandeja.PrioDoc;
                sOperacion.Periodo = CtrBandeja.Periodo;
                sOperacion.NumOper = CtrBandeja.NumOper;

                ListOper = sBandejaDao.GetBandejaDoc(sOperacion);
                RpsOperList.OperacionLista = ListOper;
            }

            return RpsOperList;
        }

 #endregion       

        public MesaVirtualResponse GetTipoMesaVirtual(MesaVirtualRequest RqtMesaVirtual)
        {
            MesaVirtualResponse RpsMVList = new MesaVirtualResponse();
            RpsMVList.CorrelationId = RqtMesaVirtual.RequestId;

            eMesaVirtual CtrMesaVir = RqtMesaVirtual.CtrMesaVir as eMesaVirtual;

            if (RqtMesaVirtual.LoadOptions.Contains("TipoMesa"))
            {
                IList<eMesaVirtual> ListTipoMV;
                eMesaVirtual sMesaVirtual = new eMesaVirtual();

                sMesaVirtual.Estado = CtrMesaVir.Estado;

                ListTipoMV = sTipoMesaVirtualDao.GetTipoMV(sMesaVirtual);
                RpsMVList.ListaMesaVirtual = ListTipoMV;
            }
            return RpsMVList;
        }


        public BuscarLogOperResponse GetBuscarLogOper(BuscarLogOperRequest RqtLogOper)
        {
            BuscarLogOperResponse RpsLogOper = new BuscarLogOperResponse();
            RpsLogOper.CorrelationId = RqtLogOper.RequestId;

            eBuscarLogOperacion CtrLogOper = RqtLogOper.CtrBLogOper as eBuscarLogOperacion;

            if (RqtLogOper.LoadOptions.Contains("BuscarLogOper"))
            {
                IList<eBuscarLogOperacion> ListLogOpe;
                eBuscarLogOperacion sLogOper = new eBuscarLogOperacion();

                sLogOper.TipoBusq = CtrLogOper.TipoBusq;
                sLogOper.NumDocu = CtrLogOper.NumDocu;
        
                ListLogOpe = sLogOperDao.GetBusLogOper(sLogOper);
                RpsLogOper.BListaLogOper = ListLogOpe;
            }
            return RpsLogOper;
        }


#region Lista : Busqueda de Documentos Adjunto (Control)

        public BuscarDocumentoResponse GetDocumentoAdjunto(BuscarDocumentoRequest RqtDocAdj)
        {
            BuscarDocumentoResponse RpsDocumentoDigital = new BuscarDocumentoResponse();
            RpsDocumentoDigital.CorrelationId = RqtDocAdj.RequestId;

            eBuscarDocumentos CtrDocumentoDigital = RqtDocAdj.CtrDocDigTD as eBuscarDocumentos;
            if (RqtDocAdj.LoadOptions.Contains("TipoDocumentoAdjunto"))
            {
                IList<eBuscarDocumentos> ListaDocumentoAdjunto;
                eBuscarDocumentos BDocumentoAdj = new eBuscarDocumentos()
                {
                    TipoBusq = CtrDocumentoDigital.TipoBusq,

                    sDocDig = new eDocDig
                    {
                        CodiDocuDigi = CtrDocumentoDigital.sDocDig.CodiDocuDigi,
                        NumDocuDigi = CtrDocumentoDigital.sDocDig.NumDocuDigi,
                        CodiTipoDocu = CtrDocumentoDigital.sDocDig.CodiTipoDocu,
                        TituDocuDigi = CtrDocumentoDigital.sDocDig.TituDocuDigi,
                        AsunDocuDigi = CtrDocumentoDigital.sDocDig.AsunDocuDigi,
                        NombOrig = CtrDocumentoDigital.sDocDig.NombOrig,
                        NombFisi = CtrDocumentoDigital.sDocDig.NombFisi
                    },
                };

                ListaDocumentoAdjunto = sBuscarDocumento.GetBuscarAdjunto(BDocumentoAdj);

                RpsDocumentoDigital.BListaDocumentoAdjunto = ListaDocumentoAdjunto;
            }
            return RpsDocumentoDigital;
        }

#endregion

        public UbigeoResponse GetUbigeo(UbigeoRequest RqtUbigeo)
        {
            UbigeoResponse RpsUbigeo = new UbigeoResponse();
            RpsUbigeo.CorrelationId = RqtUbigeo.RequestId;

            eUbigeo CtrUbigeo = RqtUbigeo.CtrUbigeo as eUbigeo;

            if (RqtUbigeo.LoadOptions.Contains("UbigeoList"))
            {
                IList<eUbigeo> ListUbigeo;
                eUbigeo sUbigeo = new eUbigeo();

                sUbigeo.TipoCod = CtrUbigeo.TipoCod;
                sUbigeo.Cod_Dpto = CtrUbigeo.Cod_Dpto;
                sUbigeo.Cod_Prov = CtrUbigeo.Cod_Prov;

                ListUbigeo = sUbigeoDao.GetUbigeo(sUbigeo);
                RpsUbigeo.ListaUbigeo = ListUbigeo;
            }
            return RpsUbigeo;
        }

    }
}
