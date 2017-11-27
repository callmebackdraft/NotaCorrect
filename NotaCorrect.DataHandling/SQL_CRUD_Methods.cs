using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NotaCorrect.Exceptions;


namespace NotaCorrect.DataHandling
{
    static class SQL_CRUD_Methods
    {

        private static SqlConnection EstablishConnection()
        {
            SqlConnection DBConnection = new SqlConnection(Properties.Settings.Default.SecondaryDB);
            try
            {
                DBConnection.Open();
                return DBConnection;
            }
            catch (SqlException exc)
            {
                throw new Exception(exc.Message);
            }
        }

        private static SqlCommand BuildSQLCommand(string query, List<KeyValuePair<string, object>> parameterlist)
        {
            SqlConnection conn = EstablishConnection();
            SqlCommand sqlcmd = new SqlCommand(query, conn);
            foreach (KeyValuePair<string, object> kvp in parameterlist)
            {
                sqlcmd.Parameters.AddWithValue(kvp.Key, kvp.Value);
            }
            if (!CheckQueryValidity(sqlcmd, conn))
            {
                throw new SqlQueryException("Invalid Query, check the query for typo's");
            }
            return sqlcmd;
        }

        private static SqlCommand BuildSQLCommand(string query)
        {
            SqlConnection conn = EstablishConnection();
            SqlCommand sqlcmd = new SqlCommand(query, conn);
            if (!CheckQueryValidity(sqlcmd, conn))
            {
                throw new SqlQueryException("Invalid Query, check the query for typo's");
            }
            return sqlcmd;
        }

        private static bool CheckQueryValidity(SqlCommand commandToCheck, SqlConnection conn)
        {
            bool result;
            SqlCommand cmd = new SqlCommand("SET NOEXEC ON", conn);
            cmd.ExecuteNonQuery();
            try
            {
                commandToCheck.ExecuteNonQuery();
                result = true;
            }
            catch
            {
                result = false;
            }
            finally
            {
                cmd = new SqlCommand("SET NOEXEC OFF", conn);
                cmd.ExecuteNonQuery();
            }
            return result;
        }

        public static bool SQLInsert(string query, List<KeyValuePair<string, string>> parameterlist)
        {
            throw new NotImplementedException();
        }

        public static bool SQLCreate(string query)
        {
            throw new NotImplementedException();
        }

        public static bool SQLUpdate(string query, List<KeyValuePair<string, object>> parameterlist)
        {
            if(BuildSQLCommand(query, parameterlist).ExecuteNonQuery() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool SQLDelete(string query)
        {
            throw new NotImplementedException();
        }

        public static DataTable SQLReadNonParameter(string query)
        {
            var result = new DataTable();
            using (var da = new SqlDataAdapter(BuildSQLCommand(query)))
            {
                da.Fill(result);
            }
            return result;
        }

        public static DataTable SQLReadParameterized(string query, List<KeyValuePair<string,object>> parameterlist)
        {
            var result = new DataTable();
            using (var da = new SqlDataAdapter(BuildSQLCommand(query, parameterlist)))
            {
                da.Fill(result);
            }
            return result;
        }

    }
}
