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
    public class bTipoAcceso: ITipoAcceso
    {
        private ITipoAcceso _dSqlTipoAcceso = new dSqlTipoAcceso();
                
        public IList<eTipoAcceso> GetListaTipoAcceso(eTipoAcceso sTipoAcceso)
        {
            return _dSqlTipoAcceso.GetListaTipoAcceso(sTipoAcceso);
        }

    }
}
