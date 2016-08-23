using Entity;
using Entity.Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Entity.Interfaces
{
    public interface IUsuarioPer
    {
        Int64 SetAddUsuario(eUsuario _eUsuario);
        Int64 SetUsuarioEstado(eUsuario _eUsuario);

        IList<eUsuario> GetListaUsuarioPer(eUsuario _eUsuario);
        IList<eUsuario> GetListaUsuarioGrupo(eUsuario _eUsuario);
    }
}
