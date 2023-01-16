using System;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace Zer0ne.Data
{
    public enum ConnectionType
    {
        sqlServer,
        access,
        mySql
    }

    public class DatabaseController
    {
        private DbParameterCollection dbParameter;
        private ConnectionType connType;
        public ConnectionType DbType
        {
            get
            {
                return connType;
            }
            set
            {
                connType = value;
            }
        }

        private string connString; // = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=mainDB.accdb;";
        public string ConnectionString
        {
            get{return connString;}
            set{ connString = value;}
        }

        public bool Statue
        {
            get
            {
                switch (connType)
                {
                    case ConnectionType.sqlServer:

                        var cn = new SqlConnection(connString);
                        try
                        {
                            cn.Close();
                            cn.Open();
                            cn.Close();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message, ex.InnerException);
                        }
                    case ConnectionType.access:

                        var cnole = new OleDbConnection(connString);
                        try
                        {
                            cnole.Close();
                            cnole.Open();
                            cnole.Close();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message, ex.InnerException);
                        }
                    case ConnectionType.mySql:

                        return false;
                    default:
                        return false;
                }
            }
        }

        public DatabaseController(ConnectionType conType, string cnnString)
        {
            connString = cnnString; 
            connType = conType;
        }

        public void AddParametersValue(string ParameterName, object value, SqlDbType dataType = SqlDbType.NVarChar)
        {
            switch (DbType)
            {
                case ConnectionType.sqlServer:
                    if (dbParameter == null)
                    {
                        SqlCommand cmd = new SqlCommand();
                        dbParameter = cmd.Parameters;
                    }
                    dbParameter.Add(new SqlParameter(ParameterName, dataType));
                    break;
                case ConnectionType.access:
                    if (dbParameter == null)
                    {
                        OleDbCommand cmd = new OleDbCommand();
                        dbParameter = cmd.Parameters;
                    }
                    dbParameter.Add(new SqlParameter(ParameterName, dataType));
                    break;
                case ConnectionType.mySql:
                    break;
                default:
                    break;
            }
            dbParameter[dbParameter.Count - 1].Value = value;
        }

        public DataTable Read(string qry, bool IsProcedure = false)
        {
            DataTable tbl = new DataTable();
            switch (connType)
            {
                case ConnectionType.sqlServer:

                    using (SqlConnection conn = new SqlConnection(ConnectionString))
                    using (SqlCommand com = new SqlCommand(qry, conn))
                    {
                        try
                        {
                            if (IsProcedure)
                            {
                                com.CommandType = CommandType.StoredProcedure;
                            }
                            if (dbParameter != null && dbParameter.Count > 0)
                            {
                                com.CommandType = CommandType.StoredProcedure;
                                foreach (SqlParameter prm in dbParameter)
                                {
                                    com.Parameters.AddWithValue(prm.ParameterName, prm.Value);
                                }
                                dbParameter.Clear();
                            }
                            if (conn.State != ConnectionState.Open)
                            {
                                conn.Open();
                            }
                            tbl.Load(com.ExecuteReader());
                            conn.Close();
                        }
                        catch (Exception ex)
                        {
                            throw new NotImplementedException(ex.Message, ex.InnerException);
                        }
                    }
                    return tbl;

                case ConnectionType.access:

                    using (OleDbConnection conn = new OleDbConnection(ConnectionString))
                    using (OleDbCommand com = new OleDbCommand(qry, conn))
                    {
                        try
                        {
                            if (conn.State != ConnectionState.Open)
                            {
                                conn.Open();
                            }
                            tbl.Load(com.ExecuteReader());
                            conn.Close();
                        }
                        catch (Exception ex)
                        {
                            throw new NotImplementedException(ex.Message, ex.InnerException);
                        }
                    }
                    return tbl;

                case ConnectionType.mySql:
                    return null;
                default:
                    return null;
            }
        }
        
        public bool Execute(string query, bool IsProcedure = false)
        {
            switch (connType)
            {
                case ConnectionType.sqlServer:

                    using (SqlConnection conn = new SqlConnection(ConnectionString))
                    using (SqlCommand com = new SqlCommand(query, conn))
                    {
                        try
                        {
                            if (IsProcedure)
                            {
                                com.CommandType = CommandType.StoredProcedure;
                            }
                            if (dbParameter != null && dbParameter.Count > 0)
                            {
                                foreach (SqlParameter prm in dbParameter)
                                {
                                    com.Parameters.AddWithValue(prm.ParameterName, prm.Value);
                                }
                                dbParameter.Clear();
                            }
                            if (conn.State != ConnectionState.Open)
                            {
                                conn.Open();
                            }
                            com.ExecuteNonQuery();
                            conn.Close();
                        }
                        catch (Exception ex)
                        {
                            throw new NotImplementedException(ex.Message, ex.InnerException);
                        }
                    }
                    return true;

                case ConnectionType.access:

                    using (OleDbConnection conn = new OleDbConnection(ConnectionString))
                    using (OleDbCommand com = new OleDbCommand(query, conn))
                    {
                        try
                        {
                            if (conn.State != ConnectionState.Open)
                            {
                                conn.Open();
                            }
                            if (dbParameter != null && dbParameter.Count > 0)
                            {
                                foreach (OleDbParameter prm in dbParameter)
                                {
                                    com.Parameters.AddWithValue(prm.ParameterName, prm.Value);
                                }
                                dbParameter.Clear();
                            }
                            com.ExecuteNonQuery();
                            conn.Close();
                        }
                        catch (Exception ex)
                        {
                            throw new NotImplementedException(ex.Message, ex.InnerException);
                        }
                    }
                    return true;

                case ConnectionType.mySql:
                    return false;
                default:
                    return false;
            }
        }
