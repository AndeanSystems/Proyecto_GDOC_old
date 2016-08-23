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
    public class bOperacion: IOperaciones
    {
        private IOperaciones _dSqlOperacion = new dSqlOperacion();

        public IList<eOperaciones> GetOperaciones(eOperaciones sOperaciones)
        {
            return _dSqlOperacion.GetOperaciones(sOperaciones);
        }
    }
}
