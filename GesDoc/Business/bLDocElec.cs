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
    public class bLDocElec: ILDocElec
    {

        private ILDocElec _dSqlLDocElec = new dSqlLDocElec();
      

        public IList<eDocumentoElectronico> GetDocElec(eDocumentoElectronico sDocElec)
        {
            return _dSqlLDocElec.GetDocElec(sDocElec);
        }
    }
}
