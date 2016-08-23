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
    public class bUsuarioGrupo: IUsuarioGrupo
    {
        private IUsuarioGrupo _dSqlUsuarioGrupo = new dSqlUsuarioGrupo();

        public IList<eUsuarioGrupo> GetUsuarioGrupo(eUsuarioGrupo sUsuarioGrupo)
        {
            return _dSqlUsuarioGrupo.GetUsuarioGrupo(sUsuarioGrupo);
        }

    }
}