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
    public class bBandejaMV: IBandejaMV
    {
        private IBandejaMV _dSqlBandejaMV = new dSqlBandejaMV();       

        public IList<eMesaVirtual> GetBandejaMV(eMesaVirtual sMesaVirtual)
        {
            return _dSqlBandejaMV.GetBandejaMV(sMesaVirtual);
        }
    }
}
