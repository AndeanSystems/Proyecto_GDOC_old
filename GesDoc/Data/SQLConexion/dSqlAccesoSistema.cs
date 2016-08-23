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
    public class dSqlIAccesoSistema : IAccesoSistema
    {
        private dbConexion _db = new dbConexion();

        public dSqlIAccesoSistema()
        {
            _db = new dbConexion();
        }

        public Int64 SetAccesoSistema(eAccesoSistema sAcceso)
        {
            Int64 _TmpInt64 = 0;

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSPInsertarAcceso;

                sqlcmd.Parameters.Add("@CodiAcce", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@CodiUsuCrea", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@FechModi", SqlDbType.DateTime);
                sqlcmd.Parameters.Add("@EstAcc", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@CodiUsu", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@CodiPag", SqlDbType.BigInt);

                sqlcmd.Parameters["@CodiAcce"].Value = sAcceso.Codigo.ToInt64();
                sqlcmd.Parameters["@CodiUsuCrea"].Value = sAcceso.UsuarioCreacion.Codigo.ToInt64();
                sqlcmd.Parameters["@FechModi"].Value = sAcceso.FechaModificacion.ToDateTime();
                sqlcmd.Parameters["@EstAcc"].Value = sAcceso.Estado.ToText();
                sqlcmd.Parameters["@CodiUsu"].Value = sAcceso.Usuario.Codigo.ToInt64();
                sqlcmd.Parameters["@CodiPag"].Value = sAcceso.Pagina.Codigo.ToInt64();

                _TmpInt64 = (int)sqlcmd.ExecuteNonQuery();
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

            return _TmpInt64;
        }

        public Int64 SetAnulaAcceso(eAccesoSistema sAcceso)
        {   
            Int64 _TmpInt64 = 0;

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSPAnulaAccesoSistema;

                sqlcmd.Parameters.Add("@CodiUsu", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@CodiPag", SqlDbType.BigInt);

                sqlcmd.Parameters["@CodiUsu"].Value = sAcceso.Usuario.Codigo.ToInt64();
                sqlcmd.Parameters["@CodiPag"].Value = sAcceso.Pagina.Codigo.ToInt64();

                _TmpInt64 = (int)sqlcmd.ExecuteNonQuery();
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

            return _TmpInt64;
        }


        public IList<eAccesoSistema> GetAccesoSistema(eAccesoSistema sAcceso)
        {
            IList<eAccesoSistema> _lstTmp = new List<eAccesoSistema>();

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSPConsAccesoSistema;

                sqlcmd.Parameters.Add("@CodiUsu", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@CodiPag", SqlDbType.BigInt);

                sqlcmd.Parameters["@CodiUsu"].Value = sAcceso.Usuario.Codigo.ToInt64();
                sqlcmd.Parameters["@CodiPag"].Value = sAcceso.Pagina.Codigo.ToInt64();

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

            sAcceso.Codigo = idr["CodiAcce"].ToInt64();
            sAcceso.UsuarioCreacion = new eUsuario { Codigo = idr["CodiUsuCrea"].ToInt64() };
            sAcceso.FechaModificacion = idr["FechModi"].ToDateTime();
            sAcceso.Estado = idr["EstAcc"].ToText();
            sAcceso.Usuario = new eUsuario { Codigo = idr["CodiUsu"].ToInt64() };
            sAcceso.Pagina = new eModuloPagina { Codigo = idr["CodiPag"].ToInt64() };

            return sAcceso;
        }
        
    }
}
