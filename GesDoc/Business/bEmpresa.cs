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
    public class bEmpresa: IEmpresa
    {

        private IEmpresa _dSqlEmpresa = new dSqlEmpresa();
        
        public Int64 SetEmpresaAdd(eEmpresa sEmpresa)
        {
            return _dSqlEmpresa.SetEmpresaAdd(sEmpresa);
        }

        public IList<eEmpresa> GetEmpresa(eEmpresa sEmpresa)
        {
            return _dSqlEmpresa.GetEmpresa(sEmpresa);   
        }
    }
}
