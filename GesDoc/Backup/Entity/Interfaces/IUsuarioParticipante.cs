using Entity;
using Entity.Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Entity.Interfaces
{
    public interface IUsuarioParticipante
    {
        Int64 SetUsuParticipante(eParticipante _eParticipante);
        Int64 UpdateUsuParticipante(eParticipante _eParticipante);
        Int64 SetAnulaUserPart(eParticipante _eParticipante);
    }
}
