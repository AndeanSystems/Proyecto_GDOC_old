using Entity;
using Entity.Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Entity.Interfaces
{
    public interface IGrupoUsuarios
    {
        Int64 GrupoUserAdd(eUsuarioGrupo _eUsuarioGrupo);

        Int64 AnulaGrupoUser(eUsuarioGrupo _eUsuarioGrupo);
    }
}