/*
        public bool Execute(string query, object paramaters)
        {
            switch (connType)
            {
                case ConnectionType.sqlServer:

                    using (SqlConnection conn = new SqlConnection(ConnectionString))
                    using (SqlCommand com = new SqlCommand(query, conn))
                    {
                        try
                        {
                            var prmsql = (SqlParameterCollection)paramaters;
                            for (int i = 0; i < prmsql.Count; i++)
                            {
                                com.Parameters.Add(new SqlParameter(prmsql[i].ParameterName, SqlDbType.VarChar));
                                if (prmsql[i].SqlDbType == SqlDbType.VarBinary)
                                {
                                    com.Parameters[com.Parameters.Count - 1].SqlDbType = SqlDbType.VarBinary;
                                }
                                com.Parameters[com.Parameters.Count - 1].Value = prmsql[i].Value;
                            }
                            if (conn.State != ConnectionState.Open)
                            {
                                conn.Open();
                            }
                            com.ExecuteNonQuery();
                            conn.Close();
                        }
                        catch (Exception ex)
                        {
                            throw new NotImplementedException(ex.Message, ex.InnerException);
                        }
                    }
                    return true;

                case ConnectionType.access:

                    using (OleDbConnection conn = new OleDbConnection(ConnectionString))
                    using (OleDbCommand com = new OleDbCommand(query, conn))
                    {
                        try
                        {
                            var prms = (OleDbParameterCollection)paramaters;
                            for (int i = 0; i < prms.Count; i++)
                            {
                                com.Parameters.Add(new OleDbParameter(prms[i].ParameterName, OleDbType.VarChar));
                                if (prms[i].OleDbType == OleDbType.VarBinary)
                                {
                                    com.Parameters[com.Parameters.Count - 1].OleDbType = OleDbType.VarBinary;
                                }
                                com.Parameters[com.Parameters.Count - 1].Value = prms[i].Value;
                            }
                            if (conn.State != ConnectionState.Open)
                            {
                                conn.Open();
                            }
                            com.ExecuteNonQuery();
                            conn.Close();
                        }
                        catch (Exception ex)
                        {
                            throw new NotImplementedException(ex.Message, ex.InnerException);
                        }
                    }
                    return true;

                case ConnectionType.mySql:
                    return false;
                default:
                    return false;
            }
        }
*/
    }
}
