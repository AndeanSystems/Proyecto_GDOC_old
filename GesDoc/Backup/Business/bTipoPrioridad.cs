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
    public class bTipoPrioridad: ITipoPrioridad
    {

        private ITipoPrioridad _dSqlTipoPrioridad = new dSqlTipoPrioridad();
        
        public IList<eTipoPrioridad> GetListaTipoPrioridad(eTipoPrioridad sTipoPrioridad)
        {
            return _dSqlTipoPrioridad.GetListaTipoPrioridad(sTipoPrioridad);
        }
    }
}
