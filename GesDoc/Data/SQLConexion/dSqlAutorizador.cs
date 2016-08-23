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
    public class dSqlAutorizador: IAutorizador
    {
        private dbConexion _db = new dbConexion();

        public dSqlAutorizador()
        {
            _db = new dbConexion();
        }

        public Int64 SetAutorizadorAdd(eAutorizador sAutorizador)
        {
            Int64 _TmpInt64 = 0;

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSPInsertarAutoriza;

                sqlcmd.Parameters.Add("@Type", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@iCodiUsuPart", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@iCodiOper", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@cTipoOper", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@cRespUsuAuto", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@dFechUsuAuto", SqlDbType.DateTime);
                sqlcmd.Parameters.Add("@cComeUsuAuto", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@cEstaAuto", SqlDbType.VarChar);


                sqlcmd.Parameters["@Type"].Value = sAutorizador.Type.ToInt64();
                sqlcmd.Parameters["@iCodiUsuPart"].Value = sAutorizador.CodiUsuPart.ToInt64();
                sqlcmd.Parameters["@iCodiOper"].Value = sAutorizador.CodiOper.ToInt64();
                sqlcmd.Parameters["@cTipoOper"].Value = sAutorizador.TipoOper.ToText();
                sqlcmd.Parameters["@cRespUsuAuto"].Value = sAutorizador.RespUsuAuto.ToText();
                sqlcmd.Parameters["@dFechUsuAuto"].Value = sAutorizador.FechUsuAuto.ToDateTime();
                sqlcmd.Parameters["@cComeUsuAuto"].Value = sAutorizador.ComeUsuAuto.ToText();
                sqlcmd.Parameters["@cEstaAuto"].Value = sAutorizador.EstaAuto.ToText();


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
