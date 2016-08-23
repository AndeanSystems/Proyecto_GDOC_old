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
    public class dSqlDocDigTD: IDocDigListTD
    {
        private dbConexion _db = new dbConexion();

        public dSqlDocDigTD()
        {
            _db = new dbConexion();
        }

        public IList<eDocDigListTD> GetListaTipoDoc(eDocDigListTD sTipoDoc)
        {
            IList<eDocDigListTD> _lstTmp = new List<eDocDigListTD>();

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSPConsTipoDocumento;

                sqlcmd.Parameters.Add("@sEstTipoDocumento", SqlDbType.VarChar);

                sqlcmd.Parameters["@sEstTipoDocumento"].Value = sTipoDoc.EstTipoDocumento.ToText();

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
        private IList<eDocDigListTD> MakeUniqueDatos(IDataReader idr)
        {
            IList<eDocDigListTD> list = new List<eDocDigListTD>();

            while (idr.Read())
                list.Add(MakeDatosMapeados(idr));

            return list;
        }
        private eDocDigListTD MakeDatosMapeados(IDataReader idr)
        {
            eDocDigListTD sDocDigListTD = new eDocDigListTD();

            sDocDigListTD.CodiTipoDocu = idr["CodiTipoDocu"].ToText();
            sDocDigListTD.NombTipoDocu = idr["NombTipoDocu"].ToText();

            return sDocDigListTD;
        }

    }
}
