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
    public class bConsComenMV: IConsComenMV
    {

        private IConsComenMV _dSqlConsComenMV = new dSqlConsComenMV();

        public IList<eMesaVirtual> GetComenMesa(eMesaVirtual sMesaVirtual)
        {
            return _dSqlConsComenMV.GetComenMesa(sMesaVirtual);
        }
    }
}
