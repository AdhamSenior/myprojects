using System;
using System.Data.SQLite;
using System.Text;

namespace Common.Database
{
    public partial class DbHelper
    {
        /// <summary>
        /// Вставляет данные в таблицу.
        /// </summary>
        /// <param name="tablename">Имя таблицы</param>
        /// <param name="parameters">Коллекция параметров</param>
        /// <returns>ID последней вставленной строки</returns>
        public int Insert(string tablename, ParametersCollection parameters)
        {
            if (String.IsNullOrWhiteSpace(tablename))
                return 0;

            int lastId;
            using (var con = new SQLiteConnection(_csb.ConnectionString))
            {
                con.Open();
                var tran = con.BeginTransaction();

                try
                {
                    using (var cmd = new SQLiteCommand(con))
                    {
                        var isFirst = true;
                        var queryColumns = new StringBuilder("("); //список полей, в которые вставляются новые значения
                        var queryValues = new StringBuilder("("); //список значений для этих полей
                        foreach (Parameter iparam in parameters)
                        {
                            var pVal = Convert.IsDBNull(iparam.Value) ? Convert.DBNull : iparam.Value;
                            cmd.Parameters.Add("@" + iparam.ColumnName, iparam.DbType).Value = pVal;
                            if (isFirst)
                            {
                                queryColumns.Append(iparam.ColumnName);
                                queryValues.Append("@" + iparam.ColumnName);
                                isFirst = false;
                            }
                            else
                            {
                                queryColumns.Append("," + iparam.ColumnName);
                                queryValues.Append(",@" + iparam.ColumnName);
                            }
                        }
                        queryColumns.Append(")");
                        queryValues.Append(")");

                        var query = String.Format("INSERT INTO {0} {1} VALUES {2}", tablename, queryColumns, queryValues);
                        cmd.CommandText = query;
                        cmd.ExecuteNonQuery();
                    }

                    using (var cmd = new SQLiteCommand("SELECT last_insert_rowid();", con))
                    {
                        lastId = int.Parse(cmd.ExecuteScalar().ToString());
                    }

                    tran.Commit();
                }
                catch (SQLiteException ex)
                {
                    _lastError = String.Format("Ошибка при вставке новой записи в таблицу {0}.\n{1}", tablename, ex.Message);
                    tran.Rollback();
                    return 0;
                }
            }
            return lastId;
        }

        /// <summary>
        /// Вставляет несколько записей в таблицу.
        /// </summary>
        /// <param name="tName">Имя таблицы</param>
        /// <param name="prm">Массив параметров/записей</param>
        /// <returns>Возвращает 0, если удачно</returns>
        public int InsertMany(string tName, ParametersCollection[] prm)
        {
            if (String.IsNullOrWhiteSpace(tName))
                return 1;

            using (var con = new SQLiteConnection(_csb.ConnectionString))
            {
                con.Open();
                var tran = con.BeginTransaction();

                try
                {
                    using (var cmd = new SQLiteCommand(con))
                    {
                        foreach (var p in prm)
                        {
                            var ifFirst = true;
                            var queryColumns = new StringBuilder("("); // список полей, в которые вставляются новые значения
                            var queryValues = new StringBuilder("("); // список значений для этих полей
                            foreach (Parameter iparam in p)
                            {
                                var pVal = Convert.IsDBNull(iparam.Value) ? Convert.DBNull : iparam.Value;
                                cmd.Parameters.Add("@" + iparam.ColumnName, iparam.DbType).Value = pVal;
                                if (ifFirst)
                                {
                                    queryColumns.Append(iparam.ColumnName);
                                    queryValues.Append("@" + iparam.ColumnName);
                                    ifFirst = false;
                                }
                                else
                                {
                                    queryColumns.Append("," + iparam.ColumnName);
                                    queryValues.Append(",@" + iparam.ColumnName);
                                }
                            }
                            queryColumns.Append(")");
                            queryValues.Append(")");

                            var query = String.Format("INSERT INTO {0} {1} VALUES {2}", tName, queryColumns, queryValues);
                            cmd.CommandText = query;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    tran.Commit();
                }
                catch (SQLiteException ex)
                {
                    _lastError = String.Format("Ошибка при вставке новой записи в таблицу {0}.\n{1}", tName, ex.Message);
                    tran.Rollback();
                    return 1;
                }
            }
            return 0;
        }

        /// <summary>
        /// Вставляет несколько записей в таблицу.
        /// </summary>
        /// <param name="tName">Имя таблицы</param>
        /// <param name="prm">Массив параметров/записей</param>
        /// <returns>Возвращает 0, если удачно</returns>
        public int InsertOrReplaceMany(string tName, ParametersCollection[] prm)
        {
            if (String.IsNullOrWhiteSpace(tName))
                return 1;

            using (var con = new SQLiteConnection(_csb.ConnectionString))
            {
                con.Open();
                var tran = con.BeginTransaction();

                try
                {
                    using (var cmd = new SQLiteCommand(con))
                    {
                        foreach (var p in prm)
                        {
                            var ifFirst = true;
                            var queryColumns = new StringBuilder("("); // список полей, в которые вставляются новые значения
                            var queryValues = new StringBuilder("("); // список значений для этих полей
                            foreach (Parameter iparam in p)
                            {
                                var pVal = Convert.IsDBNull(iparam.Value) ? Convert.DBNull : iparam.Value;
                                cmd.Parameters.Add("@" + iparam.ColumnName, iparam.DbType).Value = pVal;
                                if (ifFirst)
                                {
                                    queryColumns.Append(iparam.ColumnName);
                                    queryValues.Append("@" + iparam.ColumnName);
                                    ifFirst = false;
                                }
                                else
                                {
                                    queryColumns.Append("," + iparam.ColumnName);
                                    queryValues.Append(",@" + iparam.ColumnName);
                                }
                            }
                            queryColumns.Append(")");
                            queryValues.Append(")");

                            var query = String.Format("INSERT OR REPLACE INTO {0} {1} VALUES {2}", tName, queryColumns, queryValues);
                            cmd.CommandText = query;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    tran.Commit();
                }
                catch (SQLiteException ex)
                {
                    _lastError = String.Format("Ошибка при вставке новой записи в таблицу {0}.\n{1}", tName, ex.Message);
                    tran.Rollback();
                    return 1;
                }
            }
            return 0;
        }
    }
}