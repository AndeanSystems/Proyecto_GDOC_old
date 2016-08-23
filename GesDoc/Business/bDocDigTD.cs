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
    public class bDocDigTD: IDocDigListTD
    {
        private IDocDigListTD _dSqlDocDigTD = new dSqlDocDigTD();

        public IList<eDocDigListTD> GetListaTipoDoc(eDocDigListTD sTipoDoc)
        {
            return _dSqlDocDigTD.GetListaTipoDoc(sTipoDoc);
        }

    }
}
