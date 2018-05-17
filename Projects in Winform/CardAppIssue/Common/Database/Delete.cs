using System;
using System.Data.SQLite;
using System.Text;

namespace Common.Database
{
    public partial class DbHelper
    {
        /// <summary>
        /// Удаляет все данные из выбранной таблицы.
        /// </summary>
        /// <param name="tName">Имя таблицы</param>
        /// <returns>Код ошибки. Если 0, ошибки нет</returns>
        public int Delete(string tName)
        {
            if (String.IsNullOrWhiteSpace(tName))
                return 1;

            using (var con = new SQLiteConnection(_csb.ConnectionString))
            {
                con.Open();
                var tran = con.BeginTransaction();

                try
                {
                    var query = String.Format("DELETE FROM {0}", tName);
                    using (var cmd = new SQLiteCommand(query, con))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    tran.Commit();
                }
                catch (SQLiteException ex)
                {
                    _lastError = String.Format("Ошибка при удалении данных из таблицы {0}.\n{1}", tName, ex.Message);
                    tran.Rollback();
                    return 1;
                }
            }
            return 0;
        }

        /// <summary>
        /// Удаляет все данные по условию.
        /// </summary>
        /// <param name="tName">Имя таблицы</param>
        /// <param name="where">Строка условий, начинающихся с WHERE</param>
        /// <param name="prm">Список параметров</param>
        /// <returns>Код ошибки. Если 0, ошибки нет</returns>
        public int Delete(string tName, string where, ParametersCollection prm)
        {
            if (String.IsNullOrWhiteSpace(tName))
                return 1;

            if (!String.IsNullOrWhiteSpace(tName) && !where.ToLower().Trim().StartsWith("where"))
                where = "WHERE " + where;

            using (var con = new SQLiteConnection(_csb.ConnectionString))
            {
                con.Open();
                var tran = con.BeginTransaction();

                try
                {
                    var query = String.Format("DELETE FROM {0} {1}", tName, where);
                    using (var cmd = new SQLiteCommand(query, con))
                    {
                        foreach (Parameter iparam in prm)
                        {
                            var pName = iparam.ColumnName.StartsWith("@") ? iparam.ColumnName : "@" + iparam.ColumnName;
                            var pVal = Convert.IsDBNull(iparam.Value) ? Convert.DBNull : iparam.Value;
                            cmd.Parameters.Add(pName, iparam.DbType).Value = pVal;
                        }
                        cmd.ExecuteNonQuery();
                    }
                    tran.Commit();
                }
                catch (SQLiteException ex)
                {
                    _lastError = String.Format("Ошибка при удалении данных из таблицы {0}.\n{1}", tName, ex.Message);
                    tran.Rollback();
                    return 1;
                }
            }
            return 0;
        }

        /// <summary>
        /// Удаляет все данные по условию.
        /// </summary>
        /// <param name="tName">Имя таблицы</param>
        /// <param name="where">Строка условий, начинающихся с WHERE</param>
        /// <returns>Код ошибки. Если 0, ошибки нет</returns>
        public int Delete(string tName, string where)
        {
            if (String.IsNullOrWhiteSpace(tName))
                return 1;

            if (!String.IsNullOrWhiteSpace(where) && !where.ToLower().Trim().StartsWith("where"))
                where = "WHERE " + where;

            using (var con = new SQLiteConnection(_csb.ConnectionString))
            {
                con.Open();
                var tran = con.BeginTransaction();

                try
                {
                    var query = String.Format("DELETE FROM {0} {1}", tName, where);
                    using (var cmd = new SQLiteCommand(query, con))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    tran.Commit();
                }
                catch (SQLiteException ex)
                {
                    _lastError = String.Format("Ошибка при удалении данных из таблицы {0}.\n{1}", tName, ex.Message);
                    tran.Rollback();
                    return 1;
                }
            }

            return 0;
        }

        /// <summary>
        /// Удаляет данные из таблицы с массивом условий.
        /// </summary>
        /// <param name="tName">Имя таблицы</param>
        /// <param name="column">Название поля</param>
        /// <param name="collection">Массив объектов с условием</param>
        /// <returns>Код ошибки. Если 0, ошибки нет</returns>
        public int Delete(string tName, string column, object[] collection)
        {
            if (String.IsNullOrWhiteSpace(tName))
                return 1;

            using (var con = new SQLiteConnection(_csb.ConnectionString))
            {
                con.Open();
                var tran = con.BeginTransaction();

                try
                {
                    #region Создаем строку условий

                    var isFirst = true;
                    var where = new StringBuilder();
                    foreach (var item in collection)
                    {
                        if (isFirst)
                        {
                            where.Append("WHERE " + column + " = '" + item + "'");
                            isFirst = false;
                        }
                        else
                            where.Append(" OR " + column + " = '" + item + "'");
                    }

                    #endregion

                    var query = String.Format("DELETE FROM {0} {1}", tName, where);
                    using (var cmd = new SQLiteCommand(query, con))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    tran.Commit();
                }
                catch (SQLiteException ex)
                {
                    _lastError = String.Format("Ошибка при удалении данных из таблицы {0}.\n{1}", tName, ex.Message);
                    tran.Rollback();
                    return 1;
                }
            }
            return 0;
        }
    }
}