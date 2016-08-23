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
    public class bDocumentoElectronico: IDocumentoElectronico  
    {

        private IDocumentoElectronico _dSqlDocumentoElectronico = new dSqlDocumentoElectronico();
       
        public Int64 SetDocumentoElectronicoEnviar(eDocumentoElectronico sDocumentoElectronico)
        {
            return _dSqlDocumentoElectronico.SetDocumentoElectronicoEnviar(sDocumentoElectronico);
        }

    }
}
