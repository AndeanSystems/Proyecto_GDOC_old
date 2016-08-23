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
    public class bConsModuPag: IConsModuPag
    {
        private IConsModuPag _dSqlConsModuPag = new dSqlConsModuPag();

        public IList<eModuloPagina> GetModuloPagina(eModuloPagina sModulo)
        {
            return _dSqlConsModuPag.GetModuloPagina(sModulo);
        }

    }
}
