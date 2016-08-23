using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Common;
using Entity;
using Entity.Entities;
using Entity.Interfaces;
using System.Diagnostics;

namespace Data.SqlConexion
{
    public class dSqlUsuarioPer : IUsuarioPer
    {
        private dbConexion _db = new dbConexion();

        public dSqlUsuarioPer()
        {
            _db = new dbConexion();
        }

        public Int64 SetAddUsuario(eUsuario sUsuario)
        {
            Int64 _return = 0;

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSPInsertUsuario;

                sqlcmd.Parameters.Add("@CodiUsu", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@IdeUsu", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@PassUsu", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@FirmElec", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@EstaUsu", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@FechReg", SqlDbType.DateTime);
                sqlcmd.Parameters.Add("@FechUltiAcc", SqlDbType.DateTime);
                sqlcmd.Parameters.Add("@FechModi", SqlDbType.DateTime);
                sqlcmd.Parameters.Add("@InteErraPass", SqlDbType.SmallInt);
                sqlcmd.Parameters.Add("@InteErraFirm", SqlDbType.SmallInt);
                sqlcmd.Parameters.Add("@TermUsu", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@UsuCrea", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@CodiCnx", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@CodiPers", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@CodiRol", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@CodiTipUsu", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@ClasUsu", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@ExpiClav", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@ExpiFirm", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@FechExpiClav", SqlDbType.DateTime);
                sqlcmd.Parameters.Add("@FechExpiFirm", SqlDbType.DateTime);


                sqlcmd.Parameters["@CodiUsu"].Value = sUsuario.Codigo;
                sqlcmd.Parameters["@IdeUsu"].Value = sUsuario.IdeUsuario;
                sqlcmd.Parameters["@PassUsu"].Value = sUsuario.Pasword;
                sqlcmd.Parameters["@FirmElec"].Value = sUsuario.FirmaElectronica;
                sqlcmd.Parameters["@EstaUsu"].Value = sUsuario.Estado;
                sqlcmd.Parameters["@FechReg"].Value = sUsuario.FechaRegistro;
                sqlcmd.Parameters["@FechUltiAcc"].Value = sUsuario.FechaUltimoAcceso;
                sqlcmd.Parameters["@FechModi"].Value = sUsuario.FechaModificacion;
                sqlcmd.Parameters["@InteErraPass"].Value = sUsuario.IntentoErradoPasword;
                sqlcmd.Parameters["@InteErraFirm"].Value = sUsuario.IntentoErradoFirma;
                sqlcmd.Parameters["@TermUsu"].Value = sUsuario.TermUsu;
                sqlcmd.Parameters["@UsuCrea"].Value = sUsuario.UsuCrea;
                sqlcmd.Parameters["@CodiCnx"].Value = sUsuario.CodiCnx;
                sqlcmd.Parameters["@CodiPers"].Value = sUsuario.CodigoPersona;
                sqlcmd.Parameters["@CodiRol"].Value = sUsuario.CodiRol;
                sqlcmd.Parameters["@CodiTipUsu"].Value = sUsuario.CodiTipUsu;
                sqlcmd.Parameters["@ClasUsu"].Value = sUsuario.ClasUsu;
                sqlcmd.Parameters["@ExpiClav"].Value = sUsuario.ExpiClav;
                sqlcmd.Parameters["@ExpiFirm"].Value = sUsuario.ExpiFirm;
                sqlcmd.Parameters["@FechExpiClav"].Value = sUsuario.FechExpiFirm;
                sqlcmd.Parameters["@FechExpiFirm"].Value = sUsuario.FechExpiClav;

                _return = (int)sqlcmd.ExecuteScalar();
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

            return _return;
        }

        //Esta funcion permite eliminar,registrar ultima fecha de acceso y cambio de password y firmaelectronica
        public Int64 SetUsuarioEstado(eUsuario sUsuario)
        {
            Int64 _return = 0;

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSPUsuarioPer;

                sqlcmd.Parameters.Add("@Type", SqlDbType.Int);
                sqlcmd.Parameters.Add("@CodiUsu", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@CodiPers", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@PassUsu", SqlDbType.VarChar);
                sqlcmd.Parameters.Add("@FirmElec", SqlDbType.VarChar);

                sqlcmd.Parameters["@Type"].Value = sUsuario.CodiTipUsu;
                sqlcmd.Parameters["@CodiUsu"].Value = sUsuario.Codigo;
                sqlcmd.Parameters["@CodiPers"].Value = sUsuario.CodigoPersona;
                sqlcmd.Parameters["@PassUsu"].Value = sUsuario.Pasword;
                sqlcmd.Parameters["@FirmElec"].Value = sUsuario.FirmaElectronica;

                _return = (int)sqlcmd.ExecuteNonQuery();
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

            return _return;
        }


        public IList<eUsuario> GetListaUsuarioPer(eUsuario sUsuario)
        {
            IList<eUsuario> _lstUsuario = new List<eUsuario>();

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSPConsUsuario;
                IDataReader idr = sqlcmd.ExecuteReader();
                _lstUsuario = MakeUniqueDatos(idr);
                idr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
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

            return _lstUsuario;
        }
        private IList<eUsuario> MakeUniqueDatos(IDataReader idr)
        {
            IList<eUsuario> list = new List<eUsuario>();

            while (idr.Read())
                list.Add(MakeDatosMapeados(idr));

            return list;
        }
        private eUsuario MakeDatosMapeados(IDataReader idr)
        {
            eUsuario sUsuario = new eUsuario();

            sUsuario.Codigo = idr["CodiUsu"].ToInt64();
            sUsuario.IdeUsuario = idr["IdeUsu"].ToText();
            sUsuario.Pasword = idr["PassUsu"].ToText();
            sUsuario.FirmaElectronica = idr["FirmElec"].ToText();
            sUsuario.Estado = idr["EstaUsu"].ToText();
            sUsuario.FechaRegistro = idr["FechReg"].ToDateTime();
            sUsuario.FechaUltimoAcceso = idr["FechUltiAcc"].ToDateTime();
            sUsuario.FechaModificacion = idr["FechModi"].ToDateTime();
            sUsuario.IntentoErradoPasword = idr["InteErraPass"].ToInt16();
            sUsuario.IntentoErradoFirma = idr["InteErraFirm"].ToInt16();
            sUsuario.TermUsu = idr["TermUsu"].ToText();
            sUsuario.UsuCrea = idr["UsuCrea"].ToText();
            sUsuario.CodiCnx = idr["CodiCnx"].ToText();
            sUsuario.CodiRol = idr["CodiRol"].ToText();
            sUsuario.CodiTipUsu = idr["CodiTipUsu"].ToInt64();
            sUsuario.ClasUsu = idr["ClasUsu"].ToText();
            sUsuario.DescArea = idr["DescArea"].ToText();
            sUsuario.DescCarg = idr["DescCarg"].ToText();
            sUsuario.Pers = new ePersonal
            {
                CodigoPersona = idr["CodiPers"].ToInt64(),
                NombPers = idr["NombPers"].ToText(),
                ApePers = idr["ApePers"].ToText(),
                SexoPers = idr["SexoPers"].ToText(),
                EmaiPers = idr["EmaiPers"].ToText(),
                EmaiTrab = idr["EmaiTrab"].ToText(),
                FechNac = idr["FechNac"].ToDateTime(),
                TelePers = idr["TelePers"].ToText(),
                AnexPers = idr["AnexPers"].ToText(),
                CeluPers = idr["CeluPers"].ToText(),
                EstaPers = idr["EstaPers"].ToText(),
                CodiTipUsu = idr["CodiTipUsu"].ToInt64(),
                CodiArea = idr["CodiArea"].ToInt64(),
                CodiCarg = idr["CodiCarg"].ToInt64(),
                RucEmpr = idr["RucEmpr"].ToInt64(),
                DNI = idr["DNI"].ToText(),
                DirePers = idr["DirePers"].ToText()
            };

            return sUsuario;
        }


        public IList<eUsuario> GetListaUsuarioGrupo(eUsuario sUsuario)
        {
            IList<eUsuario> _lstUsuario = new List<eUsuario>();

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSPConsUsuarioGrupo;

                sqlcmd.Parameters.Add("@sIdeUsu", SqlDbType.VarChar);

                sqlcmd.Parameters["@sIdeUsu"].Value = sUsuario.NombPers.ToText();


                IDataReader idr = sqlcmd.ExecuteReader();
                _lstUsuario = MakeUniqueDatosUsuGrup(idr);
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

            return _lstUsuario;
        }
        private IList<eUsuario> MakeUniqueDatosUsuGrup(IDataReader idr)
        {
            IList<eUsuario> list = new List<eUsuario>();

            while (idr.Read())
                list.Add(MakeDatosUsuGrup(idr));

            return list;
        }
        private eUsuario MakeDatosUsuGrup(IDataReader idr)
        {
            eUsuario sUsuario = new eUsuario();

            sUsuario.Codigo = idr["CodiUsu"].ToInt64();
            sUsuario.IdeUsuario = idr["IdeUsu"].ToText();
            sUsuario.CodigoPersona = idr["CodiPers"].ToInt64();
            sUsuario.NombPers = idr["Nombre"].ToText();
            sUsuario.DescCarg = idr["Cargo"].ToText();

            return sUsuario;
        }

    }
}
