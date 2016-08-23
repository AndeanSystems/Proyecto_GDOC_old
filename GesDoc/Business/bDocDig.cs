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
    public class bDocDig: IDocDig
    {
        private IDocDig _dSqlDocDig = new dSqlDocDig();

        public Int64 SetDocDigAdd(eDocDig sDocDig)
        {
            return _dSqlDocDig.SetDocDigAdd(sDocDig);
        }
    }
}
