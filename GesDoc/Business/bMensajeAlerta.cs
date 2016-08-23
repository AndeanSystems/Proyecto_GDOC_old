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
    public class bMensajeAlerta: IMensajeAlerta
    {
        private IMensajeAlerta _dSqlMensajeAlerta = new dSqlMensajeAlerta();
        
        public Int64 SetMensajeAlerta(eMensajeAlerta sMensajeAlerta)
        {
            return _dSqlMensajeAlerta.SetMensajeAlerta(sMensajeAlerta);
        }
    }
}
