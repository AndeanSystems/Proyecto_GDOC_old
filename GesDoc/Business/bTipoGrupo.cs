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
    public class bTipoGrupo: ITipoGrupo
    {
        private ITipoGrupo _dSqlTipoGrupo = new dSqlTipoGrupo();
        
        public IList<eGrupo> GetTipoGrupo(eGrupo sGrupo)
        {
            return _dSqlTipoGrupo.GetTipoGrupo(sGrupo);
        }
    }
}
