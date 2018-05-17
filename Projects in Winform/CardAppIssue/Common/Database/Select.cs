using System;
using System.Collections.Generic;

namespace Common.Database
{
    /// <summary>
    /// Типы связывания таблиц между собой.
    /// </summary>
    public enum SqlJoinTypes
    {
        InnerJoin = 1,
        LeftJoin,
        RightJoin,
        FullJoin,
        CrossJoin
    }

    /// <summary>
    /// Класс для создания строки запроса. Работает как конструктор запроса.
    /// </summary>
    public class Select
    {
        #region Константы

        const string InnerJoin = "inner join";
        const string LeftJoin = "left join";
        const string RightJoin = "right join";
        const string FullJoin = "full join";
        const string CrossJoin = "cross join";

        const string SqlWildcard = "*";
        const string SqlFrom = "FROM";
        const string SqlWhere = "WHERE";
        const string SqlGroupBy = "GROUP BY";
        const string SqlOrderBy = "ORDER BY";
        const string SqlHaving = "HAVING";
        const string SqlLimit = "LIMIT";

        #endregion

        #region Приватные переменные

        private string _from = String.Empty;
        private string _columns = "*";
        private string _where = String.Empty;
        private string _group = String.Empty;
        private string _having = String.Empty;
        private string _order = String.Empty;
        private string _lastError = String.Empty;
        private int _limitCount, _limitOffset;

        readonly List<JoinObj> _collectionJoin = new List<JoinObj>();

        #endregion

        /// <summary>
        /// Строка запроса.
        /// </summary>
        public string SelectCommand
        {
            get { return Constructor(); }
        }

        public string LastError
        {
            get { return _lastError; }
        }

        /// <summary>
        /// Строка запроса.
        /// </summary>
        /// <returns>Тест запроса к базе данных</returns>
        public override string ToString()
        {
            return Constructor();
        }

        private class JoinObj
        {
            readonly string _name;
            readonly string _conditional;
            readonly SqlJoinTypes _type;

            /// <summary>
            /// Условное выражение.
            /// </summary>
            public string Conditional
            {
                get { return _conditional; }
            }

            /// <summary>
            /// Имя таблицы.
            /// </summary>
            public string Name
            {
                get { return _name; }
            }

            /// <summary>
            /// Тип связывания.
            /// </summary>
            public string SqlJoinType
            {
                get
                {
                    switch (_type)
                    {
                        case SqlJoinTypes.InnerJoin:
                            return InnerJoin;
                        case SqlJoinTypes.LeftJoin:
                            return LeftJoin;
                        case SqlJoinTypes.RightJoin:
                            return RightJoin;
                        case SqlJoinTypes.FullJoin:
                            return FullJoin;
                        case SqlJoinTypes.CrossJoin:
                            return CrossJoin;
                        default:
                            return "";
                    }
                }
            }

            public JoinObj(string name, string conditional, SqlJoinTypes type)
            {
                _name = name;
                _conditional = conditional;
                _type = type;
            }
        }

        #region Публичные методы

        /// <summary>
        /// Задает имя таблицы.
        /// </summary>
        /// <param name="tablename">Имя таблицы</param>
        /// <returns>Объект для создания строки запроса</returns>
        public Select From(string tablename)
        {
            _from = tablename;
            return this;
        }

        /// <summary>
        /// Задает имя таблицы и возвращаемые поля.
        /// </summary>
        /// <param name="tablename">Имя таблицы</param>
        /// <param name="columns">Поля, которые нужно получить</param>
        /// <returns>Объект для создания строки запроса</returns>
        public Select From(string tablename, string[] columns)
        {
            _from = tablename;
            if (ReferenceEquals(columns, null) || columns.Length == 0)
                _columns = SqlWildcard;
            else
                _columns = ColumnsToLine(columns);
            return this;
        }

        /// <summary>
        /// Задает имя таблицы и возвращаемые поля.
        /// </summary>
        /// <param name="tablename">Имя таблицы</param>
        /// <param name="columns">Поля, которые нужно получить</param>
        /// <returns>Объект для создания строки запроса</returns>
        public Select From(string tablename, string columns)
        {
            _from = tablename;
            _columns = String.IsNullOrWhiteSpace(columns) ? SqlWildcard : columns;
            return this;
        }

