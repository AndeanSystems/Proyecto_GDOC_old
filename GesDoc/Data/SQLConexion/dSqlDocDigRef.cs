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
    public class dSqlDocDigRef: IDocDigRef
    {
        private dbConexion _db = new dbConexion();

        public dSqlDocDigRef()
        {
            _db = new dbConexion();
        }

        public Int64 SetRefDigital(eDocDigRef sDogDigRef)
        {
            Int64 _TmpInt64 = 0;

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSPInsertRef;

                sqlcmd.Parameters.Add("@Type", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@iCodiInde", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@cDescInde", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@cEstaInde", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@iCodiOper", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@cTipoOper", SqlDbType.VarChar);


                sqlcmd.Parameters["@Type"].Value = sDogDigRef.Type.ToText();
                sqlcmd.Parameters["@iCodiInde"].Value = sDogDigRef.CodiInde.ToInt64();
                sqlcmd.Parameters["@cDescInde"].Value = sDogDigRef.DescInde.ToText();
                sqlcmd.Parameters["@cEstaInde"].Value = sDogDigRef.EstaInde.ToText();
                sqlcmd.Parameters["@iCodiOper"].Value = sDogDigRef.CodiOper.ToInt64();
                sqlcmd.Parameters["@cTipoOper"].Value = sDogDigRef.TipoOper.ToText();

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
