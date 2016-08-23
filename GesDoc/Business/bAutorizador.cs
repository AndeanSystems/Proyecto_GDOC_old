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
    public class bAutorizador: IAutorizador
    {
        private IAutorizador _dSqlAutorizador = new dSqlAutorizador();
        
        public Int64 SetAutorizadorAdd(eAutorizador sAutorizador)
        {
            return _dSqlAutorizador.SetAutorizadorAdd(sAutorizador);
        }
    }
}
