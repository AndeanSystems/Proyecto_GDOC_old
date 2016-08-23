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
    public class bUsuarioParticipante : IUsuarioParticipante
    {
        private IUsuarioParticipante _dSqlUsuarioParticipante = new dSqlUsuarioParticipante();

        public Int64 SetUsuParticipante(eParticipante sParticipante)
        {
            return _dSqlUsuarioParticipante.SetUsuParticipante(sParticipante);
        }

        public Int64 UpdateUsuParticipante(eParticipante sParticipante)
        {
            return _dSqlUsuarioParticipante.UpdateUsuParticipante(sParticipante);
        }

        public Int64 SetAnulaUserPart(eParticipante sParticipante)
        {
            return _dSqlUsuarioParticipante.SetAnulaUserPart(sParticipante);
        }
    }
}
