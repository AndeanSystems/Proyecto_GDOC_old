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
    public class bUbigeo: IUbigeo
    {
        private IUbigeo _dSqlUbigeo = new dSqlUbigeo();

        public IList<eUbigeo> GetUbigeo(eUbigeo sUbigeo)
        {
            return _dSqlUbigeo.GetUbigeo(sUbigeo);
        }

    }
}
