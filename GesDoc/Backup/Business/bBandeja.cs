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
    public class bBandeja: IBandeja
    {
        private IBandeja _dSqlBandeja = new dSqlBandeja();

        public IList<eOperaciones> GetBandejaDoc(eOperaciones _eOperaciones)
        {
           return  _dSqlBandeja.GetBandejaDoc(_eOperaciones);
        }
    }

}
