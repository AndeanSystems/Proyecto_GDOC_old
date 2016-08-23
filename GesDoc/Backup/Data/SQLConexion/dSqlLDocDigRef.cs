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
    public class dSqlLDocDigRef :ILDocDigRef
    {
        private dbConexion _db = new dbConexion();

        public dSqlLDocDigRef()
        {
            _db = new dbConexion();
        }


        public IList<eDocDigRef> GetDocDigRef(eDocDigRef sDocDigRef)
        {
            IList<eDocDigRef> _lstTmp = new List<eDocDigRef>();

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSPConsulDocDigRef;

                sqlcmd.Parameters.Add("@cEstaInde", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@iCodiOper", SqlDbType.BigInt);

                sqlcmd.Parameters["@cEstaInde"].Value = sDocDigRef.EstaInde.ToText();
                sqlcmd.Parameters["@iCodiOper"].Value = sDocDigRef.CodiOper.ToInt64();

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

        private IList<eDocDigRef> MakeUniqueDatos(IDataReader idr)
        {
            IList<eDocDigRef> list = new List<eDocDigRef>();

            while (idr.Read())
                list.Add(MakeDatosMapeados(idr));

            return list;
        }

        private eDocDigRef MakeDatosMapeados(IDataReader idr)
        {
            eDocDigRef sDocDigRef = new eDocDigRef();

            sDocDigRef.CodiInde = idr["CodiInde"].ToInt64();
            sDocDigRef.DescInde = idr["DescInde"].ToText();
            sDocDigRef.EstaInde = idr["EstaInde"].ToText();
            sDocDigRef.CodiOper = idr["CodiOper"].ToInt64();
            sDocDigRef.TipoOper = idr["TipoOper"].ToText();

            return sDocDigRef;
        }
    }
}
