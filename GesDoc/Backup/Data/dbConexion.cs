using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Data
{
    public class dbConexion
    {

#region "Objeto de Conexion"

        private SqlConnection _dataBase;

        public SqlConnection miconexion
        {
            get {
                Cargar();
                return _dataBase; 
            }
        }

        private void Cargar()
        { 
            try
            {
                if (_dataBase != null)
                {
                    if (_dataBase.State != ConnectionState.Closed)
                    {
                        _dataBase.Close();
                        _dataBase.Dispose();
                    }
                }

                _dataBase = new SqlConnection();
                _dataBase.ConnectionString = ConfigurationSettings.AppSettings["CnnBD"];
                _dataBase.Open();
            }
            catch (Exception ex)
            { }
        }


        //public Database db()
        //{
        //    Database _dataBase;
        //    return _dataBase = DatabaseFactory.CreateDatabase("ADO.NET.SqlServer");
        //}

#endregion


#region "Store Procedures"
    public String SetInsertarTBL_RECEPCION = "SP_INS_TBL_RECEPCION";
    public String SetActualizarTBL_RECEPCION = "SP_UPD_TBL_RECEPCION";
    public String SetEliminarTBL_RECEPCION  = "SP_DEL_TBL_RECEPCION";
    public String GetConsultarTBL_RECEPCION  = "SP_SEL_TBL_RECEPCION";


    public String sSPInsertarAcceso = "SP_FPC_InsertAccesoSistema";
    public String sSPAnulaAccesoSistema = "SP_FPC_UpdaAnulaAcceso";
    public String sSPConsAccesoSistema = "SP_FPC_ConsAccesoSistema";

    public String sSPInsertarAutoriza = "SP_FPC_InsertUsuarioAutorizador";

    public String sSPConsulBandejaDoc = "SP_FPC_ConsBandejaDocElec";

    public String sSPListaRol = "SP_FPC_ConsTipoRol";

    public String sSP_ObetivoEstrategico = "SP_FPC_IUD_ObetivoEstrategico";
    public String sSP_ConsObetivoEstrategico = "SP_FPC_Sel_ObetivoEstrategico";

    public String sSP_ObetivoOperativo = "SP_FPC_IUD_ObetivoOperativo";
    public String sSP_ConsObetivoOperativo = "SP_FPC_Sel_ObetivoOperativo";

    public String sSP_Proyecto = "SP_FPC_IUD_Proyecto";
    public String sSP_ConsProyecto = "SP_FPC_Sel_Proyecto";

    public String sSP_Actividad = "SP_FPC_IUD_Actividad";
    public String sSP_ConsActividad = "SP_FPC_Sel_Actividad";

    public String sSP_ComentarioAvance = "SP_FPC_IUD_ComentarioActividad";
    public String sSP_ConsComentarioAvance = "SP_FPC_Sel_ComentarioAvance";

    public String sSP_Informe = "SP_FPC_ConsInforme";

    public String sSInsertPersonal = "SP_FPC_InsertPersonal";

    public String sSPConsulOper = "SP_FPC_ConsOperDocuUsu";

    public String sSPConsMesaVirtualUsu = "SP_FPC_ConsMesaVirtUsu";

    public String sSPInsertarMensAlert = "SP_FPC_InsertMensajeAlerta";

    public String sSPConsUsuPart = "SP_FPC_ConsUsuaParticipantes";

    public String sSPConsUsuPartBatch = "SP_FPC_ConsUsuaParticipantesBatch";

    public String sSPInsertarLogOper = "SP_FPC_InsertLogOper";
    
    public String sSPConsUsurGruop = "SP_FPC_ConsUsuarioGrupo";

    public String sSPConsultarTipoMensaje = "SP_FPC_ConsMensajeAlerta";
    
    public String sSPConsulDescrip = "SP_FPC_ConsDesAsunto";

    public String sSPConsulDocElec = "SP_FPC_ConsDocuElec";

    public String sSPConsulBandejaMV = "SP_FPC_ConsBandejaMesaVir";

    public String sSPConsulDocDigRef = "SP_FPC_ConsRefeDocuDigi";

    public String sSPConsulDocDig = "SP_FPC_ConsDocuDigi";

    public String sSPInsertarMesaVirtual = "SP_FPC_InsertMesaVirtual";

    public String sSPInsertarGrupoPart = "SP_FPC_InsertGrupoUsuario";

    public String sSPUpdateGrupoPart = "SP_FPC_UpdaAnulaUsuGrup";

    public String sSPInsertarGrupo = "SP_FPC_InsertGrupo";

    public String sSPInsertarEmpresa = "SP_FPC_InsertEmpresa";

    public String sSPConsEmpresa = "SP_FPC_ConsEmpresa";

    public String sSPInsertarDocElec = "SP_FPC_InsertDocumentoElectronico";

    public String sSPConsTipoDocumento = "SP_FPC_ConsTipoDocumento";

    public String sSPInsertRef = "SP_FPC_InsertRefeDocuDigi";

    public String sSPInsertarDocDig = "SP_FPC_InsertDocumentoDigital";

    public String sSPInsertarDocAdj = "SP_FPC_InsertDocumentoAdjunto";
    public String sSPConsDocAdj = "SP_FPC_ConsDocAdj";
    public String sSPAnulaDocAdj = "SP_FPC_UpdaAnulaDocAdj";

    public String sSPConsModuloPagina = "SP_FPC_ConsModuloPag";

    public String sSPConsMenuUser = "SP_FPC_ConMenuUsuario";

    public String sSPConsMesaVirtualComet = "SP_FPC_ConsComentMesa";
    

    public String sSPConsAutoriza = "SP_FPC_ConsUsuarioAutorizador";

    public String sSPInsertarComenMesaVirt = "SP_FPC_InsertComentMesaVirt";

    public String sSPConsulBLogOper = "SP_FPC_BusqLogOperacion";

    public String sSPConsulBDocDig = "SP_FPC_BusqDocuDigi";
    public String sSPConsulBDocElect = "SP_FPC_BusqDocuElec";
    public String sSPConsulBMesaVirtual = "SP_FPC_BusqMesaVirt";
    public String sSPConsulBDocAdj = "SP_FPC_BusqDocuAdju";

    public String sSPConsUsuario = "SP_FPC_ConsUsuarios";

    public String sSPConsUsuarioGrupo = "SP_FPC_ConsUsuaLista";

    public String sSPInsertUsuario = "SP_FPC_InsertUsuario";

    public String sSPUsuarioPer = "SP_FPC_UpdaUsuarioPer";

    public String sSPInsertarUsuParticip = "SP_FPC_InsertUsuarioParticipante";

    public String sSPUpdateUsuParticip = "SP_FPC_UpdateUsuarioParticipante";

    public String sSPAnulaUsuParticip = "SP_FPC_UpdaAnulUsuaPart";

    public String sSPConsUsuGrup = "SP_FPC_ConsUsuarioGrupo";

    public String sSPConsUbigeo = "SP_FPC_ConsUbigeo";

    public String sSPConsultarTipoUsuario = "SP_FPC_ConsTipoUsuario";

    public String sSPConsultarTipoPrioridad = "SP_FPC_ConsTipoPrioridad";

    public String sSPConsultarTipoParticipacion = "SP_FPC_ConsTipoParticipante";

    public String sSPConsTipoOperacion = "SP_FPC_ConsTipoOperacion";

    public String sSPConsTipoMV = "SP_FPC_ConsClaseMesa";

    public String sSPConsTipoGrupo = "SP_FPC_ConsGrupo";

    public String sSPConsTipoEvento = "SP_FPC_ConsTipoEvento";

    public String sSPConsultarTipoCargo = "SP_FPC_ConsCargos";

    public String sSPConsultarTipoArea = "SP_FPC_ConsArea";

    public String sSPConsultarTipoAcceso = "SP_FPC_ConsTipoAcceso";

    

#endregion

    }
}

