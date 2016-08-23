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
    public class bDocAdj: IDocAdj
    {
        private IDocAdj _dSqlDocAdj = new dSqlDocAdj();

        public Int64 SetDocAdj(eDocAdj sDocAdj)
        {
            return _dSqlDocAdj.SetDocAdj(sDocAdj);
        }

        public Int64 SetAnulaDocAdj(eDocAdj sDocAdj)
        {
            return _dSqlDocAdj.SetAnulaDocAdj(sDocAdj);
        }

        public IList<eDocAdj> GetDocAdj(eDocAdj DocAdj)
        {
            return _dSqlDocAdj.GetDocAdj(DocAdj);            
        }
        
    }
}
