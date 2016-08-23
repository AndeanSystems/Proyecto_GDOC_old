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
    public class bRol: IRol
    {
        private IRol _dSqlRol = new dSqlRol();
        
        public IList<eRol> GetTipoRol(eRol sRol)
        {
            return _dSqlRol.GetTipoRol(sRol);
        }
    }
}
