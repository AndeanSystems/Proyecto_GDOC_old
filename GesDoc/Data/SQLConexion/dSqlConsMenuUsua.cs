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
    public class dSqlConsMenuUsua: IConsMenuUsua
    {
        private dbConexion _db = new dbConexion();

        public dSqlConsMenuUsua()
        {
            _db = new dbConexion();
        }
    
        public IList<eAccesoSistema> GetMenuUsuario(eAccesoSistema sAcceso)
        {
            IList<eAccesoSistema> _lstTmp = new List<eAccesoSistema>();

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSPConsMenuUser;

                sqlcmd.Parameters.Add("@CodiUsu", SqlDbType.BigInt);

                sqlcmd.Parameters["@CodiUsu"].Value = sAcceso.Usuario.Codigo;

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

        private IList<eAccesoSistema> MakeUniqueDatos(IDataReader idr)
        {
            IList<eAccesoSistema> list = new List<eAccesoSistema>();

            while (idr.Read())
                list.Add(MakeDatosMapeados(idr));

            return list;
        }

        private eAccesoSistema MakeDatosMapeados(IDataReader idr)
        {
           eAccesoSistema sAcceso = new eAccesoSistema();

            sAcceso.Pagina = new eModuloPagina 
            {
                Nombre = idr["NombPag"].ToText(),
                DireccionURL = idr["DireFisiPag"].ToText(),
                Codigo = idr["CodiPag"].ToInt64(),
                Comentario = idr["NomPad"].ToText(),
                CodigoPadre = idr["CodiPagPadr"].ToInt64() 
            };
            sAcceso.Estado = idr["EstAcc"].ToText();
            sAcceso.Usuario = new eUsuario { Codigo = idr["CodiUsu"].ToInt64() };

            return sAcceso;
        }
    }
}
