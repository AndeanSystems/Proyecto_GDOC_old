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
    public class bTipoArea: ITipoArea
    {
        private ITipoArea _dSqlTipoArea = new dSqlTipoArea();
        
        public IList<eArea> GetTipoArea(eArea sArea)
        {
            return _dSqlTipoArea.GetTipoArea(sArea);
        }       
    }
}
