using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace Common.Database
{
    public partial class DbHelper
    {
        private string _lastError = String.Empty;
        public string LastError
        {
            get { return _lastError; }
        }

        readonly SQLiteConnectionStringBuilder _csb = new SQLiteConnectionStringBuilder();

        #region Инициализация

        /// <summary>
        /// Инициализация подключения.
        /// </summary>
        /// <param name="fileName">Путь к файлу базы данных</param>
        public DbHelper(string fileName)
        {
            _csb.DataSource = fileName;
            ClearLastError();
        }

        /// <summary>
        /// Инициализация подключения.
        /// </summary>
        /// <param name="fileName">Путь к файлу базы данных</param>
        /// <param name="password">Пароль</param>
        public DbHelper(string fileName, string password)
        {
            _csb.DataSource = fileName;
            _csb.Password = password;
        }

        /// <summary>
        /// Инициализация подключения.
        /// </summary>
        /// <param name="csb"></param>
        public DbHelper(SQLiteConnectionStringBuilder csb)
        {
            _csb = csb;
        }

        #endregion

        #region Дополнительные инструменты

        /// <summary>
        /// Имя файла базы данных.
        /// </summary>
        public string Filename
        {
            get { return _csb.DataSource; }
        }

        /// <summary>
        /// Информация о таблице.
        /// </summary>
        /// <param name="tName">Имя таблицы</param>
        /// <returns>Перечисленные колонки в виде List</returns>
        public List<string> TableInfo(string tName)
        {
            var columns = new List<string>();
            var dt = Execute(String.Format("PRAGMA table_info([{0}])", tName));
            foreach (DataRow row in dt.Rows)
                columns.Add(row[0].ToString());
            return columns;
        }

        /// <summary>
        /// Список таблиц (временные таблицы не входят в список).
        /// </summary>        
        /// <returns>Список таблиц в виде List</returns>
        public List<string> GetTables()
        {
            var tables = new List<string>();
            var dt = Execute("SELECT name FROM sqlite_master WHERE type='table' ORDER BY name");
            foreach (DataRow row in dt.Rows)
                tables.Add(row[0].ToString());
            return tables;
        }

        /// <summary>
        /// Список всех таблиц, включая временные.
        /// </summary>        
        /// <returns>Список таблиц в виде List</returns>
        public List<string> GetAllTables()
        {
            var tables = new List<string>();
            var dt = Execute(@"SELECT name FROM 
					                (SELECT * FROM sqlite_master UNION ALL SELECT * FROM sqlite_temp_master)
					           WHERE type='table'
					           ORDER BY name");
            foreach (DataRow row in dt.Rows)
                tables.Add(row[0].ToString());
            return tables;
        }

        /// <summary>
        /// Сжать базу данных.
        /// </summary>
        public void Vacuum()
        {
            using (var con = new SQLiteConnection(_csb.ConnectionString))
            {
                con.Open();
                try
                {
                    using (var cmd = new SQLiteCommand("VACUUM;", con))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SQLiteException ex)
                {
                    _lastError = String.Format("Ошибка при выволнении команды VACUUM\n{0}", ex.Message);
                }
            }
        }

        /// <summary>
        /// Очистка последней ошибки.
        /// </summary>
        public void ClearLastError()
        {
            _lastError = String.Empty;
        }

        /// <summary>
        /// Изменение пароля для базы данных.
        /// </summary>
        /// <param name="password">Пароль</param>
        public void ChangePassword(string password)
        {
            using (var con = new SQLiteConnection(_csb.ConnectionString))
            {
                con.Open();
                try
                {
                    con.ChangePassword(password);
                }
                catch (SQLiteException ex)
                {
                    _lastError = String.Format("Ошибка при смене пароля!\n{0}", ex.Message);
                }
            }
        }

        public long RowCount(string table)
        {
            long rs = -1;
            using (var con = new SQLiteConnection(_csb.ConnectionString))
            {
                con.Open();
                try
                {
                    using (var cmd = new SQLiteCommand(con))
                    {
                        cmd.CommandText = "SELECT COUNT(*) FROM " + table;
                        rs = (long)cmd.ExecuteScalar();
                    }
                }
                catch (SQLiteException ex)
                {
                    _lastError = String.Format("Ошибка при выполнении запроса в методе RowCount.\n{0}", ex.Message);
                }
            }
            return rs;
        }

        #endregion

        #region Выполнение любого запроса без получения данных

        /// <summary>
        /// Выполняет запрос к базе данных.
        /// </summary>
        /// <param name="query">Строка запроса</param>
        /// <returns>Код ошибки. Если 0, ошибки нет</returns>
        public int ExecuteNonQuery(string query)
        {
            return ExecuteNonQuery(new[] { query });
        }

        /// <summary>
        /// Выполняет запрос к базе данных.
        /// </summary>
        /// <param name="queries">Массив запросов</param>
        /// <returns>Код ошибки. Если 0 - ошибки нет</returns>
        public int ExecuteNonQuery(string[] queries)
        {
            using (var con = new SQLiteConnection(_csb.ConnectionString))
            {
                con.Open();
                try
                {
                    using (var cmd = new SQLiteCommand(con))
                    {
                        foreach (string query in queries)
                        {
                            cmd.CommandText = query;
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                catch (SQLiteException ex)
                {
                    _lastError = String.Format("Ошибка при выполнении запроса в методе ExecuteNonQuery.\n{0}", ex.Message);
                    return 1;
                }
            }
            return 0;
        }

        #endregion

        #region Получение данных

        /// <summary>
        /// Получает данные из таблицы.
        /// </summary>
        /// <param name="tName">Имя таблицы</param>
        /// <returns>Таблица с данными</returns>
        public DataTable FetchAll(string tName)
        {
            return FetchAll(tName, "", "");
        }

        /// <summary>
        /// Получает данные из таблицы.
        /// </summary>
        /// <param name="tName">Имя таблицы</param>
        /// <param name="where">Строка условий, начинающихся с WHERE</param>
        /// <returns>Таблица с данными</returns>
        public DataTable FetchAll(string tName, string where)
        {
            return FetchAll(tName, where, "");
        }

        /// <summary>
        /// Получает данные из таблицы.
        /// </summary>
        /// <param name="tName">Имя таблицы</param>
        /// <param name="where">Строка условий, начинающихся с WHERE</param>
        /// <param name="etc">Остальные параметры: сортировка, группировка и т.д.</param>
        /// <returns>Таблица с данными</returns>
        public DataTable FetchAll(string tName, string where, string etc)
        {
            if (!String.IsNullOrWhiteSpace(where) && !where.ToLower().Trim().StartsWith("where"))
                where = "WHERE " + where;
            var query = String.Format("SELECT * FROM {0} {1} {2}", tName, where, etc);
            return Execute(query);
        }

        /// <summary>
        /// Получение данных по выбранным полям (колонкам).
        /// </summary>
        /// <param name="tName">Имя таблицы</param>
        /// <param name="columns">Массив колонок, которые необходимо получить</param>
        /// <returns>Таблица с данными</returns>
        public DataTable FetchByColumn(string tName, string[] columns)
        {
            return FetchByColumn(tName, columns, "", "");
        }

        /// <summary>
        /// Получение данных по выбранным полям (колонкам).
        /// </summary>
        /// <param name="tName">Имя таблицы</param>
        /// <param name="columns">Строка колонок через запятую, которые необходимо получить</param>
        /// <returns>Таблица с данными</returns>
        public DataTable FetchByColumn(string tName, string columns)
        {
            return FetchByColumn(tName, columns, "", "");
        }

        /// <summary>
        /// Получение данных по выбранным полям (колонкам).
        /// </summary>
        /// <param name="tName">Имя таблицы</param>
        /// <param name="columns">Массив колонок, которые необходимо получить</param>
        /// <param name="where">Строка условий, начинающихся с WHERE</param>
        /// <returns>Таблица с данными</returns>
        public DataTable FetchByColumn(string tName, string[] columns, string where)
        {
            return FetchByColumn(tName, columns, where, "");
        }

        /// <summary>
        /// Получение данных по выбранным полям (колонкам).
        /// </summary>
        /// <param name="tName">Имя таблицы</param>
        /// <param name="columns">Строка колонок через запятую, которые необходимо получить</param>
        /// <param name="where">Строка условий, начинающихся с WHERE</param>
        /// <returns>Таблица с данными</returns>
        public DataTable FetchByColumn(string tName, string columns, string where)
        {
            return FetchByColumn(tName, columns, where, "");
        }

        /// <summary>
        /// Получение данных по выбранным полям (колонкам).
        /// </summary>
        /// <param name="tName">Имя таблицы</param>
        /// <param name="columns">Массив колонок, которые необходимо получить</param>
        /// <param name="where">Строка условий, начинающихся с WHERE</param>
        /// <param name="etc">Остальные параметры: сортировка, группировка и т.д.</param>
        /// <returns>Таблица с данными</returns>
        public DataTable FetchByColumn(string tName, string[] columns, string where, string etc)
        {
            return FetchByColumn(tName, ColumnsToLine(columns), where, etc);
        }

        /// <summary>
        /// Получение данных по выбранным полям (колонкам).
        /// </summary>
        /// <param name="tName">Имя таблицы</param>
        /// <param name="columns">Строка колонок через запятую, которые необходимо получить</param>
        /// <param name="where">Строка условий, начинающихся с WHERE</param>
        /// <param name="etc">Остальные параметры: сортировка, группировка и т.д.</param>
        /// <returns>Таблица с данными</returns>
        public DataTable FetchByColumn(string tName, string columns, string where, string etc)
        {
            if (!String.IsNullOrWhiteSpace(where) && !where.ToLower().Trim().StartsWith("where"))
                where = "WHERE " + where;

            if (String.IsNullOrWhiteSpace(tName))
                return null;

            var query = String.Format("SELECT {0} FROM {1} {2} {3}", columns, tName, where, etc);
            return Execute(query);
        }

        /// <summary>
        /// Выполняет запрос, созданный с помощью конструктора класса Select.
        /// </summary>
        /// <param name="select">Объект запроса</param>
        /// <returns>Таблица с данными</returns>
        public DataTable Execute(Select select)
        {
            return Execute(select.SelectCommand);
        }

        /// <summary>
        /// Выполняет запрос, созданный с помощью конструктора класса Select.
        /// </summary>
        /// <param name="select">Объект запроса</param>
        /// <param name="parameters">Коллекция параметров</param>
        /// <returns>Таблица с данными</returns>
        public DataTable Execute(Select select, ParametersCollection parameters)
        {
            return Execute(select.SelectCommand, parameters);
        }

        /// <summary>
        /// Выполняет переданный запрос в виде строки.
        /// </summary>
        /// <param name="query">Строка запроса</param>
        /// <param name="parameters">Коллекция параметров</param>
        /// <returns>Таблица с данными</returns>
        public DataTable Execute(string query, ParametersCollection parameters)
        {
            var dt = new DataTable();
            using (var con = new SQLiteConnection(_csb.ConnectionString))
            {
                con.Open();
                try
                {
                    using (var cmd = new SQLiteCommand(query, con))
                    {
                        foreach (Parameter iparam in parameters)
                        {
                            var pName = iparam.ColumnName.StartsWith("@") ? iparam.ColumnName : "@" + iparam.ColumnName;
                            var pVal = Convert.IsDBNull(iparam.Value) ? Convert.DBNull : iparam.Value;
                            cmd.Parameters.Add(pName, iparam.DbType).Value = pVal;
                        }

                        using (var adapter = new SQLiteDataAdapter(cmd))
                            adapter.Fill(dt);
                    }
                }
                catch (SQLiteException ex)
                {
                    _lastError = String.Format("Ошибка при получении данных из базы данных {0}.\n{1}", _csb.DataSource, ex.Message);
                    return null;
                }
            }
            return dt;
        }

        /// <summary>
        /// Выполняет переданный запрос в виде строки.
        /// </summary>
        /// <param name="query">Строка запроса</param>
        /// <returns>Таблица с данными</returns>
        public DataTable Execute(string query)
        {
            var dt = new DataTable();
            using (var con = new SQLiteConnection(_csb.ConnectionString))
            {
                con.Open();
                try
                {
                    using (var cmd = new SQLiteCommand(query, con))
                    {
                        using (var adapter = new SQLiteDataAdapter(cmd))
                            adapter.Fill(dt);
                    }
                }
                catch (SQLiteException ex)
                {
                    _lastError = String.Format("Ошибка при получении из базы данных {0}.\n{1}", _csb.DataSource, ex.Message);
                    return null;
                }
            }
            return dt;
        }

        #region Получение одной строки

        /// <summary>
        /// Вернуть первую строку из полученных данных.
        /// </summary>
        /// <param name="tName">Имя таблицы</param>
        /// <param name="columns">Массив колонок, которые необходимо получить</param>
        /// <returns>Ассоциативный массив</returns>
        public Dictionary<string, object> FetchOneRow(string tName, string[] columns)
        {
            return FetchOneRow(tName, columns, "", "");
        }

        /// <summary>
        /// Вернуть первую строку из полученных данных.
        /// </summary>
        /// <param name="tName">Имя таблицы</param>
        /// <param name="columns">Строка колонок через запятую, которые необходимо получить</param>
        /// <returns>Ассоциативный массив</returns>
        public Dictionary<string, object> FetchOneRow(string tName, string columns)
        {
            return FetchOneRow(tName, columns, "", "");
        }

        /// <summary>
        /// Вернуть первую строку из полученных данных.
        /// </summary>
        /// <param name="tName">Имя таблицы</param>
        /// <param name="columns">Массив колонок, которые необходимо получить</param>
        /// <param name="where">Строка условий, начинающихся с WHERE</param>
        /// <returns>Ассоциативный массив</returns>
        public Dictionary<string, object> FetchOneRow(string tName, string[] columns, string where)
        {
            return FetchOneRow(tName, columns, where, "");
        }

        /// <summary>
        /// Вернуть первую строку из полученных данных.
        /// </summary>
        /// <param name="tName">Имя таблицы</param>
        /// <param name="columns">Строка колонок через запятую, которые необходимо получить</param>
        /// <param name="where">Строка условий, начинающихся с WHERE</param>
        /// <returns>Ассоциативный массив</returns>
        public Dictionary<string, object> FetchOneRow(string tName, string columns, string where)
        {
            return FetchOneRow(tName, columns, where, "");
        }

        /// <summary>
        /// Вернуть первую строку из полученных данных.
        /// </summary>
        /// <param name="tName">Имя таблицы</param>
        /// <param name="columns">Массив колонок, которые необходимо получить</param>
        /// <param name="where">Строка условий, начинающихся с WHERE</param>
        /// <param name="etc">Остальные параметры: сортировка, группировка и т.д.</param>
        /// <returns>Ассоциативный массив</returns>
        public Dictionary<string, object> FetchOneRow(string tName, string[] columns, string where, string etc)
        {
            return FetchOneRow(tName, ColumnsToLine(columns), where, etc);
        }

        /// <summary>
        /// Вернуть первую строку из полученных данных.
        /// </summary>
        /// <param name="tName">Имя таблицы</param>
        /// <param name="columns">Строка колонок через запятую, которые необходимо получить</param>
        /// <param name="where">Строка условий, начинающихся с WHERE</param>
        /// <param name="etc">Остальные параметры: сортировка, группировка и т.д.</param>
        /// <returns>Ассоциативный массив</returns>
        public Dictionary<string, object> FetchOneRow(string tName, string columns, string where, string etc)
        {
            if (!String.IsNullOrWhiteSpace(where) && !where.Trim().ToLower().StartsWith("where"))
                where = "WHERE " + where;

            if (String.IsNullOrWhiteSpace(tName))
                return null;

            var query = String.Format("SELECT {0} FROM {1} {2} {3}", columns, tName, where, etc);
            return FetchOneRow(query);
        }

        /// <summary>
        /// Вернуть первую строку из полученных данных.
        /// </summary>
        /// <param name="select">Объект Select</param>
        /// <returns>Ассоциативный массив</returns>
        public Dictionary<string, object> FetchOneRow(Select select)
        {
            return FetchOneRow(select.SelectCommand);
        }

        /// <summary>
        /// Вернуть первую строку из полученных данных.
        /// </summary>
        /// <param name="select">Объект Select</param>
        /// <param name="parameters">Коллекция параметров</param>
        /// <returns>Ассоциативный массив</returns>
        public Dictionary<string, object> FetchOneRow(Select select, ParametersCollection parameters)
        {
            return FetchOneRow(select.SelectCommand, parameters);
        }

        /// <summary>
        /// Вернуть первую строку из полученных данных.
        /// </summary>
        /// <param name="query">Строка запроса</param>
        /// <param name="parameters">Коллекция параметров</param>
        /// <returns>Ассоциативный массив</returns>
        public Dictionary<string, object> FetchOneRow(string query, ParametersCollection parameters)
        {
            var rowItem = new Dictionary<string, object>();
            using (var con = new SQLiteConnection(_csb.ConnectionString))
            {
                con.Open();
                try
                {
                    using (var cmd = new SQLiteCommand(query, con))
                    {
                        foreach (Parameter iparam in parameters)
                        {
                            var pName = iparam.ColumnName.StartsWith("@") ? iparam.ColumnName : "@" + iparam.ColumnName;
                            var pVal = Convert.IsDBNull(iparam.Value) ? Convert.DBNull : iparam.Value;
                            cmd.Parameters.Add(pName, iparam.DbType).Value = pVal;
                        }

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                for (var i = 0; i < reader.FieldCount; i++)
                                    rowItem.Add(reader.GetName(i), reader[i]);
                            }
                        }
                    }
                }
                catch (SQLiteException ex)
                {
                    _lastError = String.Format("Ошибка при получении из базы данных {0}.\n{1}", _csb.DataSource, ex.Message);
                    return null;
                }
            }
            return rowItem;
        }

        /// <summary>
        /// Вернуть первую строку из полученных данных.
        /// </summary>
        /// <param name="query">Строка запроса</param>
        /// <returns>Ассоциативный массив</returns>
        public Dictionary<string, object> FetchOneRow(string query)
        {
            var rowItem = new Dictionary<string, object>();
            using (var con = new SQLiteConnection(_csb.ConnectionString))
            {
                con.Open();
                try
                {
                    using (var cmd = new SQLiteCommand(query, con))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                for (var i = 0; i < reader.FieldCount; i++)
                                    rowItem.Add(reader.GetName(i), reader[i]);
                            }
                        }
                    }
                }
                catch (SQLiteException ex)
                {
                    _lastError = String.Format("Ошибка при получении из базы данных {0}.\n{1}", _csb.DataSource, ex.Message);
                    return null;
                }
            }
            return rowItem;
        }

        #endregion

        #endregion

        /// <summary>
        /// Массив колонок в строку.
        /// </summary>
        /// <param name="columns">Массив колонок</param>
        /// <returns>Колонки через запятую</returns>
        static string ColumnsToLine(string[] columns)
        {
            string textOfColumns;
            if (ReferenceEquals(columns, null) || columns.Length == 0)
                textOfColumns = "*";
            else
                textOfColumns = String.Join(",", columns);
            return textOfColumns;
        }

        #region Перегрузка и добавление встроенных функций библиотеки SQLite

        /// <summary>
        /// Перевод в нижний регистр.
        /// </summary>
        [SQLiteFunction(Name = "lower", Arguments = 1, FuncType = FunctionType.Scalar)]
        public class ToLowerCase : SQLiteFunction
        {
            public override object Invoke(object[] args)
            {
                return ReferenceEquals(args, null) || args.Length == 0 ? null : args[0].ToString().ToLower();
            }
        }

        /// <summary>
        /// Перевод в верхний регистр.
        /// </summary>
        [SQLiteFunction(Name = "upper", Arguments = 1, FuncType = FunctionType.Scalar)]
        public class ToUpperCase : SQLiteFunction
        {
            public override object Invoke(object[] args)
            {
                if (ReferenceEquals(args, null) || args.Length == 0)
                    return null;
                return args[0].ToString().ToUpper();
            }
        }

        /// <summary>
        /// Текущая дата.
        /// </summary>
        [SQLiteFunction(Name = "date", Arguments = 0, FuncType = FunctionType.Scalar)]
        public class DateNow : SQLiteFunction
        {
            public override object Invoke(object[] args)
            {
                return ReferenceEquals(args, null) || args.Length == 0 ? (object)null : DateTime.Now.Date;
            }
        }

        /// <summary>
        /// Текущая дата и время.
        /// </summary>
        [SQLiteFunction(Name = "now", Arguments = 0, FuncType = FunctionType.Scalar)]
        public class DateTimeNow : SQLiteFunction
        {
            public override object Invoke(object[] args)
            {
                return ReferenceEquals(args, null) || args.Length == 0 ? (object)null : DateTime.Now;
            }
        }

        #endregion
    }

    #region Параметры

    /// <summary>
    /// Класс параметра, для передачи конструктору запроса.
    /// </summary>
    public class Parameter
    {
        #region Поля

        #endregion

        /// <summary>
        /// Значение поля.
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Название поля в базе данных.
        /// </summary>
        public string ColumnName { get; set; }

        /// <summary>
        /// Тип значения.
        /// </summary>
        public DbType DbType { get; set; }
    }

    /// <summary>
    /// Коллекция параметров.
    /// </summary>
    public class ParametersCollection : CollectionBase
    {
        /// <summary>
        /// Добавляет параметры в коллекцию.
        /// </summary>
        /// <param name="iparam">Параметр</param>
        public virtual void Add(Parameter iparam)
        {
            List.Add(iparam);
        }

        /// <summary>
        /// Добавляет параметр в коллекцию.
        /// </summary>
        /// <param name="columnName">Имя поля/колонки</param>
        /// <param name="value">Значение</param>
        /// <param name="dbType">Тип значения</param>
        public virtual void Add(string columnName, object value, DbType dbType)
        {
            var iparam = new Parameter { ColumnName = columnName, Value = value, DbType = dbType };
            List.Add(iparam);
        }

        /// <summary>
        /// Возвращает элемент по индексу.
        /// </summary>
        /// <param name="index">Индекс</param>
        /// <returns>Параметр, для передачи конструктору запроса</returns>
        public virtual Parameter this[int index]
        {
            get { return (Parameter)List[index]; }
        }
    }

    #endregion

    #region Класс исключений

    /// <summary>
    /// Класс исключения для проверки строки запроса для базы данных.
    /// </summary>
    class ExceptionWarning : Exception
    {
        private readonly string _messageText;
        /// <summary>
        /// Текст сообщения об ошибке.
        /// </summary>
        public string MessageText
        {
            get { return _messageText; }
        }

        /// <summary>
        /// Текст сообщения об ошибке.
        /// </summary>
        /// <param name="messagetext">Сообщение об ошибке</param>
        public ExceptionWarning(string messagetext)
        {
            _messageText = messagetext;
        }
    }

    #endregion
}