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
    public class bUsuarioPer : IUsuarioPer
    {
        private IUsuarioPer _dSqlUsuarioPer = new dSqlUsuarioPer();

        public Int64 SetAddUsuario(eUsuario sUsuario)
        {
            return _dSqlUsuarioPer.SetAddUsuario(sUsuario);
        }

        //Esta funcion permite eliminar,registrar ultima fecha de acceso y cambio de password y firmaelectronica
        public Int64 SetUsuarioEstado(eUsuario sUsuario)
        {
            return _dSqlUsuarioPer.SetUsuarioEstado(sUsuario);
        }


        public IList<eUsuario> GetListaUsuarioPer(eUsuario sUsuario)
        {
            return _dSqlUsuarioPer.GetListaUsuarioPer(sUsuario);
        }

        public IList<eUsuario> GetListaUsuarioGrupo(eUsuario sUsuario)
        {
            return _dSqlUsuarioPer.GetListaUsuarioGrupo(sUsuario);
        }

    }
}
