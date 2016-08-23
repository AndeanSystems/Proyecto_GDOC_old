using System;
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
    public class dSqlLogOperacion: ILogOperacion
    {
        private dbConexion _db = new dbConexion();

        public dSqlLogOperacion()
        {
            _db = new dbConexion();
        }


        public Int64 SetLogOperacion(eLogOperacion sLogOperacion)
        {
            Int64 _TmpInt64 = 0;

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSPInsertarLogOper;

                sqlcmd.Parameters.Add("@iCodiLogOper", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@dFechEven", SqlDbType.DateTime);
                sqlcmd.Parameters.Add("@cTipoOper", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@cCodiOper", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@cCodiEven", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@iCodiUsu", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@iCodiCnx", SqlDbType.BigInt);

                sqlcmd.Parameters["@iCodiLogOper"].Value = sLogOperacion.CodiLogOper.ToInt64();
                sqlcmd.Parameters["@dFechEven"].Value = sLogOperacion.FechEven.ToDateTime();
                sqlcmd.Parameters["@cTipoOper"].Value = sLogOperacion.TipoOper.ToText();
                sqlcmd.Parameters["@cCodiOper"].Value = sLogOperacion.CodiOper.ToText();
                sqlcmd.Parameters["@cCodiEven"].Value = sLogOperacion.CodiEven.ToText();
                sqlcmd.Parameters["@iCodiUsu"].Value = sLogOperacion.CodiUsu.ToInt64();
                sqlcmd.Parameters["@iCodiCnx"].Value = sLogOperacion.CodiCnx.ToInt64();

                _TmpInt64 = (int)sqlcmd.ExecuteNonQuery();
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

            return _TmpInt64;
        }
    }
}
