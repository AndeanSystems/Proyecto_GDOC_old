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
    public class bConsMenuUsua: IConsMenuUsua
    {

        private IConsMenuUsua _dSqlConsMenuUsua = new dSqlConsMenuUsua();
    
        public IList<eAccesoSistema> GetMenuUsuario(eAccesoSistema sAcceso)
        {
            return _dSqlConsMenuUsua.GetMenuUsuario(sAcceso);
        }
    }
}
