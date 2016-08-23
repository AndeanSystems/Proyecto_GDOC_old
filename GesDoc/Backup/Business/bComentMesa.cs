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
    public class bComentMesa: IComentMesa
    {
        private IComentMesa _dSqlComentMesa = new dSqlComentMesa();

        public Int64 SetComentMesa(eMesaVirtual sMesaVirtual)
        {
            return _dSqlComentMesa.SetComentMesa(sMesaVirtual);
        }
    }
}
