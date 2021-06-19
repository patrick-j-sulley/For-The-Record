using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ForTheRecord_SelfHost
{
    static class clsDBConnection
    {
        // use dynamic class & methods if any of the following variables need to be dynamically assigned
        // and different connections be used in parallel.
        private static ConnectionStringSettings ConnectionStringSettings =
ConfigurationManager.ConnectionStrings["MyApp"];
        private static DbProviderFactory ProviderFactory =
DbProviderFactories.GetFactory(ConnectionStringSettings.ProviderName);
        private static string ConnectionStr = ConnectionStringSettings.ConnectionString;

        public static DataTable SProcTable(string prSprocName, Dictionary<string, Object> prPars)
        // returns the table result of a stored procedure, e.g. "MyProc" as prSprocName
        // supply parameters via prPars dictionary like ("prMyPar1", "Fred"), ("prMyPar2", 123)
        {
            return GetDataTable(prSprocName, prPars, CommandType.StoredProcedure);
        }

        public static Object DbFunction(string prFunctionName, Dictionary<string, Object> prPars)
        // returns a single result of a stored Function as an Object, e.g. "MyFunct" as prFunctionName
        // supply parameters via prPars dictionary like ("prMyPar1", "Fred"), ("prMyPar2", 123)
        {
            string lcParameterStr = assembleParameterString(prPars);
            DataTable lcResult = GetDataTable($"SELECT {prFunctionName}({lcParameterStr})", prPars);
            return lcResult.Rows[0][0];
        }

        public static int Execute(string prSQL, Dictionary<string, Object> prPars)
        // Execute an SQL command directly
        // Only recommended for testing purposes, better use SProcTable() and execute a stored procedure
        // For UPDATE, INSERT, and DELETE statements, the return value is the number of rows affected by the command
        // For all other types of statements, the return value is -1
        // Supply parameters via prPars dictionary like ("prMyPar1", "Fred"), ("prMyPar2", 123)
        {
            using (DbConnection lcDataConnection = ProviderFactory.CreateConnection())
            using (DbCommand lcCommand = lcDataConnection.CreateCommand())
            {
                lcDataConnection.ConnectionString = ConnectionStr;
                lcDataConnection.Open();
                lcCommand.CommandText = prSQL;
                setPars(lcCommand, prPars);
                return lcCommand.ExecuteNonQuery();
            }
        }

        private static DataTable GetDataTable(string prSQL, Dictionary<string, Object> prPars)
        // returns the result of a general query, e.g. "SELECT @val1, @val2 FROM MyTable" as prSQL
        // supply parameters val1 and val2 via prPars dictionary like ("val1", "myCol1"), ("val2", "myCol2")
        {
            return GetDataTable(prSQL, prPars, CommandType.Text);
        }

        private static DataTable GetDataTable(string prSQL, Dictionary<string, Object> prPars, CommandType prCommandType)
        // returns the table result of a general query, e.g. "SELECT @val1, @val2 FROM MyTable" as prSQL (if prCommandType = Text)
        // or the table result of a stored procedure, e.g. "MyProc" as prSQL, if prCommandType is StoredProcedure
        // supply parameters via prPars dictionary e.g. ("val1", "Fred"), ("val2", 123)
        {
            using (DataTable lcDataTable = new DataTable("TheTable"))
            using (DbConnection lcDataConnection = ProviderFactory.CreateConnection())
            using (DbCommand lcCommand = lcDataConnection.CreateCommand())
            {
                lcDataConnection.ConnectionString = ConnectionStr;
                lcDataConnection.Open();
                lcCommand.CommandText = prSQL;
                lcCommand.CommandType = prCommandType;
                setPars(lcCommand, prPars);
                using (DbDataReader lcDataReader = lcCommand.ExecuteReader(CommandBehavior.SingleResult))
                    lcDataTable.Load(lcDataReader);
                return lcDataTable;
            }
        }

        private static void setPars(DbCommand prCommand, Dictionary<string, Object> prPars)
        {   // For most DBMS using @Name1, @Name2, @Name3 etc.
            if (prPars != null)
                foreach (KeyValuePair<string, Object> lcItem in prPars)
                {
                    DbParameter lcPar = prCommand.CreateParameter();
                    lcPar.Value = lcItem.Value == null ? DBNull.Value : lcItem.Value;
                    lcPar.ParameterName = '@' + lcItem.Key.Trim();
                    prCommand.Parameters.Add(lcPar);
                    // optional:
                    // lcPar.Direction = ParameterDirection.Input;
                }
        }

        private static string assembleParameterString(Dictionary<string, Object> prPars)
        {
            string lcResult = null;
            if (prPars != null)
            {
                foreach (object lcItem in prPars.Keys)
                    lcResult += '@' + lcItem.ToString().Trim() + ',';
                if (lcResult != null) lcResult = lcResult.TrimEnd(',');
            }
            return lcResult;
        }

    }
}
