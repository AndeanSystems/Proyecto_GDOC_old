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
    public class bAccesoSistema : IAccesoSistema
    {
        private IAccesoSistema _dSqlIAccesoSistema = new dSqlIAccesoSistema();

        public Int64 SetAccesoSistema(eAccesoSistema sAcceso)
        {
            return _dSqlIAccesoSistema.SetAccesoSistema(sAcceso);
        }

        public Int64 SetAnulaAcceso(eAccesoSistema sAcceso)
        {
            return _dSqlIAccesoSistema.SetAnulaAcceso(sAcceso);
        }


        public IList<eAccesoSistema> GetAccesoSistema(eAccesoSistema sAcceso)
        {
            return _dSqlIAccesoSistema.GetAccesoSistema(sAcceso);
        }        
    }
}
