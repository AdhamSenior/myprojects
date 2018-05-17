using System;
using System.Data.SQLite;
using System.Text;

namespace Common.Database
{
    public partial class DbHelper
    {
        /// <summary>
        /// Перезаписывает данные в выбранной таблице.
        /// </summary>
        /// <param name="tName">Имя таблицы</param>
        /// <param name="prm">Коллекция полей и значений</param>
        /// <param name="where">Строка условия</param>
        /// <returns>Код ошибки. Если 0, ошибки нет</returns>
        public int Update(string tName, ParametersCollection prm, string where)
        {
            return Update(tName, prm, new[] { where }, "");
        }

        /// <summary>
        /// Перезаписывает данные в выбранной таблице.
        /// </summary>
        /// <param name="tName">Имя таблицы</param>
        /// <param name="prm">Коллекция полей и значений</param>
        /// <param name="wherePrm">Набор условий</param>
        /// <param name="whereSeparator">Разделитель между условиями OR или AND</param>
        /// <returns>Код ошибки. Если 0, ошибки нет</returns>
        public int Update(string tName, ParametersCollection prm, string[] wherePrm, string whereSeparator)
        {
            if (String.IsNullOrWhiteSpace(tName))
                return 1;
            if (wherePrm.Length == 0)
                throw (new ExceptionWarning("Ошибка. Не указано ни одно условие"));
            if (wherePrm.Length > 1 && whereSeparator.Trim().Length == 0)
                throw (new ExceptionWarning("При использовании нескольких условий, требуется указать разделитель OR или AND"));

            using (var con = new SQLiteConnection(_csb.ConnectionString))
            {
                con.Open();
                var tran = con.BeginTransaction();

                try
                {
                    using (var cmd = new SQLiteCommand(con))
                    {
                        var i = 0;
                        var isFirst = true;
                        var upParams = new StringBuilder();
                        foreach (Parameter param in prm)
                        {
                            if (isFirst)
                            {
                                upParams.Append(param.ColumnName + " = @param" + i);
                                isFirst = false;
                            }
                            else
                                upParams.Append("," + param.ColumnName + " = @param" + i);

                            var pVal = Convert.IsDBNull(param.Value) ? Convert.DBNull : param.Value;
                            cmd.Parameters.Add("@param" + i, param.DbType).Value = pVal;
                            i++;
                        }

                        isFirst = true;
                        var whParams = new StringBuilder();
                        foreach (var item in wherePrm)
                        {
                            if (isFirst)
                            {
                                whParams.Append(item);
                                isFirst = false;
                            }
                            else
                                whParams.Append(" " + whereSeparator + " " + item);
                        }

                        cmd.CommandText = String.Format("UPDATE {0} SET {1} {2}", tName, upParams, String.Format("WHERE {0}", whParams));
                        cmd.ExecuteNonQuery();
                    }
                    tran.Commit();
                }
                catch (SQLiteException se)
                {
                    _lastError = String.Format("Ошибка при обновлении данных в таблице {0}.\n{1}", tName, se.Message);
                    tran.Rollback();
                    return 1;
                }
                catch (Exception ex)
                {
                    _lastError = String.Format("Ошибка при обновлении данных в таблице {0}.\n{1}", tName, ex.Message);
                    tran.Rollback();
                    return 2;
                }
            }
            return 0;
        }
    }
}