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
    public class GestionService : IGestionService
    {
        /* JMARINOS:  Separar por regiones, comentar brevemente*/


        private static bTipoAcceso sTipoAccesoDao = new bTipoAcceso();
        private static bTipoPrioridad sTipoPrioridadDao = new bTipoPrioridad();
        private static bTipoParticip sTipoParticipDao = new bTipoParticip();
        private static bUsuarioPer sUsuarioPerDao = new bUsuarioPer();
        private static bUsuarioParticipante sUsuarioParticipanteDao = new bUsuarioParticipante();
        private static bEmpresa sEmpresaDao = new bEmpresa();
        private static bAutorizador sAutorizaDao = new bAutorizador();
        private static bTipoEvento sTipoEventoDao = new bTipoEvento();
        private static bTipoOperacion sTipoOperacionDao = new bTipoOperacion();
        private static bRol sRolDao = new bRol();
        private static bTipoCargo sTipoCargoDao = new bTipoCargo();
        private static bTipoArea sTipoAreaDao = new bTipoArea();
        private static bTipoGrupo sTipoGrupoDao = new bTipoGrupo();
        private static bTipoUsuario sTipoUsuarioDao = new bTipoUsuario();
        private static bListUsuarioGr sListUsuarioGrDao = new bListUsuarioGr();
        private static bLUserPart LUserPartDao = new bLUserPart();
        private static bListaDescripcion ListaDescripcionDao = new bListaDescripcion();
        private static bOperacion sOperacionesDao = new bOperacion();
        private static bUsuarioGrupo sUsuarioGrupoDao = new bUsuarioGrupo();
        private static bConsAutorizador sConsAutorizadorDao = new bConsAutorizador();
        private static bGrupoUsuarios sGrupoUsuariosDao = new bGrupoUsuarios();
        private static bGrupo sGrupoDao = new bGrupo();
        private static bConsModuPag ConsModuPagDao = new bConsModuPag();
        private static bAccesoSistema sAccesoDao = new bAccesoSistema();
        private static bPersonal sPersonalDao = new bPersonal();
        private static bConsMenuUsua sConsMenuUsuaDao = new bConsMenuUsua();



        #region Class: Tipo de Acceso

        public TipoAccesoResponse GetListaTipoAcceso(TipoAccesoRequest RqtListaTipoAcceso)
        {
            TipoAccesoResponse RpsTipoAcceso = new TipoAccesoResponse();
            RpsTipoAcceso.CorrelationId = RqtListaTipoAcceso.RequestId;

            eTipoAcceso CtrTipoAcceso = RqtListaTipoAcceso.CtrTipoAcceso as eTipoAcceso;

            if (RqtListaTipoAcceso.LoadOptions.Contains("TipoAccesoLista"))
            {
                IList<eTipoAcceso> ListaTipoAcceso;
                eTipoAcceso sTipoAcceso = new eTipoAcceso();

                sTipoAcceso.EstAcc = CtrTipoAcceso.EstAcc;

                ListaTipoAcceso = sTipoAccesoDao.GetListaTipoAcceso(sTipoAcceso);
                RpsTipoAcceso.ListaTipoAcceso = ListaTipoAcceso;
            }


            return RpsTipoAcceso;
        }

        #endregion

        #region Class: Tipo de Prioridad

        public TipoPrioridadResponse GetListaTipoPrioridad(TipoPrioridadRequest RqtListaTipoPrioridad)
        {
            TipoPrioridadResponse RpsTipoPrioridad = new TipoPrioridadResponse();
            RpsTipoPrioridad.CorrelationId = RqtListaTipoPrioridad.RequestId;

            eTipoPrioridad CtrTipoPrioridad = RqtListaTipoPrioridad.CtrTipoPrioridad as eTipoPrioridad;

            if (RqtListaTipoPrioridad.LoadOptions.Contains("TipoPrioridadLista"))
            {
                IList<eTipoPrioridad> ListaTipoPrioridad;
                eTipoPrioridad sTipoPrioridad = new eTipoPrioridad();

                sTipoPrioridad.EstaTipoPrio = CtrTipoPrioridad.EstaTipoPrio;

                ListaTipoPrioridad = sTipoPrioridadDao.GetListaTipoPrioridad(sTipoPrioridad);
                RpsTipoPrioridad.ListaTipoPrioridad = ListaTipoPrioridad;
            }


            return RpsTipoPrioridad;
        }

        #endregion

        #region Tipo de Participante

        public TipoParticipResponse GetListaTipoParticip(TipoParticipRequest RqtListaTipoParticip)
        {
            TipoParticipResponse RpsListaTipoParticip = new TipoParticipResponse();
            RpsListaTipoParticip.CorrelationId = RqtListaTipoParticip.RequestId;

            eTipoParticipacion CtrTipoPartic = RqtListaTipoParticip.CtrTipoPartic as eTipoParticipacion;

            if (RqtListaTipoParticip.LoadOptions.Contains("TipoParticipLista"))
            {
                IList<eTipoParticipacion> ListaTipoParticip;
                eTipoParticipacion sTipoParticipacion = new eTipoParticipacion();

                sTipoParticipacion.EstTipoParticipacion = CtrTipoPartic.EstTipoParticipacion;

                ListaTipoParticip = sTipoParticipDao.GetListaTipoParticip(sTipoParticipacion);
                RpsListaTipoParticip.ListaParticip = ListaTipoParticip;
            }

            return RpsListaTipoParticip;
        }

        #endregion

        #region Lista Usuarios

        public UsuarioPerResponse GetListaUsuarioPer(UsuarioPerRequest RqtListaUsuarioPer)
        {
            UsuarioPerResponse RpsListaUsuarioPer = new UsuarioPerResponse();
            RpsListaUsuarioPer.CorrelationId = RqtListaUsuarioPer.RequestId;

            eUsuario CtrUsuarioPer = RqtListaUsuarioPer.CtrUsuarioPer as eUsuario;

            if (RqtListaUsuarioPer.LoadOptions.Contains("UsuarioPerLista"))
            {
                IList<eUsuario> ListaUsuarioPer = new List<eUsuario>();
                eUsuario sUsuario = new eUsuario();

                sUsuario.Codigo = CtrUsuarioPer.Codigo;
                sUsuario.IdeUsuario = CtrUsuarioPer.IdeUsuario;
                sUsuario.NombPers = CtrUsuarioPer.NombPers;
                sUsuario.Pers = new ePersonal
                {
                    DNI = CtrUsuarioPer.Pers.DNI
                };

                ListaUsuarioPer = sUsuarioPerDao.GetListaUsuarioPer(sUsuario);
                RpsListaUsuarioPer.ListaUsuarioPer = ListaUsuarioPer;
            }

            return RpsListaUsuarioPer;

        }

        public UsuarioPerResponse GetListaUsuarioGrupo(UsuarioPerRequest RqtListaUsuarioPer)
        {
            UsuarioPerResponse RpsListaUsuarioGrupo = new UsuarioPerResponse();
            RpsListaUsuarioGrupo.CorrelationId = RqtListaUsuarioPer.RequestId;

            eUsuario CtrUsuarioGrupo = RqtListaUsuarioPer.CtrUsuarioPer as eUsuario;

            if (RqtListaUsuarioPer.LoadOptions.Contains("UsuarioGrupoLista"))
            {
                IList<eUsuario> ListaUsuarioGrupo = new List<eUsuario>();
                eUsuario sUsuario = new eUsuario();

                sUsuario.NombPers = CtrUsuarioGrupo.NombPers;

                ListaUsuarioGrupo = sUsuarioPerDao.GetListaUsuarioGrupo(sUsuario);
                RpsListaUsuarioGrupo.ListaUsuarioPer = ListaUsuarioGrupo;
            }

            return RpsListaUsuarioGrupo;

        }

        #endregion

        #region Usuario Participante

        public UsuParticipResponse SetUsuParticipante(UsuParticipRequest RqtUsuParticip)
        {
            UsuParticipResponse RpsUsuParticip = new UsuParticipResponse();
            RpsUsuParticip.CorrelationId = RqtUsuParticip.RequestId;

            eParticipante CtrUsuPart = RqtUsuParticip.CtrUsuPart as eParticipante;

            if (RqtUsuParticip.LoadOptions.Contains("UsuarioParticipanteAdd"))
            {
                Int64 sIUsuParticip = 0;
                eParticipante sUsuParticip = new eParticipante();

                sUsuParticip.CodiUsuPart = CtrUsuPart.CodiUsuPart;
                sUsuParticip.TipoOper = CtrUsuPart.TipoOper;
                sUsuParticip.CodiOper = CtrUsuPart.CodiOper;
                sUsuParticip.TipoPart = CtrUsuPart.TipoPart;
                sUsuParticip.ApruOper = CtrUsuPart.ApruOper;
                sUsuParticip.EnviNoti = CtrUsuPart.EnviNoti;
                sUsuParticip.FechNoti = CtrUsuPart.FechNoti;
                sUsuParticip.EstaUsuaPart = CtrUsuPart.EstaUsuaPart;
                sUsuParticip.CodiUsu = CtrUsuPart.CodiUsu;
                sUsuParticip.Reenvio = CtrUsuPart.Reenvio;
                sUsuParticip.Envio = CtrUsuPart.Envio;

                sIUsuParticip = sUsuarioParticipanteDao.SetUsuParticipante(sUsuParticip);
                RpsUsuParticip.AddUsuPartip = sIUsuParticip;

            }
            return RpsUsuParticip;
        }

        public UsuParticipResponse UpdateUsuParticipante(UsuParticipRequest RqtUsuParticip)
        {
            UsuParticipResponse RpsUsuParticip = new UsuParticipResponse();
            RpsUsuParticip.CorrelationId = RqtUsuParticip.RequestId;

            eParticipante CtrUsuPart = RqtUsuParticip.CtrUsuPart as eParticipante;

            if (RqtUsuParticip.LoadOptions.Contains("UsuarioParticipanteUpdate"))
            {
                Int64 sIUsuParticip = 0;
                eParticipante sUsuParticip = new eParticipante();

                sUsuParticip.CodiUsuPart = CtrUsuPart.CodiUsuPart;
                sUsuParticip.TipoOper = CtrUsuPart.TipoOper;
                sUsuParticip.CodiOper = CtrUsuPart.CodiOper;
                sUsuParticip.TipoPart = CtrUsuPart.TipoPart;                
                sUsuParticip.CodiUsu = CtrUsuPart.CodiUsu;
                sUsuParticip.ConfLect = CtrUsuPart.ConfLect;                

                sIUsuParticip = sUsuarioParticipanteDao.UpdateUsuParticipante(sUsuParticip);
                RpsUsuParticip.UpdateUsuPartip = sIUsuParticip;

            }
            return RpsUsuParticip;
        }

        #endregion

        #region Usuario Participante  

        public LUserParticResponse GetUserPart(UsuParticipRequest RqtUserPart)
        {
            LUserParticResponse RpsUserPart = new LUserParticResponse();
            RpsUserPart.CorrelationId = RqtUserPart.RequestId;

            eParticipante CtrUserPart = RqtUserPart.CtrUsuPart as eParticipante;

            if (RqtUserPart.LoadOptions.Contains("UserPartLista"))
            {
                IList<eParticipante> ListaUserPart;
                eParticipante sPart = new eParticipante();

                sPart.CodiOper = CtrUserPart.CodiOper;
                sPart.CodiUsu = CtrUserPart.CodiUsu;

                ListaUserPart = LUserPartDao.GetUserPart(sPart);
                RpsUserPart.ListaUsuPart = ListaUserPart;
            }

            return RpsUserPart;
        }

        public LUserParticResponse GetUserPartBatch(UsuParticipRequest RqtUserPart)
        {
            LUserParticResponse RpsUserPart = new LUserParticResponse();
            RpsUserPart.CorrelationId = RqtUserPart.RequestId;

            if (RqtUserPart.LoadOptions.Contains("UserPartListaBatch"))
            {
                IList<eParticipante> ListaUserPart;
                ListaUserPart = LUserPartDao.GetUserPartBatch(RqtUserPart.ListCodiOper, RqtUserPart.ListCodiUsu);
                RpsUserPart.ListaUsuPart = ListaUserPart;
            }

            return RpsUserPart;
        }

        #endregion

        #region Empresa

        public EmpresaResponse SetEmpresaAdd(EmpresaRequest RqtEmpresa)
        {
            EmpresaResponse RpsEmpresa = new EmpresaResponse();
            RpsEmpresa.CorrelationId = RqtEmpresa.RequestId;

            eEmpresa CtrEmpresa = RqtEmpresa.CtrEmpresa as eEmpresa;

            if (RqtEmpresa.LoadOptions.Contains("EmpresaAdd"))
            {
                Int64 sIEmpresa = 0;
                eEmpresa sEmpresa = new eEmpresa();

                sEmpresa.Type = CtrEmpresa.Type;
                sEmpresa.RucEmpr = CtrEmpresa.RucEmpr;
                sEmpresa.RazoSoci = CtrEmpresa.RazoSoci;
                sEmpresa.DireEmpr = CtrEmpresa.DireEmpr;
                sEmpresa.CodiUbig = CtrEmpresa.CodiUbig;
                sEmpresa.FechRegi = CtrEmpresa.FechRegi;
                sEmpresa.CodiUsu = CtrEmpresa.CodiUsu;
                sEmpresa.EstEmpr = CtrEmpresa.EstEmpr;

                sIEmpresa = sEmpresaDao.SetEmpresaAdd(sEmpresa);
                RpsEmpresa.AddEmpresa = sIEmpresa;
            }
            return RpsEmpresa;
        }

        public LEmpresaResponse GetEmpresa(EmpresaRequest RqtEmpr)
        {
            LEmpresaResponse RpsEmpresa = new LEmpresaResponse();
            RpsEmpresa.CorrelationId = RqtEmpr.RequestId;

            eEmpresa CtrEmpresa = RqtEmpr.CtrEmpresa as eEmpresa;

            if (RqtEmpr.LoadOptions.Contains("EmpresaList"))
            {
                IList<eEmpresa> ListaEmpresa;
                eEmpresa sEmpresa = new eEmpresa();


                sEmpresa.RucEmpr = CtrEmpresa.RucEmpr;
                sEmpresa.RazoSoci = CtrEmpresa.RazoSoci;
                sEmpresa.EstEmpr = CtrEmpresa.EstEmpr;

                ListaEmpresa = sEmpresaDao.GetEmpresa(sEmpresa);
                RpsEmpresa.EmpresaLista = ListaEmpresa;
            }
            return RpsEmpresa;
        }

        #endregion

        #region Usuario Autorizador

        public AutorizaResponse SetAutorizaAdd(AutorizaRequest RqtAutoriza)
        {
            AutorizaResponse RpsAutoriza = new AutorizaResponse();
            RpsAutoriza.CorrelationId = RqtAutoriza.RequestId;

            eAutorizador CtrAutoriza = RqtAutoriza.CtrAutoriza as eAutorizador;

            if (RqtAutoriza.LoadOptions.Contains("AutorizaAdd"))
            {
                Int64 sIAutoriza = 0;
                eAutorizador sAutoriza = new eAutorizador();

                sAutoriza.Type = CtrAutoriza.Type;
                sAutoriza.CodiUsuPart = CtrAutoriza.CodiUsuPart;
                sAutoriza.CodiOper = CtrAutoriza.CodiOper;
                sAutoriza.TipoOper = CtrAutoriza.TipoOper;
                sAutoriza.RespUsuAuto = CtrAutoriza.RespUsuAuto;
                sAutoriza.FechUsuAuto = CtrAutoriza.FechUsuAuto;
                sAutoriza.ComeUsuAuto = CtrAutoriza.ComeUsuAuto;
                sAutoriza.EstaAuto = CtrAutoriza.EstaAuto;

                sIAutoriza = sAutorizaDao.SetAutorizadorAdd(sAutoriza);
                RpsAutoriza.AddAutoriza = sIAutoriza;
            }
            return RpsAutoriza;
        }

        #endregion

        #region Tipo de Evento

        public TipoEventoResponse GetTipoEvento(TipoEventoRequest RqtTipoEvento)
        {
            TipoEventoResponse RpsTipoEvento = new TipoEventoResponse();
            RpsTipoEvento.CorrelationId = RqtTipoEvento.RequestId;

            eTipoEvento CtrTipoEvento = RqtTipoEvento.CtrTipoEvento as eTipoEvento;

            if (RqtTipoEvento.LoadOptions.Contains("TipoEventoLista"))
            {
                IList<eTipoEvento> ListaTipoEvento;
                eTipoEvento sTipoEvento = new eTipoEvento();

                sTipoEvento.EstTipoEvento = CtrTipoEvento.EstTipoEvento;

                ListaTipoEvento = sTipoEventoDao.GetTipoEvento(sTipoEvento);
                RpsTipoEvento.ListaEvento = ListaTipoEvento;
            }


            return RpsTipoEvento;
        }

        #endregion

        #region Tipo de Operacion

        public TipoOperacionResponse GetTipoOperacion(TipoOperacionRequest RqtTipoOperacion)
        {
            TipoOperacionResponse RpsTipoOperacion = new TipoOperacionResponse();
            RpsTipoOperacion.CorrelationId = RqtTipoOperacion.RequestId;

            eTipoOperacion CtrTipoOper = RqtTipoOperacion.CtrTipoOper as eTipoOperacion;

            if (RqtTipoOperacion.LoadOptions.Contains("TipoOperacionLista"))
            {
                IList<eTipoOperacion> ListaTipoOperacion;
                eTipoOperacion sTipoOperacion = new eTipoOperacion();

                sTipoOperacion.EstTipoOperacion = CtrTipoOper.EstTipoOperacion;

                ListaTipoOperacion = sTipoOperacionDao.GetTipoOperacion(sTipoOperacion);
                RpsTipoOperacion.ListOperacion = ListaTipoOperacion;
            }

            return RpsTipoOperacion;
        }

        #endregion

        #region Tipo de Rol

        public RolResponse GetTipoRol(RolRequest RqtRol)
        {
            RolResponse RpsRol = new RolResponse();
            RpsRol.CorrelationId = RqtRol.RequestId;

            eRol CtrRol = RqtRol.CtrRol as eRol;

            if (RqtRol.LoadOptions.Contains("TipoRolLista"))
            {
                IList<eRol> ListaTipoRol;
                eRol sRol = new eRol();

                sRol.EstTipoRol = CtrRol.EstTipoRol;

                ListaTipoRol = sRolDao.GetTipoRol(sRol);
                RpsRol.ListaRol = ListaTipoRol;

            }
            return RpsRol;
        }

        #endregion

        #region Tipo Cargo

        public TipoCargoResponse GetTipoCargo(TipoCargoRequest RqtTipoCargo)
        {
            TipoCargoResponse RpsTipoCargo = new TipoCargoResponse();
            RpsTipoCargo.CorrelationId = RqtTipoCargo.RequestId;

            eTipoCargo CtrTipoCargo = RqtTipoCargo.CtrTipoCargo as eTipoCargo;

            if (RqtTipoCargo.LoadOptions.Contains("TipoCargoLista"))
            {
                IList<eTipoCargo> ListaTipoCargo;
                eTipoCargo sTipoCargo = new eTipoCargo();

                sTipoCargo.EstCargo = CtrTipoCargo.EstCargo;

                ListaTipoCargo = sTipoCargoDao.GetTipoCargo(sTipoCargo);
                RpsTipoCargo.ListaTipoCargo = ListaTipoCargo;

            }
            return RpsTipoCargo;

        }

        #endregion

        #region Tipo de Area

        public TipoAreaResponse GetTipoArea(TipoAreaRequest RqtTipoArea)
        {
            TipoAreaResponse RpsTipoArea = new TipoAreaResponse();
            RpsTipoArea.CorrelationId = RqtTipoArea.RequestId;

            eArea CtrTipoArea = RqtTipoArea.CtrTipoArea as eArea;

            if (RqtTipoArea.LoadOptions.Contains("TipoAreaLista"))
            {
                IList<eArea> ListaTipoArea;
                eArea sArea = new eArea();

                sArea.EstaAre = CtrTipoArea.EstaAre;

                ListaTipoArea = sTipoAreaDao.GetTipoArea(sArea);
                RpsTipoArea.ListaTipoArea = ListaTipoArea;
            }

            return RpsTipoArea;
        }

        #endregion

        #region Tipo de Grupo

        public TipoGrupoResponse GetTipoGrupo(TipoGrupoRequest RqtTipoGrupo)
        {
            TipoGrupoResponse RpsTipoGrupo = new TipoGrupoResponse();
            RpsTipoGrupo.CorrelationId = RqtTipoGrupo.RequestId;

            eGrupo CtrTipoGrupo = RqtTipoGrupo.CtrTipoGrupo as eGrupo;

            if (RqtTipoGrupo.LoadOptions.Contains("TipoGrupoLista"))
            {
                IList<eGrupo> ListaTipoGrupo;
                eGrupo sGrupo = new eGrupo();

                sGrupo.EstGrup = CtrTipoGrupo.EstGrup;

                ListaTipoGrupo = sTipoGrupoDao.GetTipoGrupo(sGrupo);
                RpsTipoGrupo.ListaTipoGrupo = ListaTipoGrupo;
            }

            return RpsTipoGrupo;
        }

        #endregion

        #region Tipo de Usuario

        public TipoUsuarioResponse GetTipoUsuario(TipoUsuarioRequest RqtTipoUsuario)
        {
            TipoUsuarioResponse RpsTipoUsuario = new TipoUsuarioResponse();
            RpsTipoUsuario.CorrelationId = RqtTipoUsuario.RequestId;

            eTipoUsuario CtrTipoUsuario = RqtTipoUsuario.CtrTipoUsuario as eTipoUsuario;

            if (RqtTipoUsuario.LoadOptions.Contains("TipoUsuarioLista"))
            {
                IList<eTipoUsuario> ListaTipoUsuario;
                eTipoUsuario sTipoUsuario = new eTipoUsuario();

                sTipoUsuario.EstaTipUsu = CtrTipoUsuario.EstaTipUsu;

                ListaTipoUsuario = sTipoUsuarioDao.GetTipoUsuario(sTipoUsuario);
                RpsTipoUsuario.ListaTipoUsuario = ListaTipoUsuario;
            }

            return RpsTipoUsuario;
        }

        #endregion

        #region Lista ??????

        public ListaDescResponse GetListDes(ListaDescRequest RqtListaDesc)
        {
            ListaDescResponse RpsListDesc = new ListaDescResponse();
            RpsListDesc.CorrelationId = RqtListaDesc.RequestId;

            eVariable CtrListDes = RqtListaDesc.CtrDesList as eVariable;

            if (RqtListaDesc.LoadOptions.Contains("ListaDesc"))
            {
                IList<eVariable> ListaDescrp = new List<eVariable>();
                eVariable sVariable = new eVariable();

                sVariable.Descrip = CtrListDes.Descrip;
                sVariable.CodUsu = CtrListDes.CodUsu;

                ListaDescrp = ListaDescripcionDao.GetListaDescrip(sVariable);
                RpsListDesc.ListDesc = ListaDescrp;
            }

            return RpsListDesc;
        }

        #endregion

        #region Tipo de Usuario Grupo

        public TipoGrupoResponse GetTipoUsuGrupo(TipoGrupoRequest RqtTipoUsuGrupo)
        {
            TipoGrupoResponse RpsTipoUsuGrupo = new TipoGrupoResponse();
            RpsTipoUsuGrupo.CorrelationId = RqtTipoUsuGrupo.RequestId;

            eGrupo CtrTipoUsuGrupo = RqtTipoUsuGrupo.CtrTipoGrupo as eGrupo;

            if (RqtTipoUsuGrupo.LoadOptions.Contains("TipoUsuGrupoLista"))
            {
                IList<eGrupo> ListaTipoUsuGrupo = new List<eGrupo>();
                eGrupo sGrupo = new eGrupo();

                sGrupo.CodiGrup = CtrTipoUsuGrupo.CodiGrup;
                sGrupo.UsuarioGrupo.Codigo = CtrTipoUsuGrupo.UsuarioGrupo.Codigo;

                ListaTipoUsuGrupo = sListUsuarioGrDao.GetUsuarioGrupo(sGrupo);
                RpsTipoUsuGrupo.ListaTipoGrupo = ListaTipoUsuGrupo;
            }

            return RpsTipoUsuGrupo;
        }

        #endregion

        #region Lista Operaciones

        public OperacionResponse GetListOper(OperacionRequest RqtListOper)
        {
            OperacionResponse RpsOperList = new OperacionResponse();
            RpsOperList.CorrelationId = RqtListOper.RequestId;

            eOperaciones CtrOperList = RqtListOper.CtrOper as eOperaciones;

            if (RqtListOper.LoadOptions.Contains("OperLista"))
            {
                IList<eOperaciones> ListOper;
                eOperaciones sOperacion = new eOperaciones();

                sOperacion.Type = CtrOperList.Type;
                sOperacion.CodUsu = CtrOperList.CodUsu;
                sOperacion.Fecha = CtrOperList.Fecha;

                ListOper = sOperacionesDao.GetOperaciones(sOperacion);
                RpsOperList.OperacionLista = ListOper;
            }

            return RpsOperList;
        }

        #endregion

        #region Mensaje Alerta

        public UsuParticipResponse SetAnulaUserPart(UsuParticipRequest RqtUsuParticip)
        {
            UsuParticipResponse RpsUsuParticip = new UsuParticipResponse();
            RpsUsuParticip.CorrelationId = RqtUsuParticip.RequestId;

            eParticipante CtrUsuPart = RqtUsuParticip.CtrUsuPart as eParticipante;

            if (RqtUsuParticip.LoadOptions.Contains("UsuarioPartAnula"))
            {
                Int64 sIUsuParticip = 0;
                eParticipante sUsuParticip = new eParticipante();

                sUsuParticip.CodiOper = CtrUsuPart.CodiOper;
                sUsuParticip.CodiUsu = CtrUsuPart.CodiUsu;

                sIUsuParticip = sUsuarioParticipanteDao.SetAnulaUserPart(sUsuParticip);
                RpsUsuParticip.AddUsuPartip = sIUsuParticip;

            }
            return RpsUsuParticip;
        }

        #endregion

        #region Class: Usuario Grupo

        public UsuarioGrupoResponse GetUsuarioGrupo(UsuarioGrupoRequest RqtUsuarioGrupo)
        {
            UsuarioGrupoResponse RpsUsuarioGrupo = new UsuarioGrupoResponse();
            RpsUsuarioGrupo.CorrelationId = RqtUsuarioGrupo.RequestId;

            eUsuarioGrupo CtrUsuarioGrupo = RqtUsuarioGrupo.CtrUsuarioGrupo as eUsuarioGrupo;

            if (RqtUsuarioGrupo.LoadOptions.Contains("ListUsuarioGrupo"))
            {
                IList<eUsuarioGrupo> ListUsuarioGrupo = new List<eUsuarioGrupo>();
                eUsuarioGrupo sUsuarioGrupo = new eUsuarioGrupo();

                sUsuarioGrupo.Grupo = new eGrupo
                {
                    CodiGrup = CtrUsuarioGrupo.Grupo.CodiGrup,
                    NombGrup = CtrUsuarioGrupo.Grupo.NombGrup
                };

                ListUsuarioGrupo = sUsuarioGrupoDao.GetUsuarioGrupo(sUsuarioGrupo);
                RpsUsuarioGrupo.UsuarioGrupoLista = ListUsuarioGrupo;

            }
            return RpsUsuarioGrupo;
        }

        #endregion

        #region Lista Autorizador
        public LUserAutoResponse GetAutorizaList(AutorizaRequest RqtAutoriza)
        {
            LUserAutoResponse RpsUserAuto = new LUserAutoResponse();
            RpsUserAuto.CorrelationId = RqtAutoriza.RequestId;

            eAutorizador CtrAutoriz = RqtAutoriza.CtrAutoriza as eAutorizador;

            if (RqtAutoriza.LoadOptions.Contains("AutorizaList"))
            {
                IList<eAutorizador> ListAutoriza;
                eAutorizador Autoriza = new eAutorizador();

                Autoriza.Type = CtrAutoriz.Type;
                Autoriza.CodiOper = CtrAutoriz.CodiOper;
                Autoriza.CodiUsuPart = CtrAutoriz.CodiUsuPart;

                ListAutoriza = sConsAutorizadorDao.GetUserAutoriza(Autoriza);
                RpsUserAuto.AutorizaList = ListAutoriza;
            }
            return RpsUserAuto;
        }
        #endregion

        public GrupoUsuarioResponse SetGrupoUser(UsuarioGrupoRequest RqtGrupoUser)
        {

            GrupoUsuarioResponse RpsGrupoUser = new GrupoUsuarioResponse();
            RpsGrupoUser.CorrelationId = RqtGrupoUser.RequestId;

            eUsuarioGrupo CtrUser = RqtGrupoUser.CtrUsuarioGrupo as eUsuarioGrupo;
            if (RqtGrupoUser.LoadOptions.Contains("GrupoUserAdd"))
            {
                Int64 sIGrupoUser = 0;
                eUsuarioGrupo GUser = new eUsuarioGrupo();

                GUser.CodiUsuGrup = CtrUser.CodiUsuGrup;
                GUser.Usuario = new eUsuario
                {
                    Codigo = CtrUser.Usuario.Codigo
                };
                GUser.Grupo = new eGrupo
                {
                    CodiGrup = CtrUser.Grupo.CodiGrup
                };
                GUser.UsuCrea = CtrUser.UsuCrea;
                GUser.FechCrea = CtrUser.FechCrea;
                GUser.EstUsuGrup = CtrUser.EstUsuGrup;

                sIGrupoUser = sGrupoUsuariosDao.GrupoUserAdd(GUser);
                RpsGrupoUser.GrupoUsuarioAdd = sIGrupoUser;
            }
            return RpsGrupoUser;
        }

        public GrupoResponse SetGrupoAdd(ref GrupoRequest RqtGrupo)
        {
            GrupoResponse RpsGrupo = new GrupoResponse();
            RpsGrupo.CorrelationId = RqtGrupo.RequestId;

            eGrupo CtrGrupo = RqtGrupo.CtrGrupo as eGrupo;
            if (RqtGrupo.LoadOptions.Contains("GrupoAdd"))
            {
                Int64 sIGrupo = 0;

                eGrupo sGrupo = new eGrupo();
                sGrupo.CodiGrup = CtrGrupo.CodiGrup;
                sGrupo.NombGrup = CtrGrupo.NombGrup;
                sGrupo.FechCrea = CtrGrupo.FechCrea;
                sGrupo.UsuCrea = CtrGrupo.UsuCrea;
                sGrupo.ComeGrup = CtrGrupo.ComeGrup;
                sGrupo.EstGrup = CtrGrupo.EstGrup;

                sIGrupo = sGrupoDao.GrupoAdd(sGrupo);
                if (sGrupo.CodiGrup > 0)
                {
                    RqtGrupo.CtrGrupo.CodiGrup = sGrupo.CodiGrup;
                }
                RpsGrupo.AddGrupo = sIGrupo;
            }
            return RpsGrupo;

        }

        public GrupoUsuarioResponse SetAnulaGrupoUser(UsuarioGrupoRequest RqtGrupoUser)
        {
            GrupoUsuarioResponse RpsGrupoUser = new GrupoUsuarioResponse();
            RpsGrupoUser.CorrelationId = RqtGrupoUser.RequestId;

            eUsuarioGrupo CtrUser = RqtGrupoUser.CtrUsuarioGrupo as eUsuarioGrupo;
            if (RqtGrupoUser.LoadOptions.Contains("GrupoUserAnula"))
            {
                Int64 sIGrupoUser = 0;
                eUsuarioGrupo GUser = new eUsuarioGrupo();

                GUser.Grupo = new eGrupo
                {
                    CodiGrup = CtrUser.Grupo.CodiGrup
                };
                GUser.Usuario = new eUsuario
                {
                    Codigo = CtrUser.Usuario.Codigo
                };

                sIGrupoUser = sGrupoUsuariosDao.AnulaGrupoUser(GUser);
                RpsGrupoUser.GrupoUsuarioAdd = sIGrupoUser;
            }
            return RpsGrupoUser;
        }

        public ConsModPagResponse GetModuloPagina(ConsModPagRequest RqtModPag)
        {
            ConsModPagResponse RpsModPag = new ConsModPagResponse();
            RpsModPag.CorrelationId = RqtModPag.RequestId;

            eModuloPagina CtrModPag = RqtModPag.CtrModPag as eModuloPagina;

            if (RqtModPag.LoadOptions.Contains("ModPagLista"))
            {
                IList<eModuloPagina> ListaModPag;
                eModuloPagina sModulo = new eModuloPagina();

                sModulo.Estado = CtrModPag.Estado;

                ListaModPag = ConsModuPagDao.GetModuloPagina(sModulo);
                RpsModPag.ListaModPag = ListaModPag;
            }

            return RpsModPag;
        }

        public AccesoResponse SetAccesoSistema(AccesoRequest RqtAcceso)
        {
            AccesoResponse RpsAcceso = new AccesoResponse();
            RpsAcceso.CorrelationId = RqtAcceso.RequestId;

            eAccesoSistema CtrAcceso = RqtAcceso.CtrAcceso as eAccesoSistema;

            if (RqtAcceso.LoadOptions.Contains("AccesoAdd"))
            {
                Int64 sIAcceso = 0;
                eAccesoSistema sAcceso = new eAccesoSistema();

                sAcceso.Codigo = CtrAcceso.Codigo;
                sAcceso.UsuarioCreacion = new eUsuario
                {
                    Codigo = CtrAcceso.UsuarioCreacion.Codigo
                };
                sAcceso.FechaModificacion = CtrAcceso.FechaModificacion;
                sAcceso.Estado = CtrAcceso.Estado;
                sAcceso.Usuario = new eUsuario
                {
                    Codigo = CtrAcceso.Usuario.Codigo
                };
                sAcceso.Pagina = new eModuloPagina
                {
                    Codigo = CtrAcceso.Pagina.Codigo
                };

                sIAcceso = sAccesoDao.SetAccesoSistema(sAcceso);
                RpsAcceso.AddAcceso = sIAcceso;
            }

            return RpsAcceso;
        }

        public LAccesoResponse GetAccesoSistema(AccesoRequest RqtAccesolist)
        {
            LAccesoResponse RpsAcceso = new LAccesoResponse();
            RpsAcceso.CorrelationId = RqtAccesolist.RequestId;

            eAccesoSistema CtrAcceso = RqtAccesolist.CtrAcceso as eAccesoSistema;

            if (RqtAccesolist.LoadOptions.Contains("AccesoList"))
            {
                IList<eAccesoSistema> ListAcceso = new List<eAccesoSistema>();
                eAccesoSistema sAcceso = new eAccesoSistema();

                sAcceso.Usuario = new eUsuario
                {
                    Codigo = CtrAcceso.Usuario.Codigo
                };
                sAcceso.Pagina = new eModuloPagina
                {
                    Codigo = CtrAcceso.Pagina.Codigo
                };

                ListAcceso = sAccesoDao.GetAccesoSistema(sAcceso);
                RpsAcceso.ListaAcceso = ListAcceso;
            }

            return RpsAcceso;
        }

        public AccesoResponse SetAnulaAcceso(AccesoRequest RqtAcceso)
        {
            AccesoResponse RpsAcceso = new AccesoResponse();
            RpsAcceso.CorrelationId = RqtAcceso.RequestId;

            eAccesoSistema CtrAcceso = RqtAcceso.CtrAcceso as eAccesoSistema;

            if (RqtAcceso.LoadOptions.Contains("AccesoAnula"))
            {
                Int64 sIAcceso = 0;
                eAccesoSistema sAcceso = new eAccesoSistema();

                sAcceso.Usuario = new eUsuario
                {
                    Codigo = CtrAcceso.Usuario.Codigo
                };
                sAcceso.Pagina = new eModuloPagina
                {
                    Codigo = CtrAcceso.Pagina.Codigo
                };

                sIAcceso = sAccesoDao.SetAnulaAcceso(sAcceso);
                RpsAcceso.AddAcceso = sIAcceso;
            }

            return RpsAcceso;

        }

        public PersonalResponse SetAddPersonal(ref PersonalRequest RqtPersonal)
        {
            PersonalResponse RpsPer = new PersonalResponse();
            RpsPer.CorrelationId = RqtPersonal.RequestId;

            ePersonal CtrPersonal = RqtPersonal.CtrPersonal as ePersonal;

            if (RqtPersonal.LoadOptions.Contains("PersonalAdd"))
            {
                Int64 sIPersonal = 0;
                ePersonal sPersonal = new ePersonal();

                sPersonal.CodigoPersona = CtrPersonal.CodigoPersona;
                sPersonal.NombPers = CtrPersonal.NombPers;
                sPersonal.ApePers = CtrPersonal.ApePers;
                sPersonal.SexoPers = CtrPersonal.SexoPers;
                sPersonal.EmaiPers = CtrPersonal.EmaiPers;
                sPersonal.EmaiTrab = CtrPersonal.EmaiTrab;
                sPersonal.FechNac = CtrPersonal.FechNac;
                sPersonal.TelePers = CtrPersonal.TelePers;
                sPersonal.AnexPers = CtrPersonal.AnexPers;
                sPersonal.CeluPers = CtrPersonal.CeluPers;
                sPersonal.EstaPers = CtrPersonal.EstaPers;
                sPersonal.CodiTipUsu = CtrPersonal.CodiTipUsu;
                sPersonal.CodiArea = CtrPersonal.CodiArea;
                sPersonal.CodiCarg = CtrPersonal.CodiCarg;
                sPersonal.ClasPers = CtrPersonal.ClasPers;
                sPersonal.RucEmpr = CtrPersonal.RucEmpr;
                sPersonal.DNI = CtrPersonal.DNI;
                sPersonal.DirePers = CtrPersonal.DirePers;

                sIPersonal = sPersonalDao.SetAddPersonal(sPersonal);
                if (sPersonal.CodigoPersona > 0)
                {
                    RqtPersonal.CtrPersonal.CodigoPersona = sPersonal.CodigoPersona;

                }
                RpsPer.AddPersonal = sIPersonal;
            }

            return RpsPer;
        }

        public UsuarioResponse SetAddUsuario(UsuarioPerRequest RqtUser)
        {
            UsuarioResponse RpsUser = new UsuarioResponse();
            RpsUser.CorrelationId = RqtUser.RequestId;

            eUsuario CtrUser = RqtUser.CtrUsuarioPer as eUsuario;

            if (RqtUser.LoadOptions.Contains("UsuarioAdd"))
            {
                Int64 sIUsuario = 0;
                eUsuario sUsuario = new eUsuario();

                sUsuario.Codigo = CtrUser.Codigo;
                sUsuario.IdeUsuario = CtrUser.IdeUsuario;
                sUsuario.Pasword = CtrUser.Pasword;
                sUsuario.FirmaElectronica = CtrUser.FirmaElectronica;
                sUsuario.Estado = CtrUser.Estado;
                sUsuario.FechaRegistro = CtrUser.FechaRegistro;
                sUsuario.FechaUltimoAcceso = CtrUser.FechaUltimoAcceso;
                sUsuario.FechaModificacion = CtrUser.FechaModificacion;
                sUsuario.IntentoErradoPasword = CtrUser.IntentoErradoPasword;
                sUsuario.IntentoErradoFirma = CtrUser.IntentoErradoFirma;
                sUsuario.TermUsu = CtrUser.TermUsu;
                sUsuario.UsuCrea = CtrUser.UsuCrea;
                sUsuario.CodiCnx = CtrUser.CodiCnx;
                sUsuario.CodigoPersona = CtrUser.CodigoPersona;
                sUsuario.CodiRol = CtrUser.CodiRol;
                sUsuario.CodiTipUsu = CtrUser.CodiTipUsu;
                sUsuario.ClasUsu = CtrUser.ClasUsu;
                sUsuario.ExpiClav = CtrUser.ExpiClav;
                sUsuario.ExpiFirm = CtrUser.ExpiFirm;
                sUsuario.FechExpiClav = CtrUser.FechExpiClav;
                sUsuario.FechExpiFirm = CtrUser.FechExpiFirm;

                sIUsuario = sUsuarioPerDao.SetAddUsuario(sUsuario);
                RpsUser.AddUser = sIUsuario;
            }
            return RpsUser;
        }

        public UsuarioResponse SetUsuarioPer(UsuarioPerRequest RqtUser)
        {
            UsuarioResponse RpsUser = new UsuarioResponse();
            RpsUser.CorrelationId = RqtUser.RequestId;

            eUsuario CtrUser = RqtUser.CtrUsuarioPer as eUsuario;

            if (RqtUser.LoadOptions.Contains("UsuarioPer"))
            {
                Int64 sIUsuario = 0;
                eUsuario sUsuario = new eUsuario();

                sUsuario.CodiTipUsu = CtrUser.CodiTipUsu;//parametro utilizado para no generar un tipo Type
                sUsuario.Codigo = CtrUser.Codigo;
                sUsuario.CodigoPersona = CtrUser.CodigoPersona;
                sUsuario.Pasword = CtrUser.Pasword;
                sUsuario.FirmaElectronica = CtrUser.FirmaElectronica;

                sIUsuario = sUsuarioPerDao.SetUsuarioEstado(sUsuario);
                RpsUser.AddUser = sIUsuario;
            }
            return RpsUser;
        }

        public LAccesoResponse GetMenuUsuario(AccesoRequest RqtMenu)
        {
            LAccesoResponse RpsAcceso = new LAccesoResponse();
            RpsAcceso.CorrelationId = RqtMenu.RequestId;

            eAccesoSistema CtrAcceso = RqtMenu.CtrAcceso as eAccesoSistema;

            if (RqtMenu.LoadOptions.Contains("MenuUsuario"))
            {
                IList<eAccesoSistema> ListMenu = new List<eAccesoSistema>();
                eAccesoSistema sAcceso = new eAccesoSistema();

                sAcceso.Usuario = new eUsuario
                {
                    Codigo = CtrAcceso.Usuario.Codigo
                };

                ListMenu = sConsMenuUsuaDao.GetMenuUsuario(sAcceso);
                RpsAcceso.ListaAcceso = ListMenu;
            }

            return RpsAcceso;
        }
    }
}