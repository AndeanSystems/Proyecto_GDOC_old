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
    public class dSqlUsuarioGrupo: IUsuarioGrupo
    {
        private dbConexion _db = new dbConexion();

        public dSqlUsuarioGrupo()
        {
            _db = new dbConexion();
        }
 
        public IList<eUsuarioGrupo> GetUsuarioGrupo(eUsuarioGrupo sUsuarioGrupo)
        {
            IList<eUsuarioGrupo> _lstTmp = new List<eUsuarioGrupo>();

            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = _db.miconexion;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _db.sSPConsUsurGruop;

                sqlcmd.Parameters.Add("@sCodiGrupo", SqlDbType.BigInt);
                sqlcmd.Parameters.Add("@sIdeGrupo", SqlDbType.VarChar);


                sqlcmd.Parameters["@sCodiGrupo"].Value = sUsuarioGrupo.Grupo.CodiGrup.ToInt64();
                sqlcmd.Parameters["@sIdeGrupo"].Value = sUsuarioGrupo.Grupo.NombGrup.ToText();
                
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

        private IList<eUsuarioGrupo> MakeUniqueDatos(IDataReader idr)
        {
            IList<eUsuarioGrupo> list = new List<eUsuarioGrupo>();

            while (idr.Read())
                list.Add(MakeDatosMapeados(idr));

            return list;
        }           

        private eUsuarioGrupo MakeDatosMapeados(IDataReader idr)
        {
            eUsuarioGrupo sUsuarioGrupo = new eUsuarioGrupo();

            sUsuarioGrupo.UsuCrea = idr["UsuCrea"].ToText();
            sUsuarioGrupo.FechCrea = idr["FechCrea"].ToDateTime();

            sUsuarioGrupo.Grupo = new eGrupo
            {
                CodiGrup = idr["CodiGrup"].ToInt64(),
                NombGrup = idr["NombGrup"].ToText(),
                FechCrea = idr["FechCrea"].ToDateTime(),
                UsuCrea = idr["UsuCrea"].ToText(),
                ComeGrup = idr["ComeGrup"].ToText(),
                EstGrup = idr["EstGrup"].ToText()                
            };

            sUsuarioGrupo.Usuario = new eUsuario
            {
                Codigo = idr["CodiUsu"].ToInt64(),
                IdeUsuario = idr["IdeUsu"].ToText(),
                Pasword = idr["PassUsu"].ToText(),
                FirmaElectronica = idr["FirmElec"].ToText(),
                Estado = idr["EstaUsu"].ToText(),
                FechaRegistro = idr["FechReg"].ToDateTime(),
                FechaUltimoAcceso = idr["FechUltiAcc"].ToDateTime(),
                FechaModificacion = idr["FechModi"].ToDateTime(),
                IntentoErradoPasword = idr["InteErraPass"].ToInt16(),
                IntentoErradoFirma = idr["InteErraFirm"].ToInt16(),
                CodigoPersona = idr["CodiPers"].ToInt64(),
            };

            return sUsuarioGrupo;
        }
    }
}