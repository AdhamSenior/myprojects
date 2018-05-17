using System.Globalization;

namespace System
{
    public static class CommonExt
    {
        /// <summary>
        /// Определяет, является ли значение null или DBNull.
        /// </summary>
        /// <param name="value">Значение</param>
        public static bool IsNullOrDBNull(this object value)
        {
            return ReferenceEquals(value, null) || value is DBNull;
        }

        /// <summary>
        /// Определяет, является ли значение объекта одним из перечисленных.
        /// </summary>
        /// <typeparam name="T">Тип объекта</typeparam>
        /// <param name="obj">Объект</param>
        /// <param name="values">Значения</param>
        public static bool IsOneOf<T>(this T obj, params T[] values)
        {
            foreach (T t in values)
                if (t.Equals(obj))
                    return true;
            return false;
        }

        /// <summary>
        /// Проверить, не является ли аргумент null.
        /// </summary>
        /// <typeparam name="T">Тип аргумента</typeparam>
        /// <param name="arg">Аргумент</param>
        /// <param name="objectName">Наименование аргумента</param>
        public static void CheckInvalidOperation<T>(T arg, string objectName) where T : class
        {
            if (arg.IsNullOrDBNull())
                throw new InvalidOperationException(objectName + " is null.");
        }

        public static int ToInt32(this string txt)
        {
            int rs;
            var success = int.TryParse(txt, out rs);
            if (success)
                return rs;
            return -1;
        }

        public static bool ToBool(this string txt)
        {
            bool rs;
            var success = bool.TryParse(txt, out rs);
            if (success)
                return rs;
            return false;
        }

        public static DateTime ToDateTime(this string txt)
        {
            DateTime rs;
            var success = DateTime.TryParseExact(txt, "dd-MM-yyyy", null, DateTimeStyles.None, out rs);
            if (success)
                return rs;

            success = DateTime.TryParse(txt, out rs);
            if (success)
                return rs;

            return DateTime.MinValue;
        }

        public static DateTime ToDateTimeExact(this string txt, string format)
        {
            if (String.IsNullOrWhiteSpace(format))
                format = "yyyyMMddHHmmss";

            DateTime rs;
            var success = DateTime.TryParseExact(txt, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out rs);
            if (success)
                return rs;
            return DateTime.MinValue;
        }
    }
}