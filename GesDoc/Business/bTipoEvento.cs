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
    public class bTipoEvento: ITipoEvento
    {
        private ITipoEvento _dSqlTipoEvento = new dSqlTipoEvento();
        
        
        public IList<eTipoEvento> GetTipoEvento(eTipoEvento sTipoEvento)
        {
            return _dSqlTipoEvento.GetTipoEvento(sTipoEvento);
        }
    }
}
