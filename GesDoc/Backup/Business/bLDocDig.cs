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
    public class bLDocDig: ILDocDig
    {
        private dbConexion _db = new dbConexion();

        private ILDocDig _dSqlLDocDig = new dSqlLDocDig();
        
        public IList<eDocDig> GetDocDigital(eDocDig sDocDig)
        {
            return _dSqlLDocDig.GetDocDigital(sDocDig);
        }
    }
}