        /// <summary>
        /// Задает список полей, которые будут возвращены.
        /// </summary>
        /// <param name="columns">Поля, которые нужно получить</param>
        /// <returns>Объект для создания строки запроса</returns>
        public Select Columns(string[] columns)
        {
            if (ReferenceEquals(columns, null) || columns.Length == 0)
                _columns = SqlWildcard;
            else
                _columns = ColumnsToLine(columns);
            return this;
        }

        /// <summary>
        /// Задает список полей, которые будут возвращены.
        /// </summary>
        /// <param name="columns">Поля, которые нужно получить</param>
        /// <returns>Объект для создания строки запроса</returns>
        public Select Columns(string columns)
        {
            _columns = String.IsNullOrWhiteSpace(columns) ? SqlWildcard : columns;
            return this;
        }

        /// <summary>
        /// Условия.
        /// </summary>
        /// <param name="where">Перечисление условий без WHERE</param>
        /// <returns>Объект для создания строки запроса</returns>
        public Select Where(string where)
        {
            _where = " " + where;
            return this;
        }

        /// <summary>
        /// Связывание таблиц.
        /// </summary>
        /// <param name="name">Имя таблицы с которой связываемся</param>
        /// <param name="conditional">Условия связывания</param>
        /// <param name="type">Тип связывания</param>
        /// <returns>Объект для создания строки запроса</returns>
        public Select Join(string name, string conditional, SqlJoinTypes type)
        {
            _collectionJoin.Add(new JoinObj(name, conditional, type));
            return this;
        }

        /// <summary>
        /// Группировка.
        /// </summary>
        /// <param name="group">Поле или поля через запятую для группировки</param>
        /// <returns>Объект для создания строки запроса</returns>
        public Select Group(string group)
        {
            _group = group;
            return this;
        }

        /// <summary>
        /// Вычисление табличного выражения.
        /// </summary>
        /// <param name="having">Условие</param>
        /// <returns>Объект для создания строки запроса</returns>
        public Select Having(string having)
        {
            _having = having;
            return this;
        }

        /// <summary>
        /// Порядок сортировки.
        /// </summary>
        /// <param name="order">Поле для группировки</param>
        /// <returns>Объект для создания строки запроса</returns>
        public Select Order(string order)
        {
            _order = order;
            return this;
        }

        /// <summary>
        /// Лимит на выборку.
        /// </summary>
        /// <param name="count">Количество записей</param>
        /// <returns>Объект для создания строки запроса</returns>
        public Select Limit(int count)
        {
            _limitCount = count;
            _limitOffset = 0;
            return this;
        }

        /// <summary>
        /// Лимит на выборку.
        /// </summary>
        /// <param name="count">Минимальное количество записей</param>
        /// <param name="offset">Максимальное количество записей</param>
        /// <returns>Объект для создания строки запроса</returns>
        public Select Limit(int count, int offset)
        {
            _limitCount = count;
            _limitOffset = offset;
            return this;
        }

        /// <summary>
        /// Конструктор запроса.
        /// </summary>
        /// <returns>Строка запроса к базе данных</returns>
        private string Constructor()
        {
            if (_from.Length == 0)
            {
                _lastError = "Не определено имя таблицы";
                return "";
            }

            var command = String.Format("SELECT {0} {1} {2} ", _columns, SqlFrom, _from);
            // собираем Join
            foreach (var join in _collectionJoin)
            {
                command += String.Format("{0} {1} ON {2} ", join.SqlJoinType, join.Name, join.Conditional);
            }

            // условие
            command += _where.Length > 0 ? SqlWhere + " " + _where : "";

            // группировка
            if (_group.Length > 0)
                command += " " + SqlGroupBy + " " + _group;

            // вычисление табличного выражения
            if (_having.Length > 0)
                command += " " + SqlHaving + " " + _having;

            // сортировка
            if (_order.Length > 0)
                command += " " + SqlOrderBy + " " + _order;

            // лимит
            if (_limitCount > 0)
                command += " " + SqlLimit + " " + _limitCount;

            if (_limitOffset > 0)
                command += "," + _limitOffset;

            return command;
        }

        #endregion

        /// <summary>
        /// Массив колонок в строку
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
    }
}