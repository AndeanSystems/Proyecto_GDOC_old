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
    public class bListaDescripcion: IListaDescripcion
    {
        private IListaDescripcion _dSqlListaDescripcion = new dSqlListaDescripcion();
      
        public IList<eVariable> GetListaDescrip(eVariable sVariable)
        {
            return _dSqlListaDescripcion.GetListaDescrip(sVariable);
        }
    }
}

