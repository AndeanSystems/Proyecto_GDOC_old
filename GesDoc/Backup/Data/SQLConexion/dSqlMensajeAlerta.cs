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
using System.Diagnostics;

namespace Data.SqlConexion
{
    public class dSqlMensajeAlerta : IMensajeAlerta
    {
        private dbConexion _db = new dbConexion();

        public dSqlMensajeAlerta()
        {
            _db = new dbConexion();           
        }


        public Int64 SetMensajeAlerta(eMensajeAlerta sMensajeAlerta)
        {
            Int64 _TmpInt64 = 0;

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSPInsertarMensAlert;

                sqlcmd.Parameters.Add("@Type", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@iCodiMensAler", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@iCodiOper", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@cTipoOper", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@dFechAler", SqlDbType.DateTime);
                sqlcmd.Parameters.Add("@cTipoAler", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@cCodiEven", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@cEstMensAler", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@iCodiUsu", SqlDbType.BigInt);

                sqlcmd.Parameters["@Type"].Value = sMensajeAlerta.Type.ToText();
                sqlcmd.Parameters["@iCodiMensAler"].Value = sMensajeAlerta.CodiMensAler.ToInt64();
                sqlcmd.Parameters["@iCodiOper"].Value = sMensajeAlerta.CodiOper.ToInt64();
                sqlcmd.Parameters["@cTipoOper"].Value = sMensajeAlerta.TipoOper.ToText();
                sqlcmd.Parameters["@dFechAler"].Value = sMensajeAlerta.FechAler.ToDateTime();
                sqlcmd.Parameters["@cTipoAler"].Value = sMensajeAlerta.TipoAler.ToText();
                sqlcmd.Parameters["@cCodiEven"].Value = sMensajeAlerta.CodiEven.ToText();
                sqlcmd.Parameters["@cEstMensAler"].Value = sMensajeAlerta.EstMensAler.ToText();
                sqlcmd.Parameters["@iCodiUsu"].Value = sMensajeAlerta.CodiUsu.ToInt64();

                _TmpInt64 = (int)sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
               
            }
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
