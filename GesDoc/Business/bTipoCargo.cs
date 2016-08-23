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
    public class bTipoCargo: ITipoCargo
    {
        private ITipoCargo _dSqlTipoCargo = new dSqlTipoCargo();
        
        
        public IList<eTipoCargo> GetTipoCargo(eTipoCargo sTipoCargo)
        {
            return _dSqlTipoCargo.GetTipoCargo(sTipoCargo);  
        }
    }
}
