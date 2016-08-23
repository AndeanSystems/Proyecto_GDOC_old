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
    public class bLDocDigRef :ILDocDigRef
    {
        private dbConexion _db = new dbConexion();

        private ILDocDigRef _dSqlLDocDigRef = new dSqlLDocDigRef();
       
        public IList<eDocDigRef> GetDocDigRef(eDocDigRef sDocDigRef)
        {
            return _dSqlLDocDigRef.GetDocDigRef(sDocDigRef);  
        }
    }
}
