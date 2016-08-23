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
    public class dSqlComentMesa: IComentMesa
    {
        private dbConexion _db = new dbConexion();

        public dSqlComentMesa()
        {
            _db = new dbConexion();
        }

        public Int64 SetComentMesa(eMesaVirtual sMesaVirtual)
        {
            Int64 _TmpInt64 = 0;

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSPInsertarComenMesaVirt;

                SqlParameter outputIdParam1 = new SqlParameter("@OutCodiComeMesaV", SqlDbType.BigInt)
                {
                    Direction = ParameterDirection.Output
                };

                sqlcmd.Parameters.Add(outputIdParam1);
                sqlcmd.Parameters.Add("@Type", SqlDbType.SmallInt);
                sqlcmd.Parameters.Add("@CodiComeMesaV", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@ComeMesaV", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@FechPubl", SqlDbType.DateTime);
                sqlcmd.Parameters.Add("@EstCome", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@CodiMesaV", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@CodiUsu", SqlDbType.BigInt);


                sqlcmd.Parameters["@Type"].Value = sMesaVirtual.Type;
                sqlcmd.Parameters["@CodiComeMesaV"].Value = sMesaVirtual.CodiMesaComent;
                sqlcmd.Parameters["@ComeMesaV"].Value = sMesaVirtual.Asunto;
                sqlcmd.Parameters["@FechPubl"].Value = sMesaVirtual.Fecha;
                sqlcmd.Parameters["@EstCome"].Value = sMesaVirtual.Estado;
                sqlcmd.Parameters["@CodiMesaV"].Value = sMesaVirtual.CodiOper;
                sqlcmd.Parameters["@CodiUsu"].Value = sMesaVirtual.CodiUsu;

                _TmpInt64 = (int)sqlcmd.ExecuteNonQuery();

                sMesaVirtual.CodiMesaComent = outputIdParam1.Value.ToInt64();
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
