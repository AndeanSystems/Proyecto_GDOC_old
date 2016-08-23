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
    public class bTipoParticip: ITipoParticip
    {

        private ITipoParticip _dSqlTipoParticip = new dSqlTipoParticip();

        public IList<eTipoParticipacion> GetListaTipoParticip(eTipoParticipacion sTipoParticipacion)
        {
            return _dSqlTipoParticip.GetListaTipoParticip(sTipoParticipacion);
        }
    }
}
