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
    public class dSqlTipoMesaVirtual: ITipoMesaVirtual
    {
        private dbConexion _db = new dbConexion();

        public dSqlTipoMesaVirtual()
        {
            _db = new dbConexion();
        }
        
        public IList<eMesaVirtual> GetTipoMV(eMesaVirtual sMesaVirtual)
        {
            IList<eMesaVirtual> _lstTmp = new List<eMesaVirtual>();

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSPConsTipoMV;

                sqlcmd.Parameters.Add("@EstaClasMesa", SqlDbType.VarChar);

                sqlcmd.Parameters["@EstaClasMesa"].Value = sMesaVirtual.Estado;

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

        private IList<eMesaVirtual> MakeUniqueDatos(IDataReader idr)
        {
            IList<eMesaVirtual> list = new List<eMesaVirtual>();

            while (idr.Read())
                list.Add(MakeDatosMapeados(idr));

            return list;
        }


        private eMesaVirtual MakeDatosMapeados(IDataReader idr)
        {
            eMesaVirtual sTipoMesa = new eMesaVirtual();

            sTipoMesa.ClaseMV = idr["ClasMesa"].ToText().ToInt();
            sTipoMesa.DesMesaVir = idr["NombClasMesa"].ToText().ToText();
            sTipoMesa.Estado = idr["EstaClasMesa"].ToText().ToText();

            return sTipoMesa;
        }
    }
}
