using System;
using System.Collections;
using System.Collections.Generic;
using Entity;
using Entity.Entities;
using Entity.Interfaces;
using Common;
using Data;
using Data.SqlConexion;


namespace Business
{
    public class bBuscarDocumentos: IBuscarDocumentos 
    {

        private IBuscarDocumentos _dSqlBuscarDocumentos = new dSqlBuscarDocumentos();

        public IList<eBuscarDocumentos> GetBusDocDig(eBuscarDocumentos sDocDig)
        {
            return _dSqlBuscarDocumentos.GetBusDocDig(sDocDig);
        }

        public IList<eBuscarDocumentos> GetBusDocElect(eBuscarDocumentos sDocElect)
        {
            return _dSqlBuscarDocumentos.GetBusDocElect(sDocElect);
        }

        //  Datos para MesaVirtual
        // ===============================

        public IList<eBuscarDocumentos> GetBusMesaVirtual(eBuscarDocumentos sMesaVirtual)
        {
            return _dSqlBuscarDocumentos.GetBusMesaVirtual(sMesaVirtual);
        }     

        public IList<eBuscarDocumentos> GetBuscarAdjunto(eBuscarDocumentos sBuscarAdjunto)
        {
            return _dSqlBuscarDocumentos.GetBuscarAdjunto(sBuscarAdjunto);
        }
    }

}
