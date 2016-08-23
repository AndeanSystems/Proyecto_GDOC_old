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
    public class bGrupo: IGrupo
    {

        private IGrupo _dSqlGrupo = new dSqlGrupo();
        
        public Int64 GrupoAdd(eGrupo sGrupo)
        {
            return _dSqlGrupo.GrupoAdd(sGrupo);
        }
    }
}
