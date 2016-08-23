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
    public class bListMensAler: IListMensAler
    {
        private IListMensAler _dSqlListMensAler = new dSqlListMensAler();
        
        public IList<eMensajeAlerta> GetListMensajAlert(eMensajeAlerta sMensajeAlerta)
        {
            return _dSqlListMensAler.GetListMensajAlert(sMensajeAlerta);
        }


    }
}
