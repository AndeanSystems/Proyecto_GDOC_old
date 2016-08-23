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
    public class dSqlTipoArea: ITipoArea
    {
        private dbConexion _db = new dbConexion();

        public dSqlTipoArea()
        {
            _db = new dbConexion();
        }
        
        public IList<eArea> GetTipoArea(eArea sArea)
        {
            IList<eArea> _lstTmp = new List<eArea>();

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSPConsultarTipoArea;

                sqlcmd.Parameters.Add("@sEstArea", SqlDbType.VarChar);

                sqlcmd.Parameters["@sEstArea"].Value = sArea.EstaAre.ToText();

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

        private IList<eArea> MakeUniqueDatos(IDataReader idr)
        {
            IList<eArea> list = new List<eArea>();

            while (idr.Read())
                list.Add(MakeDatosMapeados(idr));

            return list;
        }

        private eArea MakeDatosMapeados(IDataReader idr)
        {
            eArea sTipoArea = new eArea();

            sTipoArea.CodiAre = idr["CodiArea"].ToInt64();
            sTipoArea.DescAre = idr["DescArea"].ToText();

            return sTipoArea;
        }
    }
}
