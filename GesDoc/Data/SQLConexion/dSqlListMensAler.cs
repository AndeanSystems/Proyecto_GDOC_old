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
    public class dSqlListMensAler: IListMensAler
    {
        private dbConexion _db = new dbConexion();

        public dSqlListMensAler()
        {
            _db = new dbConexion();
        }


        public IList<eMensajeAlerta> GetListMensajAlert(eMensajeAlerta sMensajeAlerta)
        {
            IList<eMensajeAlerta> _lstTmp = new List<eMensajeAlerta>();

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSPConsultarTipoMensaje;

                sqlcmd.Parameters.Add("@sEstMensajeAlerta", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@iCodiOper", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@iCodiUsu", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@dFechMensAler", SqlDbType.DateTime);
                sqlcmd.Parameters.Add("@dFechMensAler2", SqlDbType.DateTime);

                sqlcmd.Parameters["@sEstMensajeAlerta"].Value = sMensajeAlerta.EstMensAler.ToText();
                sqlcmd.Parameters["@iCodiOper"].Value = sMensajeAlerta.CodiOper.ToInt64();
                sqlcmd.Parameters["@iCodiUsu"].Value = sMensajeAlerta.CodiUsu.ToInt64();
                sqlcmd.Parameters["@dFechMensAler"].Value = sMensajeAlerta.FechAler.ToDateTime();
                sqlcmd.Parameters["@dFechMensAler2"].Value = sMensajeAlerta.FechAler.ToDateTime();


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

        private IList<eMensajeAlerta> MakeUniqueDatos(IDataReader idr)
        {
            IList<eMensajeAlerta> list = new List<eMensajeAlerta>();

            while (idr.Read())
                list.Add(MakeDatosMapeados(idr));

            return list;
        }

        private eMensajeAlerta MakeDatosMapeados(IDataReader idr)
        {
            eMensajeAlerta sMensajeAlerta = new eMensajeAlerta();

            sMensajeAlerta.CodiMensAler = idr["CodiMensAler"].ToInt64();
            sMensajeAlerta.FechAler = idr["FechAler"].ToDateTime();
            sMensajeAlerta.DescEven = idr["DescEven"].ToText();
            sMensajeAlerta.CodiOper = idr["CodiOper"].ToInt64();
            sMensajeAlerta.TipoOper = idr["TipoOper"].ToText();


            return sMensajeAlerta;
        }
    }
}
