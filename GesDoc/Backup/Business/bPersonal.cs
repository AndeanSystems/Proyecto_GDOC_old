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
    public class bPersonal: IPersonal
    {
        private IPersonal _dSqlPersonal = new dSqlPersonal();
       
        public Int64 SetAddPersonal(ePersonal sPersonal) 
        {
           return _dSqlPersonal.SetAddPersonal(sPersonal);
        }
    }
}
