using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ServiceModel;
using WebGdoc.GestionServRef;
using Entity.Entities;

namespace WebGdoc.ServicesControllers
{
    public class GestionController : ControllerBase
    {



#region Class: Tipo de Acceso

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<eTipoAcceso> GetTipoAcceso(eTipoAcceso oTipoAcceso)
        {
            try
            {
                TipoAccesoRequest rqtTipoAcceso = new TipoAccesoRequest();
                rqtTipoAcceso.RequestId = NewRequestId;
                rqtTipoAcceso.AccessToken = AccessToken;
                rqtTipoAcceso.ClientTag = ClientTag;
                rqtTipoAcceso.LoadOptions = new string[] { "TipoAccesoLista" };
                rqtTipoAcceso.CtrTipoAcceso = new eTipoAcceso    
                {
                    EstAcc = oTipoAcceso.EstAcc
                };

                TipoAccesoResponse responseTD = GestionServiceClient.GetListaTipoAcceso(rqtTipoAcceso);

                if (rqtTipoAcceso.RequestId != responseTD.CorrelationId)
                    throw new ApplicationException("Error");

                return responseTD.ListaTipoAcceso;

            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }
        }

#endregion

#region Class: Tipo de Prioridad

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<eTipoPrioridad> GetTipoPrioridad(eTipoPrioridad oTipoPrioridad)
        {
            try
            {
                TipoPrioridadRequest rqtTipoPrioridad = new TipoPrioridadRequest();
                rqtTipoPrioridad.RequestId = NewRequestId;
                rqtTipoPrioridad.AccessToken = AccessToken;
                rqtTipoPrioridad.ClientTag = ClientTag;
                rqtTipoPrioridad.LoadOptions = new string[] { "TipoPrioridadLista" };
                rqtTipoPrioridad.CtrTipoPrioridad = new eTipoPrioridad
                {
                    EstaTipoPrio = oTipoPrioridad.EstaTipoPrio
                };

                TipoPrioridadResponse responseTD = GestionServiceClient.GetListaTipoPrioridad(rqtTipoPrioridad);

                if (rqtTipoPrioridad.RequestId != responseTD.CorrelationId)
                    throw new ApplicationException("Error");

                return responseTD.ListaTipoPrioridad;

            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }
        }

#endregion

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<eTipoParticipacion> GetListaTipoParticip(eTipoParticipacion oeTipoParticipacion)
        {
            try
            {
                TipoParticipRequest rqtTipoParticip = new TipoParticipRequest();
                rqtTipoParticip.RequestId = NewRequestId;
                rqtTipoParticip.AccessToken = AccessToken;
                rqtTipoParticip.ClientTag = ClientTag;
                rqtTipoParticip.LoadOptions = new string[] { "TipoParticipLista" };
                rqtTipoParticip.CtrTipoPartic = new eTipoParticipacion
                {
                    EstTipoParticipacion = oeTipoParticipacion.EstTipoParticipacion,
                };

                TipoParticipResponse responseTD = GestionServiceClient.GetListaTipoParticip(rqtTipoParticip);

                if (rqtTipoParticip.RequestId != responseTD.CorrelationId)
                    throw new ApplicationException("Error");

                return responseTD.ListaParticip;

            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }
        }

#region Class: Tipo de Prioridad

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<eUsuario> GetListaUsuarioPer(eUsuario oUsuarioPer)
        {
            try
            {
                UsuarioPerRequest rqtUsuarioPer = new UsuarioPerRequest();
                rqtUsuarioPer.RequestId = NewRequestId;
                rqtUsuarioPer.AccessToken = AccessToken;
                rqtUsuarioPer.ClientTag = ClientTag;
                rqtUsuarioPer.LoadOptions = new string[] { "UsuarioPerLista" };
                rqtUsuarioPer.CtrUsuarioPer = new eUsuario
                {
                    Codigo = oUsuarioPer.Codigo,
                    IdeUsuario = oUsuarioPer.IdeUsuario,
                    NombPers = oUsuarioPer.NombPers,
                    Pers = new ePersonal {
                        DNI = (oUsuarioPer.Pers == null ? "" : oUsuarioPer.Pers.DNI)
                    }
                };

                UsuarioPerResponse responseTD = GestionServiceClient.GetListaUsuarioPer(rqtUsuarioPer);

                if (rqtUsuarioPer.RequestId != responseTD.CorrelationId)
                    throw new ApplicationException("Error");

                return responseTD.ListaUsuarioPer;

            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message + " Error:" + ex.Message);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<eUsuario> GetListaUsuarioGrupo(eUsuario oUsuarioPer)
        {
            try
            {
                UsuarioPerRequest rqtUsuarioPer = new UsuarioPerRequest();
                rqtUsuarioPer.RequestId = NewRequestId;
                rqtUsuarioPer.AccessToken = AccessToken;
                rqtUsuarioPer.ClientTag = ClientTag;
                rqtUsuarioPer.LoadOptions = new string[] { "UsuarioGrupoLista" };
                rqtUsuarioPer.CtrUsuarioPer = new eUsuario
                {
                    NombPers = oUsuarioPer.NombPers
                };

                UsuarioPerResponse responseTD = GestionServiceClient.GetListaUsuarioGrupo(rqtUsuarioPer);

                if (rqtUsuarioPer.RequestId != responseTD.CorrelationId)
                    throw new ApplicationException("Error");

                return responseTD.ListaUsuarioPer;

            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }
        }
        
#endregion

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public Int64 SetUsuParticipante(eParticipante oUsuarioParticip)
        {
            try
            {
                UsuParticipRequest rqtUsuParticip = new UsuParticipRequest();
                rqtUsuParticip.RequestId = NewRequestId;
                rqtUsuParticip.AccessToken = AccessToken;
                rqtUsuParticip.ClientTag = ClientTag;
                rqtUsuParticip.LoadOptions = new string[] { "UsuarioParticipanteAdd" };
                rqtUsuParticip.CtrUsuPart = new eParticipante
                {
                    CodiUsuPart = oUsuarioParticip.CodiUsuPart,
                    TipoOper = oUsuarioParticip.TipoOper,
                    CodiOper = oUsuarioParticip.CodiOper,
                    TipoPart = oUsuarioParticip.TipoPart,
                    ApruOper = oUsuarioParticip.ApruOper,
                    EnviNoti = oUsuarioParticip.EnviNoti,
                    FechNoti = oUsuarioParticip.FechNoti,
                    EstaUsuaPart = oUsuarioParticip.EstaUsuaPart,
                    CodiUsu = oUsuarioParticip.CodiUsu,
                    Reenvio = oUsuarioParticip.Reenvio,
                    Envio = oUsuarioParticip.Envio
                };

                UsuParticipResponse response = GestionServiceClient.SetUsuParticipante(rqtUsuParticip);

                if (rqtUsuParticip.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                return response.AddUsuPartip;
            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public Int64 UpdateUsuParticipante(eParticipante oUsuarioParticip)
        {
            try
            {
                UsuParticipRequest rqtUsuParticip = new UsuParticipRequest();
                rqtUsuParticip.RequestId = NewRequestId;
                rqtUsuParticip.AccessToken = AccessToken;
                rqtUsuParticip.ClientTag = ClientTag;
                rqtUsuParticip.LoadOptions = new string[] { "UsuarioParticipanteUpdate" };
                rqtUsuParticip.CtrUsuPart = new eParticipante
                {
                    CodiUsuPart = oUsuarioParticip.CodiUsuPart,
                    TipoOper = oUsuarioParticip.TipoOper,
                    CodiOper = oUsuarioParticip.CodiOper,
                    TipoPart = oUsuarioParticip.TipoPart,                 
                    CodiUsu = oUsuarioParticip.CodiUsu,
                    ConfLect = oUsuarioParticip.ConfLect                   
                };

                UsuParticipResponse response = GestionServiceClient.UpdateUsuParticipante(rqtUsuParticip);

                if (rqtUsuParticip.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                return response.AddUsuPartip;
            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }
        }

        
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public Int64 SetEmpresaAdd(eEmpresa oeEmpresa)
        {
            try
            {
                EmpresaRequest RqtEmpresa = new EmpresaRequest();

                RqtEmpresa.RequestId = NewRequestId;
                RqtEmpresa.AccessToken = AccessToken;
                RqtEmpresa.ClientTag = ClientTag;
                RqtEmpresa.LoadOptions = new string[] { "EmpresaAdd" };
                RqtEmpresa.CtrEmpresa = new eEmpresa 
                {
                    Type = oeEmpresa.Type,
                    RucEmpr = oeEmpresa.RucEmpr,
                    RazoSoci = oeEmpresa.RazoSoci,
                    DireEmpr = oeEmpresa.DireEmpr,
                    CodiUbig = oeEmpresa.CodiUbig,
                    FechRegi = oeEmpresa.FechRegi,
                    CodiUsu = oeEmpresa.CodiUsu,
                    EstEmpr = oeEmpresa.EstEmpr
                };

                EmpresaResponse response = GestionServiceClient.SetEmpresaAdd(RqtEmpresa);

                if (RqtEmpresa.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                return response.AddEmpresa;
            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);  
            
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public IList<eEmpresa> GetEmpresa (eEmpresa oEmpresa)
        {
            try
            {
                EmpresaRequest RqtEmpresa = new EmpresaRequest();

                RqtEmpresa.RequestId = NewRequestId;
                RqtEmpresa.AccessToken = AccessToken;
                RqtEmpresa.ClientTag = ClientTag;
                RqtEmpresa.LoadOptions = new string[] { "EmpresaList" };
                RqtEmpresa.CtrEmpresa = new eEmpresa
                {
                    RucEmpr = oEmpresa.RucEmpr,
                    RazoSoci = oEmpresa.RazoSoci,
                    EstEmpr = oEmpresa.EstEmpr
                };

                LEmpresaResponse response = GestionServiceClient.GetEmpresa(RqtEmpresa);

                if (RqtEmpresa.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                return response.EmpresaLista;
            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);

            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public Int64 SetAutorizaAdd(eAutorizador oeAutorizador)
        {
            try
            {
                AutorizaRequest RqtAutoriza = new AutorizaRequest();
                RqtAutoriza.RequestId = NewRequestId;
                RqtAutoriza.AccessToken = AccessToken;
                RqtAutoriza.ClientTag= ClientTag;
                RqtAutoriza.LoadOptions= new string[]{"AutorizaAdd"};
                RqtAutoriza.CtrAutoriza = new eAutorizador
                { Type = oeAutorizador.Type,
                  CodiUsuPart = oeAutorizador.CodiUsuPart,
                  CodiOper = oeAutorizador.CodiOper,
                  TipoOper = oeAutorizador.TipoOper,
                  RespUsuAuto = oeAutorizador.RespUsuAuto,
                  FechUsuAuto = oeAutorizador.FechUsuAuto,
                  ComeUsuAuto = oeAutorizador.ComeUsuAuto,
                  EstaAuto = oeAutorizador.EstaAuto
                };

                AutorizaResponse response = GestionServiceClient.SetAutorizaAdd(RqtAutoriza);

                if(RqtAutoriza.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                return response.AddAutoriza;
            }
            catch (Exception ex)
            {
               string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
               throw new FaultException(message);  
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<eTipoEvento> GetTipoEvento(eTipoEvento oeTipoEvento)
        {
            try
            {
                TipoEventoRequest rqtTipoEvento = new TipoEventoRequest();
                rqtTipoEvento.RequestId = NewRequestId;
                rqtTipoEvento.AccessToken = AccessToken;
                rqtTipoEvento.ClientTag = ClientTag;
                rqtTipoEvento.LoadOptions = new string[] { "TipoEventoLista" };
                rqtTipoEvento.CtrTipoEvento = new eTipoEvento
                {
                    EstTipoEvento = oeTipoEvento.EstTipoEvento
                };

                TipoEventoResponse response = GestionServiceClient.GetTipoEvento(rqtTipoEvento);

                if (rqtTipoEvento.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                return response.ListaEvento;

            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<eTipoOperacion> GetTipoOperacion(eTipoOperacion oeTipoOperacion)
        {
            try
            {
                TipoOperacionRequest rqtTipoOper = new TipoOperacionRequest();
                rqtTipoOper.RequestId = NewRequestId;
                rqtTipoOper.AccessToken = AccessToken;
                rqtTipoOper.ClientTag = ClientTag;
                rqtTipoOper.LoadOptions = new string[] { "TipoOperacionLista" };
                rqtTipoOper.CtrTipoOper = new eTipoOperacion
                {
                    EstTipoOperacion = oeTipoOperacion.EstTipoOperacion
                };

                TipoOperacionResponse response = GestionServiceClient.GetTipoOperacion(rqtTipoOper);

                if (rqtTipoOper.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                return response.ListOperacion;
            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<eRol> GetTipoOperacion(eRol oeRol)
        {
            try
            {
                RolRequest rqtTipoRol = new RolRequest();
                rqtTipoRol.RequestId = NewRequestId;
                rqtTipoRol.AccessToken = AccessToken;
                rqtTipoRol.ClientTag = ClientTag;
                rqtTipoRol.LoadOptions = new string[] { "TipoRolLista" };
                rqtTipoRol.CtrRol = new eRol
                {
                    EstTipoRol = oeRol.EstTipoRol
                };

                RolResponse response = GestionServiceClient.GetTipoRol(rqtTipoRol);

                if (rqtTipoRol.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                return response.ListaRol;
            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<eTipoCargo> GetTipoCargo(eTipoCargo oTipoCargo)
        {
            try
            {
                TipoCargoRequest rqtTipoCargo = new TipoCargoRequest();
                rqtTipoCargo.RequestId = NewRequestId;
                rqtTipoCargo.AccessToken = AccessToken;
                rqtTipoCargo.ClientTag = ClientTag;
                rqtTipoCargo.LoadOptions = new string[] { "TipoCargoLista" };
                rqtTipoCargo.CtrTipoCargo = new eTipoCargo
                {
                    EstCargo = oTipoCargo.EstCargo
                };

                TipoCargoResponse response = GestionServiceClient.GetTipoCargo(rqtTipoCargo);

                if (rqtTipoCargo.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                return response.ListaTipoCargo;
            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<eArea> GetTipoArea(eArea oTipoArea)
        {

            try
            {
                TipoAreaRequest rqtTipoArea = new TipoAreaRequest();
                rqtTipoArea.RequestId = NewRequestId;
                rqtTipoArea.AccessToken = AccessToken;
                rqtTipoArea.ClientTag = ClientTag;
                rqtTipoArea.LoadOptions = new string[] { "TipoAreaLista" };
                rqtTipoArea.CtrTipoArea = new eArea
                {
                    EstaAre = oTipoArea.EstaAre
                };

                TipoAreaResponse response = GestionServiceClient.GetTipoArea(rqtTipoArea);

                if (rqtTipoArea.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                return response.ListaTipoArea;

            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }

        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<eGrupo> GetTipoGrupo(eGrupo oTipoGrupo)
        {

            try
            {
                TipoGrupoRequest rqtTipoGrupo = new TipoGrupoRequest();
                rqtTipoGrupo.RequestId = NewRequestId;
                rqtTipoGrupo.AccessToken = AccessToken;
                rqtTipoGrupo.ClientTag = ClientTag;
                rqtTipoGrupo.LoadOptions = new string[] { "TipoGrupoLista" };
                rqtTipoGrupo.CtrTipoGrupo = new eGrupo
                {
                    EstGrup = oTipoGrupo.EstGrup
                };

                TipoGrupoResponse response = GestionServiceClient.GetTipoGrupo(rqtTipoGrupo);

                if (rqtTipoGrupo.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                return response.ListaTipoGrupo;
            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }

        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<eTipoUsuario> GetTipoUsuario(eTipoUsuario oTipoUsuario)
        {

            try
            {
                TipoUsuarioRequest rqtTipoUsuario = new TipoUsuarioRequest();
                rqtTipoUsuario.RequestId = NewRequestId;
                rqtTipoUsuario.AccessToken = AccessToken;
                rqtTipoUsuario.ClientTag = ClientTag;
                rqtTipoUsuario.LoadOptions = new string[] { "TipoUsuarioLista" };
                rqtTipoUsuario.CtrTipoUsuario = new eTipoUsuario
                {
                    EstaTipUsu = oTipoUsuario.EstaTipUsu
                };

                TipoUsuarioResponse response = GestionServiceClient.GetTipoUsuario(rqtTipoUsuario);

                if (rqtTipoUsuario.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                return response.ListaTipoUsuario;
            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }

        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<eGrupo> GetTipoUsuGrupo(eGrupo oTipoUsuGrupo)
        {

            try
            {
                TipoGrupoRequest rqtTipoUsuGrupo = new TipoGrupoRequest();
                rqtTipoUsuGrupo.RequestId = NewRequestId;
                rqtTipoUsuGrupo.AccessToken = AccessToken;
                rqtTipoUsuGrupo.ClientTag = ClientTag;
                rqtTipoUsuGrupo.LoadOptions = new string[] { "TipoUsuGrupoLista" };
                rqtTipoUsuGrupo.CtrTipoGrupo = new eGrupo
                {
                    CodiGrup = oTipoUsuGrupo.CodiGrup,
                    UsuarioGrupo = oTipoUsuGrupo.UsuarioGrupo
                };

                TipoGrupoResponse response = GestionServiceClient.GetTipoUsuGrupo(rqtTipoUsuGrupo);

                if (rqtTipoUsuGrupo.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                return response.ListaTipoGrupo;
            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }

        }

        
        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<eParticipante> GetUserPart(eParticipante oUserPart)
        {

            try
            {
                UsuParticipRequest rqtUserPart = new UsuParticipRequest();
                rqtUserPart.RequestId = NewRequestId;
                rqtUserPart.AccessToken = AccessToken;
                rqtUserPart.ClientTag = ClientTag;
                rqtUserPart.LoadOptions = new string[] { "UserPartLista" };
                rqtUserPart.CtrUsuPart = new eParticipante
                {
                    CodiOper = oUserPart.CodiOper,
                    CodiUsu = oUserPart.CodiUsu
                };

                LUserParticResponse response = GestionServiceClient.GetUserPart(rqtUserPart);

                if (rqtUserPart.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                return response.ListaUsuPart;
            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }

        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<eParticipante> GetUserPartBatch(List<long> listCodiOper, List<long> listCodiUsu)
        {
            try
            {
                UsuParticipRequest rqtUserPart = new UsuParticipRequest();
                rqtUserPart.RequestId = NewRequestId;
                rqtUserPart.AccessToken = AccessToken;
                rqtUserPart.ClientTag = ClientTag;
                rqtUserPart.LoadOptions = new string[] { "UserPartListaBatch" };
                rqtUserPart.ListCodiOper = listCodiOper.ToArray();
                rqtUserPart.ListCodiUsu = listCodiUsu.ToArray();

                LUserParticResponse response = GestionServiceClient.GetUserPartBatch(rqtUserPart);

                if (rqtUserPart.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                return response.ListaUsuPart;
            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }

        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<eVariable> GetListaDesc(eVariable oListaDes)
        {
            try
            {
                ListaDescRequest rqtListaDesc = new ListaDescRequest();
                rqtListaDesc.RequestId = NewRequestId;
                rqtListaDesc.AccessToken = AccessToken;
                rqtListaDesc.ClientTag = ClientTag;
                rqtListaDesc.LoadOptions = new string[] { "ListaDesc" };
                rqtListaDesc.CtrDesList = new eVariable
                {
                   Descrip = oListaDes.Descrip,
                   CodUsu = oListaDes.CodUsu
                };

                ListaDescResponse response = GestionServiceClient.GetListDes(rqtListaDesc);

                if (rqtListaDesc.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                return response.ListDesc;
            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }

        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<eOperaciones> GetListaOper(eOperaciones oOperCrit)
        {
            try
            {
                OperacionRequest rqtListaOper = new OperacionRequest();
                rqtListaOper.RequestId = NewRequestId;
                rqtListaOper.AccessToken = AccessToken;
                rqtListaOper.ClientTag = ClientTag;
                rqtListaOper.LoadOptions = new string[] { "OperLista" };
                rqtListaOper.CtrOper = new eOperaciones
                {
                    Type = oOperCrit.Type,
                    CodUsu = oOperCrit.CodUsu,
                    Fecha = oOperCrit.Fecha
                };

                OperacionResponse response = GestionServiceClient.GetListOper(rqtListaOper);

                if (rqtListaOper.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                return response.OperacionLista;
            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }

        }

        
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public Int64 SetAnulaUserPart(eParticipante oUsuarioParticip)
        {
            try
            {
                UsuParticipRequest rqtUsuParticip = new UsuParticipRequest();
                rqtUsuParticip.RequestId = NewRequestId;
                rqtUsuParticip.AccessToken = AccessToken;
                rqtUsuParticip.ClientTag = ClientTag;
                rqtUsuParticip.LoadOptions = new string[] { "UsuarioPartAnula" };
                rqtUsuParticip.CtrUsuPart = new eParticipante
                {
                    CodiOper = oUsuarioParticip.CodiOper,
                    CodiUsu = oUsuarioParticip.CodiUsu
                };

                UsuParticipResponse response = GestionServiceClient.SetAnulaUserPart(rqtUsuParticip);

                if (rqtUsuParticip.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                return response.AddUsuPartip;
            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }
        }

        
        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<eUsuarioGrupo> GetUsuarioGrupo(eUsuarioGrupo oUsuarioGrupo)
        {
            try
            {
                UsuarioGrupoRequest rqtUsuarioGrupo = new UsuarioGrupoRequest();
                rqtUsuarioGrupo.RequestId = NewRequestId;
                rqtUsuarioGrupo.AccessToken = AccessToken;
                rqtUsuarioGrupo.ClientTag = ClientTag;
                rqtUsuarioGrupo.LoadOptions = new string[] { "ListUsuarioGrupo" };
                rqtUsuarioGrupo.CtrUsuarioGrupo = new eUsuarioGrupo
                {
                    Grupo = new eGrupo
                    {
                        CodiGrup = oUsuarioGrupo.Grupo.CodiGrup,
                        NombGrup = oUsuarioGrupo.Grupo.NombGrup
                    }
                };

                UsuarioGrupoResponse responseTD = GestionServiceClient.GetUsuarioGrupo(rqtUsuarioGrupo);

                if (rqtUsuarioGrupo.RequestId != responseTD.CorrelationId)
                    throw new ApplicationException("Error");

                return responseTD.UsuarioGrupoLista;

            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<eAutorizador> GetAutoriza(eAutorizador oAutoriza)
        {
            try
            {
                AutorizaRequest rqtAutoriza = new AutorizaRequest();
                rqtAutoriza.RequestId = NewRequestId;
                rqtAutoriza.AccessToken = AccessToken;
                rqtAutoriza.ClientTag = ClientTag;
                rqtAutoriza.LoadOptions = new string[] { "AutorizaList" };
                rqtAutoriza.CtrAutoriza = new eAutorizador
                {
                    Type = oAutoriza.Type,
                    CodiOper = oAutoriza.CodiOper,
                    CodiUsuPart = oAutoriza.CodiUsuPart
                };

                LUserAutoResponse response = GestionServiceClient.GetAutorizaList(rqtAutoriza);

                if (rqtAutoriza.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                return response.AutorizaList;

            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public Int64 SetGrupoUserAdd(eUsuarioGrupo oGrupoUser)
        {
            try
            {
                UsuarioGrupoRequest rqtGrupoUser = new UsuarioGrupoRequest();
                rqtGrupoUser.RequestId = NewRequestId;
                rqtGrupoUser.AccessToken = AccessToken;
                rqtGrupoUser.ClientTag = ClientTag;
                rqtGrupoUser.LoadOptions = new string[] { "GrupoUserAdd" };
                rqtGrupoUser.CtrUsuarioGrupo = new eUsuarioGrupo
                {
                    CodiUsuGrup = oGrupoUser.CodiUsuGrup,
                    Usuario = new eUsuario
                    {
                        Codigo = oGrupoUser.Usuario.Codigo
                    },
                    Grupo = new eGrupo 
                    {
                        CodiGrup = oGrupoUser.Grupo.CodiGrup
                    },
                    UsuCrea = oGrupoUser.UsuCrea,
                    FechCrea = oGrupoUser.FechCrea,
                    EstUsuGrup = oGrupoUser.EstUsuGrup
                };

                GrupoUsuarioResponse response = GestionServiceClient.SetGrupoUser(rqtGrupoUser);

                if (rqtGrupoUser.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                return response.GrupoUsuarioAdd;
            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public Int64 SetGrupoAdd(eGrupo oGrupo)
        {
            try
            {
                GrupoRequest rqtGrupo = new GrupoRequest();
                rqtGrupo.RequestId = NewRequestId;
                rqtGrupo.AccessToken = AccessToken;
                rqtGrupo.ClientTag = ClientTag;
                rqtGrupo.LoadOptions = new string[] { "GrupoAdd" };
                rqtGrupo.CtrGrupo = new eGrupo
                {
                    CodiGrup = oGrupo.CodiGrup,
                    NombGrup = oGrupo.NombGrup,
                    FechCrea = oGrupo.FechCrea,
                    UsuCrea = oGrupo.UsuCrea,
                    ComeGrup = oGrupo.ComeGrup,
                    EstGrup = oGrupo.EstGrup
                };

                GrupoResponse response = GestionServiceClient.SetGrupoAdd(ref rqtGrupo);

                if (rqtGrupo.CtrGrupo.CodiGrup > 0)
                {
                    oGrupo.CodiGrup = rqtGrupo.CtrGrupo.CodiGrup;
                }

                if (rqtGrupo.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                return response.AddGrupo;
            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public Int64 SetGrupoUserAnula(eUsuarioGrupo oGrupoUser)
        {
            try
            {
                UsuarioGrupoRequest rqtGrupoUser = new UsuarioGrupoRequest();
                rqtGrupoUser.RequestId = NewRequestId;
                rqtGrupoUser.AccessToken = AccessToken;
                rqtGrupoUser.ClientTag = ClientTag;
                rqtGrupoUser.LoadOptions = new string[] { "GrupoUserAnula" };
                rqtGrupoUser.CtrUsuarioGrupo = new eUsuarioGrupo
                {
                    Grupo = new eGrupo
                    {
                        CodiGrup = oGrupoUser.Grupo.CodiGrup
                    },
                    Usuario = new eUsuario
                    {
                        Codigo = oGrupoUser.Usuario.Codigo
                    }
                   
                  
                };

                GrupoUsuarioResponse response = GestionServiceClient.SetAnulaGrupoUser(rqtGrupoUser);

                if (rqtGrupoUser.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                return response.GrupoUsuarioAdd;
            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<eModuloPagina> GetModuloPagina(eModuloPagina oModulo)
        {

            try
            {
                ConsModPagRequest rqtModPag = new ConsModPagRequest();
                rqtModPag.RequestId = NewRequestId;
                rqtModPag.AccessToken = AccessToken;
                rqtModPag.ClientTag = ClientTag;
                rqtModPag.LoadOptions = new string[] { "ModPagLista" };
                rqtModPag.CtrModPag = new eModuloPagina
                {
                   Estado = oModulo.Estado
                };

                ConsModPagResponse response = GestionServiceClient.GetModuloPagina(rqtModPag);

                if (rqtModPag.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                return response.ListaModPag;
            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }

        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public Int64 SetAccesoSistema(eAccesoSistema oAcceso)
        {
            try
            {
                AccesoRequest rqtAcceso = new AccesoRequest();
                rqtAcceso.RequestId = NewRequestId;
                rqtAcceso.AccessToken = AccessToken;
                rqtAcceso.ClientTag = ClientTag;
                rqtAcceso.LoadOptions = new string[] { "AccesoAdd" };
                rqtAcceso.CtrAcceso = new eAccesoSistema
                {
                    Codigo = oAcceso.Codigo,
                    UsuarioCreacion = new eUsuario { Codigo = oAcceso.UsuarioCreacion.Codigo },
                    FechaModificacion = oAcceso.FechaModificacion,
                    Estado = oAcceso.Estado,
                    Usuario = new eUsuario { Codigo = oAcceso.Usuario.Codigo },
                    Pagina = new eModuloPagina { Codigo = oAcceso.Pagina.Codigo}
                };

                AccesoResponse response = GestionServiceClient.SetAccesoSistema(rqtAcceso);

                if (rqtAcceso.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                return response.AddAcceso;
            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<eAccesoSistema> GetAccesoSistema(eAccesoSistema oAcceso)
        {
            try
            {
                AccesoRequest rqtAcceso = new AccesoRequest();
                rqtAcceso.RequestId = NewRequestId;
                rqtAcceso.AccessToken = AccessToken;
                rqtAcceso.ClientTag = ClientTag;
                rqtAcceso.LoadOptions = new string[] { "AccesoList" };
                rqtAcceso.CtrAcceso = new eAccesoSistema
                {
                    Usuario = new eUsuario { Codigo = oAcceso.Usuario.Codigo },
                    Pagina = new eModuloPagina { Codigo = oAcceso.Pagina.Codigo }
                };

                LAccesoResponse response = GestionServiceClient.GetAccesoSistema(rqtAcceso);

                if (rqtAcceso.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                return response.ListaAcceso;
            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public Int64 SetAnulaAcceso(eAccesoSistema oAcceso)
        {
            try
            {
                AccesoRequest rqtAcceso = new AccesoRequest();
                rqtAcceso.RequestId = NewRequestId;
                rqtAcceso.AccessToken = AccessToken;
                rqtAcceso.ClientTag = ClientTag;
                rqtAcceso.LoadOptions = new string[] { "AccesoAnula" };
                rqtAcceso.CtrAcceso = new eAccesoSistema
                {
                    Usuario = new eUsuario { Codigo = oAcceso.Usuario.Codigo },
                    Pagina = new eModuloPagina { Codigo = oAcceso.Pagina.Codigo }
                };

                AccesoResponse response = GestionServiceClient.SetAnulaAcceso(rqtAcceso);

                if (rqtAcceso.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                return response.AddAcceso;
            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public Int64 SetAddPersonal(ePersonal oPersonal)
        {
            try
            {
                PersonalRequest rqtPers = new PersonalRequest();
                rqtPers.RequestId = NewRequestId;
                rqtPers.AccessToken = AccessToken;
                rqtPers.ClientTag = ClientTag;
                rqtPers.LoadOptions = new string[] { "PersonalAdd" };
                rqtPers.CtrPersonal = new ePersonal
                {
                    CodigoPersona = oPersonal.CodigoPersona,
                    NombPers = oPersonal.NombPers,
                    ApePers = oPersonal.ApePers,
                    SexoPers = oPersonal.SexoPers,
                    EmaiPers = oPersonal.EmaiPers,
                    EmaiTrab = oPersonal.EmaiTrab,
                    FechNac = oPersonal.FechNac,
                    TelePers = oPersonal.TelePers,
                    AnexPers = oPersonal.AnexPers,
                    CeluPers = oPersonal.CeluPers,
                    EstaPers = oPersonal.EstaPers,
                    CodiTipUsu = oPersonal.CodiTipUsu,
                    CodiArea = oPersonal.CodiArea,
                    CodiCarg = oPersonal.CodiCarg,
                    ClasPers = oPersonal.ClasPers,
                    RucEmpr = oPersonal.RucEmpr,
                    DNI = oPersonal.DNI,
                    DirePers = oPersonal.DirePers
                };

                PersonalResponse response = GestionServiceClient.SetAddPersonal(ref rqtPers);

                if (rqtPers.CtrPersonal.CodigoPersona > 0)
                {
                    oPersonal.CodigoPersona = rqtPers.CtrPersonal.CodigoPersona;
                    
                }

                if (rqtPers.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                return response.AddPersonal;
            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }
        }


        [DataObjectMethod(DataObjectMethodType.Insert)]
        public Int64 SetAddUsuario(eUsuario oUser)
        {
            try
            {
                UsuarioPerRequest rqtUser = new UsuarioPerRequest();
                rqtUser.RequestId = NewRequestId;
                rqtUser.AccessToken = AccessToken;
                rqtUser.ClientTag = ClientTag;
                rqtUser.LoadOptions = new string[] { "UsuarioAdd" };
                rqtUser.CtrUsuarioPer = new eUsuario
                {
                    Codigo = oUser.Codigo,
                    IdeUsuario = oUser.IdeUsuario,
                    Pasword = oUser.Pasword,
                    FirmaElectronica = oUser.FirmaElectronica,
                    Estado = oUser.Estado,
                    FechaRegistro = oUser.FechaRegistro,
                    FechaUltimoAcceso = oUser.FechaUltimoAcceso,
                    FechaModificacion = oUser.FechaModificacion,
                    IntentoErradoPasword = oUser.IntentoErradoPasword,
                    IntentoErradoFirma = oUser.IntentoErradoFirma,
                    TermUsu = oUser.TermUsu,
                    UsuCrea = oUser.UsuCrea,
                    CodiCnx = oUser.CodiCnx,
                    CodigoPersona = oUser.CodigoPersona,
                    CodiRol = oUser.CodiRol,
                    CodiTipUsu = oUser.CodiTipUsu,
                    ClasUsu = oUser.ClasUsu,
                    ExpiClav = oUser.ExpiClav,
                    ExpiFirm = oUser.ExpiFirm,
                    FechExpiClav = oUser.FechExpiClav,
                    FechExpiFirm = oUser.FechExpiFirm
                };

                UsuarioResponse response = GestionServiceClient.SetAddUsuario(rqtUser);

                if (rqtUser.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                return response.AddUser;
            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public Int64 SetUsuarioEstadp(eUsuario oUser)
        {
            try
            {
                UsuarioPerRequest rqtUser = new UsuarioPerRequest();
                rqtUser.RequestId = NewRequestId;
                rqtUser.AccessToken = AccessToken;
                rqtUser.ClientTag = ClientTag;
                rqtUser.LoadOptions = new string[] { "UsuarioPer" };
                rqtUser.CtrUsuarioPer = new eUsuario
                {
                    CodiTipUsu = oUser.CodiTipUsu,
                    Codigo = oUser.Codigo,
                    CodigoPersona = oUser.CodigoPersona,
                    Pasword = oUser.Pasword,
                    FirmaElectronica = oUser.FirmaElectronica                        
                };

                UsuarioResponse response = GestionServiceClient.SetUsuarioPer(rqtUser);

                if (rqtUser.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                return response.AddUser;
            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<eAccesoSistema> GetMenuUsuario(eAccesoSistema oAcceso)
        {
            try
            {
                AccesoRequest rqtMenu = new AccesoRequest();
                rqtMenu.RequestId = NewRequestId;
                rqtMenu.AccessToken = AccessToken;
                rqtMenu.ClientTag = ClientTag;
                rqtMenu.LoadOptions = new string[] { "MenuUsuario" };
                rqtMenu.CtrAcceso = new eAccesoSistema
                {
                    Usuario = new eUsuario { Codigo = oAcceso.Usuario.Codigo }
                };

                LAccesoResponse response = GestionServiceClient.GetMenuUsuario(rqtMenu);

                if (rqtMenu.RequestId != response.CorrelationId)
                    throw new ApplicationException("Error");

                return response.ListaAcceso;
            }
            catch (Exception ex)
            {
                string message = String.Format("Se encontro '{0}' excepcion en el servicio", ex.GetType().ToString());
                throw new FaultException(message);
            }
        }

    }

}