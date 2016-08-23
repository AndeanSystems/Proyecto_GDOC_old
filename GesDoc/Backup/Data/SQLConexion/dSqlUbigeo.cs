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
    public class dSqlUbigeo: IUbigeo
    {
        private dbConexion _db = new dbConexion();

        public dSqlUbigeo()
        {
            _db = new dbConexion();
        }
        
        
        public IList<eUbigeo> GetUbigeo(eUbigeo sUbigeo)
        {
            IList<eUbigeo> _lstTmp = new List<eUbigeo>();

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSPConsUbigeo;

                sqlcmd.Parameters.Add("@TipoCod", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@Cod_Dpto", SqlDbType.Int);
                sqlcmd.Parameters.Add("@Cod_Prov", SqlDbType.Int);


                sqlcmd.Parameters["@TipoCod"].Value = sUbigeo.TipoCod.ToText();
                sqlcmd.Parameters["@Cod_Dpto"].Value = sUbigeo.Cod_Dpto.ToInt32();
                sqlcmd.Parameters["@Cod_Prov"].Value = sUbigeo.Cod_Prov.ToInt32();

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

        private IList<eUbigeo> MakeUniqueDatos(IDataReader idr)
        {
            IList<eUbigeo> list = new List<eUbigeo>();

            while (idr.Read())
                list.Add(MakeDatosMapeados(idr));

            return list;
        }

        private eUbigeo MakeDatosMapeados(IDataReader idr)
        {
            eUbigeo sUbigeo = new eUbigeo();

            sUbigeo.CodUbi = idr["CodUbi"].ToInt32();
            sUbigeo.Descripcion = idr["Descripcion"].ToText();
            sUbigeo.TipoCod = idr["TipoCod"].ToText();
            sUbigeo.Cod_Dpto = idr["Cod_Dpto"].ToInt32();
            sUbigeo.Cod_Prov = idr["Cod_Prov"].ToInt32();

            return sUbigeo;
        }
    }
}
