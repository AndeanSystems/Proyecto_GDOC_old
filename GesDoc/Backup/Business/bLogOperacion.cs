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
    public class bLogOperacion: ILogOperacion
    {
        private dbConexion _db = new dbConexion();

        private ILogOperacion _dSqlLogOperacion = new dSqlLogOperacion();
       
        public Int64 SetLogOperacion(eLogOperacion sLogOperacion)
        {
            return _dSqlLogOperacion.SetLogOperacion(sLogOperacion);
        }
    }
}
