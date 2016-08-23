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
    public class dSqlConsModuPag: IConsModuPag
    {
        private dbConexion _db = new dbConexion();

        public dSqlConsModuPag()
        {
            _db = new dbConexion();
        }

        public IList<eModuloPagina> GetModuloPagina(eModuloPagina sModulo)
        {
            IList<eModuloPagina> _lstTmp = new List<eModuloPagina>();

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSPConsModuloPagina;

                sqlcmd.Parameters.Add("@EstPag", SqlDbType.VarChar);

                sqlcmd.Parameters["@EstPag"].Value = sModulo.Estado;

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

        private IList<eModuloPagina> MakeUniqueDatos(IDataReader idr)
        {
            IList<eModuloPagina> list = new List<eModuloPagina>();

            while (idr.Read())
                list.Add(MakeDatosMapeados(idr));

            return list;
        }

        private eModuloPagina MakeDatosMapeados(IDataReader idr)
        {
            eModuloPagina sModulo = new eModuloPagina();

            sModulo.Codigo = idr["CodiPag"].ToInt64();
            sModulo.Nombre = idr["NombPag"].ToText();
            sModulo.Comentario = idr["ComePag"].ToText();
            sModulo.DireccionURL = idr["DireFisiPag"].ToText();
            sModulo.Estado = idr["EstPag"].ToText();
            sModulo.CodigoPadre = idr["CodiPagPadr"].ToInt64();
            sModulo.Modulo = idr["ModuSiste"].ToText();

            return sModulo;
        }
    }
}
