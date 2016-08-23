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
    public class bTipoMesaVirtual: ITipoMesaVirtual
    {
        private ITipoMesaVirtual _dSqlTipoMesaVirtual = new dSqlTipoMesaVirtual();
        
        
        public IList<eMesaVirtual> GetTipoMV(eMesaVirtual sMesaVirtual)
        {
            return _dSqlTipoMesaVirtual.GetTipoMV(sMesaVirtual);
        }
    }
}
