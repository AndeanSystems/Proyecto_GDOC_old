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
    public class bMesaVirtual: IMesaVirtual
    {
        private IMesaVirtual _dSqlMesaVirtual = new dSqlMesaVirtual();
     
        public IList<eMesaVirtual> GetMesaVirtual(eMesaVirtual sMesaVirtual)
        {
            return _dSqlMesaVirtual.GetMesaVirtual(sMesaVirtual);
        }
    }
}
