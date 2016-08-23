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
    public class bInserMesaVirtual : IInserMesaVirtual
    {        
        private IInserMesaVirtual _dSqlInserMesaVirtual = new dSqlInserMesaVirtual();

        public Int64 SetMesaVirtual(eMesaVirtual sMesaVirtual)
        {
            return _dSqlInserMesaVirtual.SetMesaVirtual(sMesaVirtual);
        }
    }
}
