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
    public class bLUserPart: ILUserPart
    {
        private dbConexion _db = new dbConexion();

        private ILUserPart _dSqlLUserPart = new dSqlLUserPart();
        
        public IList<eParticipante> GetUserPart(eParticipante sParticipante)
        {
            return _dSqlLUserPart.GetUserPart(sParticipante);
        }

        public IList<eParticipante> GetUserPartBatch(List<long> listCodiOper, List<long> listCodiUsu)
        {
            return _dSqlLUserPart.GetUserPartBatch(listCodiOper, listCodiUsu);
        }
    }
}
