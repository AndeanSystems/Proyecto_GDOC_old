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
    public class bConsAutorizador: IConsAutorizador
    {
        private IConsAutorizador _dSqlConsAutorizador = new dSqlConsAutorizador();

        public IList<eAutorizador> GetUserAutoriza(eAutorizador sAutorizador)
        {
            return _dSqlConsAutorizador.GetUserAutoriza(sAutorizador);
        }
    }
}
