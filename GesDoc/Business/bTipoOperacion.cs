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
    public class bTipoOperacion: ITipoOperacion
    {

        private ITipoOperacion _dSqlTipoOperacion = new dSqlTipoOperacion();
                
        public IList<eTipoOperacion> GetTipoOperacion(eTipoOperacion sTipoOperacion)
        {
            return _dSqlTipoOperacion.GetTipoOperacion(sTipoOperacion);
        }
    }
}
