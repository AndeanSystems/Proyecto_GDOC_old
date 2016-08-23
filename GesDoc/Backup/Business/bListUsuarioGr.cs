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
    public class bListUsuarioGr: IListUsuarioGr
    {
        private IListUsuarioGr _dSqlListUsuarioGr = new dSqlListUsuarioGr();
     
        public IList<eGrupo> GetUsuarioGrupo(eGrupo sGrupo)
        {
            return _dSqlListUsuarioGr.GetUsuarioGrupo(sGrupo);   
        }
    }
}
