﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
//using System.Data.Common;
//using Microsoft.Practices.EnterpriseLibrary.Data;
using Common;
using Entity;
using Entity.Entities;
using Entity.Interfaces;

namespace Data.SqlConexion
{
    public class dSqlOperacion: IOperaciones
    {
        private dbConexion _db = new dbConexion();

        public dSqlOperacion()
        {
            _db = new dbConexion();
        }

        public IList<eOperaciones> GetOperaciones(eOperaciones sOperaciones)
        {
            IList<eOperaciones> _lstTmp = new List<eOperaciones>();

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSPConsulOper;

                sqlcmd.Parameters.Add("@iType", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@iCodiUsu", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@dFecha", SqlDbType.DateTime);

                sqlcmd.Parameters["@iType"].Value = sOperaciones.Type.ToInt64();
                sqlcmd.Parameters["@iCodiUsu"].Value = sOperaciones.CodUsu.ToInt64();
                sqlcmd.Parameters["@dFecha"].Value = sOperaciones.Fecha.ToDateTime();

                IDataReader idr = sqlcmd.ExecuteReader();
                _lstTmp = MakeUniqueDatos(idr);
                idr.Close();

            }
            catch (Exception ex)
            { }
            finally
            {
                if (_db == null)
                {
                    if (_db.miconexion.State != ConnectionState.Closed)
                    {
                        _db.miconexion.Close();
                        _db.miconexion.Dispose();
                    }
                }
            }

            return _lstTmp;
        }

        private IList<eOperaciones> MakeUniqueDatos(IDataReader idr)
        {
            IList<eOperaciones> list = new List<eOperaciones>();

            while (idr.Read())
                list.Add(MakeDatosMapeados(idr));

            return list;
        }

        private eOperaciones MakeDatosMapeados(IDataReader idr)
        {
            eOperaciones sOper= new eOperaciones();

            sOper.CodiOper = idr["CodiOper"].ToInt64();
            sOper.Asunto = idr["Asunto"].ToText();
            sOper.TipoOper = idr["TipoDocu"].ToText();
            sOper.AcceOper = idr["AcceOper"].ToText();
            sOper.NumOper = idr["NumOper"].ToText();
            sOper.Fecha = idr["Fecha"].ToDateTime();
            sOper.IdeUsu = idr["IdeUsu"].ToText();
            sOper.CodUsu = idr["Autor"].ToInt64();

            return sOper;
        }
    }
}
