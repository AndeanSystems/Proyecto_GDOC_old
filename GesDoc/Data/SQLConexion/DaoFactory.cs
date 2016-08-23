using System;
using System.Collections.Generic;

namespace DataObjects.Sources.AdoNet.SqlServer
{
    public class DaoFactory : DataObjects.Dao.DaoFactory
    {

        public override Interfaces.IDocDigDao DocDigDao
        {
            get { return new DocDigDao(); }
        }

        public override Interfaces.IDocumentoElectronicoDao DocumentoElectronicoDao
        {
            get { return new DocumentoElectronicoDao(); }
        }

        public override Interfaces.IDocDigListTD DocDigTDDao
        {
            get { return new DocDigTDDao(); }
        }

        public override Interfaces.ITipoAccesoDao TipoAccesoDao
        {
            get { return new TipoAccesoDao(); }
        }

        public override Interfaces.ITipoPrioridadDao TipoPrioridadDao
        {
            get { return new TipoPrioridadDao(); }
        }

        public override DataObjects.Interfaces.ITipoParticipDao TipoParticipDao
        {
            get { return new TipoParticipDao(); }
        }

        public override DataObjects.Interfaces.IUsuarioPerDao UsuarioPerDao
        {
            get { return new UsuarioPerDao(); }
        }

        public override DataObjects.Interfaces.IUsuarioParticipanteDao UsuarioParticipanteDao
        {
            get { return new UsuarioParticipanteDao(); }
        }

        public override DataObjects.Interfaces.ILogOperacionDao LogOperacionDao
        {
            get { return new LogOperacionDao(); }
        }

        public override DataObjects.Interfaces.IMensajeAlertaDao MensajeAlertaDao
        {
            get { return new MensajeAlertaDao(); }
        }

        public override DataObjects.Interfaces.IEmpresaDao EmpresaDao
        {
            get { return new EmpresaDao(); }
        }

        public override DataObjects.Interfaces.IAutorizadorDao AutorizadorDao
        {
            get { return new AutorizadorDao(); }
        }

        public override DataObjects.Interfaces.ITipoEventoDao TipoEventoDao
        {
            get { return new TipoEventoDao(); }
        }

        public override DataObjects.Interfaces.ITipoOperacionDao TipoOperacionDao
        {
            get { return new TipoOperacionDao(); }
        }

        public override DataObjects.Interfaces.IRolDao RolDao
        {
            get { return new RolDao(); }
        }

        public override DataObjects.Interfaces.ITipoCargoDao TipoCargoDao
        {
            get { return new TipoCargoDao(); }
        }

        public override DataObjects.Interfaces.ITipoAreaDao TipoAreaDao
        {
            get { return new TipoAreaDao(); }
        }

        public override DataObjects.Interfaces.ITipoGrupoDao TipoGrupoDao
        {
            get { return new TipoGrupoDao(); }
        }

        public override DataObjects.Interfaces.ITipoUsuarioDao TipoUsuarioDao
        {
            get { return new TipoUsuarioDao(); }
        }

        public override DataObjects.Interfaces.IListMensAlerDao ListMensAlerDao
        {
            get { return new ListMensAlerDao(); }
        }

        public override DataObjects.Interfaces.IListUsuarioGrDao ListUsuarioGrDao
        {
            get { return new ListUsuarioGrDao(); }
        }

        public override DataObjects.Interfaces.IDocAdjDao DocAdjDao
        {
            get { return new DocAdjDao(); }
        }

        public override DataObjects.Interfaces.ILDocElecDao LDocElecDao
        {
            get { return new LDocElecDao(); }
        }

        public override DataObjects.Interfaces.IDocDigRefDao DogDigRefDao
        {
            get { return new DocDigRefDao(); }
        }

        public override DataObjects.Interfaces.ILDocDigDao LDocDigDao
        {
            get { return new LDocDigDao(); }
        }

        public override DataObjects.Interfaces.ILDocDigRefDao LDocDigRefDao
        {
            get { return new LDocDigRefDao(); }
        }

        public override DataObjects.Interfaces.ILUserPartDao LUserPartDao
        {
            get { return new LUserPartDao(); }
        }

        public override DataObjects.Interfaces.IListaDescripcionDao ListaDescripcionDao
        {
            get { return new ListaDescripcionDao(); }
        }

        public override DataObjects.Interfaces.IOperacionesDao OperacionDao
        {
            get { return new OperacionDao(); }
        }

        public override DataObjects.Interfaces.IMesaVirtualDao MesaVirtualDao
        {
            get { return new MesaVirtualDao(); }
        }

        public override DataObjects.Interfaces.IBuscarDocumentosDao BDocDigDao
        {
            get { return new BuscarDocumentosDao(); }
        }

        public override DataObjects.Interfaces.IBandejaDao BandejaDao
        {
            get { return new BandejaDao(); }
        }

        public override DataObjects.Interfaces.IBandejaMVDao BandejaMVDao
        {
            get { return new BandejaMVDao(); }
        }

        public override DataObjects.Interfaces.IInserMesaVirtualDao InserMesaVirtualDao
        {
            get { return new InserMesaVirtualDao(); }
        }

        public override DataObjects.Interfaces.IUsuarioGrupoDao UsuarioGrupoDao
        {
            get { return new UsuarioGrupoDao(); }
        }

        public override DataObjects.Interfaces.ITipoMesaVirtualDao TipoMesaVirtualDao
        {
            get { return new TipoMesaVirtualDao(); }
        }

        public override DataObjects.Interfaces.IConsAutorizadorDao ConsAutorizadorDao
        {
            get { return new ConsAutorizadorDao(); }
        }

        public override DataObjects.Interfaces.IComentMesaDao ComentMesaDao
        {
            get { return new ComentMesaDao(); }
        }

        public override DataObjects.Interfaces.IConsComenMVDao ConsComenMVDao
        {
            get { return new ConsComenMVDao(); }
        }

        public override DataObjects.Interfaces.IBuscarLogOperacionDao BuscarLogOper
        {
            get { return new BuscarLogOperacionDao(); }
        }

        public override DataObjects.Interfaces.IGrupoUsuariosDao GrupoUsuariosDao
        {
            get { return new GrupoUsuariosDao(); }
        }

        public override DataObjects.Interfaces.IGrupoDao GrupoDao
        {
            get { return new GrupoDao(); }
        }

        public override DataObjects.Interfaces.IConsModuPagDao ConsModuPagDao
        {
            get { return new ConsModuPagDao(); }
        }

        public override DataObjects.Interfaces.IAccesoDao AccesoDao
        {
            get { return new AccesoDao(); }
        }

        public override DataObjects.Interfaces.IPersonalDao PersonalDao
        {
            get { return new PersonalDao(); }
        }

        public override DataObjects.Interfaces.IUbigeoDao UbigeoDao
        {
            get { return new UbigeoDao(); }
        }

        public override DataObjects.Interfaces.IConsMenuUsuaDao ConsMenuUsuaDao
        {
            get { return new ConsMenuUsuaDao(); }
        }

        public override DataObjects.Interfaces.IPlanGestionDao PlanGestionDao
        {
            get { return new PlanGestionDao(); }
        }
     }
}
