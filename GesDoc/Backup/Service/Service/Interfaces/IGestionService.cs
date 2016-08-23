using System;
using System.Collections.Generic;
using System.ServiceModel;

//using Service.Message.Entity.Response;
//using Service.Message.Entity.Request;
using Service.Message.Resquest_Response;

namespace Service.Service.Interfaces
{
    [ServiceContract]
    public interface IGestionService
    {

#region Class: Tipo de Acceso

        [OperationContract]
        TipoAccesoResponse GetListaTipoAcceso(TipoAccesoRequest RqtListaTipoAcceso);

#endregion

#region Class: Tipo de Prioridad

        [OperationContract]
        TipoPrioridadResponse GetListaTipoPrioridad(TipoPrioridadRequest RqtListaTipoPrioridad);

#endregion

#region Class: Empresa

        [OperationContract]
        EmpresaResponse SetEmpresaAdd(EmpresaRequest RqtEmpresa);

#endregion

#region Class: Participante

        [OperationContract]
        TipoParticipResponse GetListaTipoParticip(TipoParticipRequest RqtListaTipoParticip);

#endregion

#region Class: Tipo Evento

        [OperationContract]
        TipoEventoResponse GetTipoEvento(TipoEventoRequest RqtTipoEvento);

#endregion

#region Class: Tipo Operacion

        [OperationContract]
        TipoOperacionResponse GetTipoOperacion(TipoOperacionRequest RqtTipoOperacion);

#endregion

#region Class: Tipo Rol 

        [OperationContract]
        RolResponse GetTipoRol(RolRequest RqtRol);

#endregion

#region Class: Tipo Cargo

        [OperationContract]
        TipoCargoResponse GetTipoCargo(TipoCargoRequest RqtTipocargo);

#endregion

#region Class: Tipo Area

        [OperationContract]
        TipoAreaResponse GetTipoArea(TipoAreaRequest RqtTipoArea);

#endregion

#region Class: Tipo Grupo

        [OperationContract]
        TipoGrupoResponse GetTipoGrupo(TipoGrupoRequest RqtTipoGrupo);

#endregion

#region Class: Tipo Usuario

        [OperationContract]
        TipoUsuarioResponse GetTipoUsuario(TipoUsuarioRequest RqtTipoUsuario);

#endregion

#region Class: Tipo Usuario Grupo

        [OperationContract]
        TipoGrupoResponse GetTipoUsuGrupo(TipoGrupoRequest RqtTipoUsuGrupo);

#endregion

#region Class: Autorizacion

        [OperationContract]
        AutorizaResponse SetAutorizaAdd(AutorizaRequest RqtAutoriza);

#endregion

        
#region Lista De Usuario(s)

        [OperationContract]
        UsuarioPerResponse GetListaUsuarioPer(UsuarioPerRequest RqtUsuarioPerRequest);

        [OperationContract]
        UsuarioPerResponse GetListaUsuarioGrupo(UsuarioPerRequest RqtListaUsuarioPer);

        [OperationContract]
        UsuParticipResponse SetUsuParticipante(UsuParticipRequest RqtUsuParticipRequest);

        [OperationContract]
        UsuParticipResponse UpdateUsuParticipante(UsuParticipRequest RqtUsuParticip);

#endregion

#region Class: Usuario Participante

        [OperationContract]
        LUserParticResponse GetUserPart(UsuParticipRequest RqtUserPart);

        [OperationContract]
        LUserParticResponse GetUserPartBatch(UsuParticipRequest RqtUserPart);

        [OperationContract]
        UsuParticipResponse SetAnulaUserPart(UsuParticipRequest RqtAnulaUserP);

#endregion

#region Class: ?????

        [OperationContract]
        ListaDescResponse GetListDes(ListaDescRequest RqtListaDesc);

#endregion

#region Class: Operaciones

        [OperationContract]
        OperacionResponse GetListOper(OperacionRequest RqtListOper);

#endregion

#region Class: Usuario Grupo

        [OperationContract]
        UsuarioGrupoResponse GetUsuarioGrupo(UsuarioGrupoRequest RqtUsuarioGrupo);

#endregion

#region Class : Lista Autorizador
        [OperationContract]
        LUserAutoResponse GetAutorizaList(AutorizaRequest RqtAutoriza);
#endregion

        [OperationContract]
        GrupoUsuarioResponse SetGrupoUser(UsuarioGrupoRequest RqtGrupoUser);

        [OperationContract]
        GrupoResponse SetGrupoAdd(ref GrupoRequest RqtGrupo);

        [OperationContract]
        GrupoUsuarioResponse SetAnulaGrupoUser(UsuarioGrupoRequest RqtGrupoUser);

        [OperationContract]
        ConsModPagResponse GetModuloPagina(ConsModPagRequest RqtModPag);

        [OperationContract]
        AccesoResponse SetAccesoSistema(AccesoRequest RqtAcceso);

        [OperationContract]
        LAccesoResponse GetAccesoSistema(AccesoRequest RqtAccesolist);

        [OperationContract]
        AccesoResponse SetAnulaAcceso(AccesoRequest RqtAcceso);

        [OperationContract]
        PersonalResponse SetAddPersonal(ref PersonalRequest RqtPersonal);

        [OperationContract]
        UsuarioResponse SetAddUsuario(UsuarioPerRequest RqtUser);

        [OperationContract]
        UsuarioResponse SetUsuarioPer(UsuarioPerRequest RqtUser);

        [OperationContract]
        LEmpresaResponse GetEmpresa(EmpresaRequest RqtEmpr);

        [OperationContract]
        LAccesoResponse GetMenuUsuario(AccesoRequest RqtMenu);
    }
}
