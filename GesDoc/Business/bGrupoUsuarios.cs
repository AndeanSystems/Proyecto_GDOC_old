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
    public class bGrupoUsuarios: IGrupoUsuarios
    {

        private IGrupoUsuarios _dSqlGrupoUsuarios = new dSqlGrupoUsuarios();

        public Int64 GrupoUserAdd(eUsuarioGrupo sGrupo)
        {
            return _dSqlGrupoUsuarios.GrupoUserAdd(sGrupo);
        }

        public Int64 AnulaGrupoUser(eUsuarioGrupo sGrupo)
        {
            return _dSqlGrupoUsuarios.AnulaGrupoUser(sGrupo);    
        }
    }
}
