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
    public class bDocDigRef: IDocDigRef
    {
        private IDocDigRef _dSqlDocDigRef = new dSqlDocDigRef();

        public Int64 SetRefDigital(eDocDigRef sDogDigRef)
        {
            return _dSqlDocDigRef.SetRefDigital(sDogDigRef);
        }
    }
}
