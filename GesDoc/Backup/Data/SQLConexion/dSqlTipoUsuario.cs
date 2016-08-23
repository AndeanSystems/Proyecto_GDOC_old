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
    public class dSqlTipoUsuario: ITipoUsuario
    {
        private dbConexion _db = new dbConexion();

        public dSqlTipoUsuario()
        {
            _db = new dbConexion();
        }
        
        public IList<eTipoUsuario> GetTipoUsuario(eTipoUsuario sTipoUsuario)
        {
            IList<eTipoUsuario> _lstTmp = new List<eTipoUsuario>();

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSPConsultarTipoUsuario;

                sqlcmd.Parameters.Add("@sEstTipoUsuario", SqlDbType.VarChar);

                sqlcmd.Parameters["@sEstTipoUsuario"].Value = sTipoUsuario.EstaTipUsu.ToText();

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

        private IList<eTipoUsuario> MakeUniqueDatos(IDataReader idr)
        {
            IList<eTipoUsuario> list = new List<eTipoUsuario>();

            while (idr.Read())
                list.Add(MakeDatosMapeados(idr));

            return list;
        }

        private eTipoUsuario MakeDatosMapeados(IDataReader idr)
        {
            eTipoUsuario sTipoUsuario = new eTipoUsuario();

            sTipoUsuario.CodiTipUsu = idr["CodiTipUsu"].ToInt64();
            sTipoUsuario.DescTipUsu = idr["DescTipUsu"].ToText();
            sTipoUsuario.AbreTipUsu = idr["AbreTipUsu"].ToText();
            sTipoUsuario.EstaTipUsu = idr["EstaTipUsu"].ToText();

            return sTipoUsuario;
        }

    }
}
