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
    public class dSqlTipoParticip: ITipoParticip
    {
        private dbConexion _db = new dbConexion();

        public dSqlTipoParticip()
        {
            _db = new dbConexion();
        }


        public IList<eTipoParticipacion> GetListaTipoParticip(eTipoParticipacion sTipoParticipacion)
        {
            IList<eTipoParticipacion> _lstTmp = new List<eTipoParticipacion>();

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSPConsultarTipoParticipacion;

                sqlcmd.Parameters.Add("@sEstTipoParticipante", SqlDbType.VarChar);

                sqlcmd.Parameters["@sEstTipoParticipante"].Value = sTipoParticipacion.EstTipoParticipacion.ToText();

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

        private IList<eTipoParticipacion> MakeUniqueDatos(IDataReader idr)
        {
            IList<eTipoParticipacion> list = new List<eTipoParticipacion>();

            while (idr.Read())
                list.Add(MakeDatosMapeados(idr));

            return list;
        }

        private eTipoParticipacion MakeDatosMapeados(IDataReader idr)
        {
            eTipoParticipacion sTipoParticipacion = new eTipoParticipacion();

            sTipoParticipacion.CodiTipoPart = idr["CodiTipoPart"].ToInt16();
            sTipoParticipacion.TipoParticip = idr["AbreTipoPart"].ToText();
            sTipoParticipacion.DescParticip = idr["DescTipoPart"].ToText();

            return sTipoParticipacion;
        }
    }
}
