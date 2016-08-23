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
    public class dSqlTipoCargo: ITipoCargo
    {
        private dbConexion _db = new dbConexion();

        public dSqlTipoCargo()
        {
            _db = new dbConexion();
        }
        
        public IList<eTipoCargo> GetTipoCargo(eTipoCargo sTipoCargo)
        {
            IList<eTipoCargo> _lstTmp = new List<eTipoCargo>();

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSPConsultarTipoCargo;

                sqlcmd.Parameters.Add("@sEstCargo", SqlDbType.VarChar);

                sqlcmd.Parameters["@sEstCargo"].Value = sTipoCargo.EstCargo.ToText();

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

        private IList<eTipoCargo> MakeUniqueDatos(IDataReader idr)
        {
            IList<eTipoCargo> list = new List<eTipoCargo>();

            while (idr.Read())
                list.Add(MakeDatosMapeados(idr));

            return list;
        }

        private eTipoCargo MakeDatosMapeados(IDataReader idr)
        {
            eTipoCargo sTipoCargo = new eTipoCargo();

            sTipoCargo.CodiCarg = idr["CodiCarg"].ToInt64();
            sTipoCargo.DescCarg = idr["DescCarg"].ToText();

            return sTipoCargo;
        }
    }
}
