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
    public class bBuscarLogOperacion: IBuscarLogOperacion
    {
        private IBuscarLogOperacion _dSqlBuscarLogOperacion = new dSqlBuscarLogOperacion();

        public IList<eBuscarLogOperacion> GetBusLogOper(eBuscarLogOperacion sBLogOper)
        {
            return _dSqlBuscarLogOperacion.GetBusLogOper(sBLogOper);
        }

    }
}
