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
    public class bTipoUsuario: ITipoUsuario
    {     
        private ITipoUsuario _dSqlTipoUsuario = new dSqlTipoUsuario();      
        
        public IList<eTipoUsuario> GetTipoUsuario(eTipoUsuario sTipoUsuario)
        {
            return _dSqlTipoUsuario.GetTipoUsuario(sTipoUsuario);
        }

    }
}
