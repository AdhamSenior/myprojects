using System.Windows.Forms;

namespace System
{
    public static class ObjectExt
    {
        public static bool IsLatinLetter(this char ch)
        {
            return (ch >= 65 && ch <= 90) || (ch >= 97 && ch <= 122 || ch == (int)Keys.Back);
        }

        public static string ToSoatoId(this string src)
        {
            if (String.IsNullOrEmpty(src))
                return src;

            var ar = src.Split(':');
            if (ar.Length != 2)
                return src.ToSafeTrimmedString();

            return ar[0].ToSafeTrimmedString();
        }

        public static string ToSoatoNameUz(this string src)
        {
            if (String.IsNullOrEmpty(src))
                return src;

            var ar = src.Split(':');
            if (ar.Length != 2)
                return src.ToSafeTrimmedString();

            return ar[1].ToSafeTrimmedString();
        }

        /// <summary>
        /// Получить безопасное строковое представление объекта. Если значение равно null, то вернется пустая строка.
        /// </summary>
        /// <param name="obj">Объект</param>
        /// <param name="defValue">Значение по умолчанию</param>
        public static string ToSafeString(this object obj, string defValue)
        {
            if (obj.IsNullOrDBNull())
                return defValue;
            return obj.ToString();
        }

        /// <summary>
        /// Получить безопасное строковое представление объекта. Если значение равно null, то вернется пустая строка.
        /// </summary>
        /// <param name="obj">Объект</param>
        public static string ToSafeString(this object obj)
        {
            return obj.ToSafeString(String.Empty);
        }

        /// <summary>
        /// Безопасное получение форматированного ToString.
        /// </summary>
        public static string ToSafeString<T>(this T obj, string format, IFormatProvider formatProvider) where T : IFormattable
        {
            if (obj.IsNullOrDBNull())
                return String.Empty;
            return obj.ToString(format, formatProvider);
        }

        /// <summary>
        /// Безопасный Trim() к объекту.
        /// </summary>
        /// <param name="value">Объект</param>
        /// <returns>Строка</returns>
        public static string ToSafeTrimmedString(this object value)
        {
            var text = value.ToSafeString(String.Empty);
            if (text.Length == 0)
                return text;
            return text.Trim();
        }

        /// <summary>
        /// Получить реальный тип.
        /// </summary>
        /// <param name="type">Тип</param>
        public static Type GetRealType(Type type)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                return type.GetGenericArguments()[0];
            return type;
        }

        public static bool IsNumeric(this object obj)
        {
            return !ReferenceEquals(obj, null) && obj.GetType().IsNumeric();
        }

        /// <summary>
        /// Определяет является тип численным.
        /// </summary>
        public static bool IsNumeric(this Type type)
        {
            return !ReferenceEquals(type, null) && GetRealType(type).IsOneOf(new[]
			{
				typeof(byte),
				typeof(sbyte),
				typeof(short),
				typeof(int),
				typeof(long),
				typeof(uint),
				typeof(ushort),
				typeof(ulong),
				typeof(decimal),
				typeof(float),
				typeof(double)
			});
        }

        /// <summary>
        /// Конвертировать.
        /// </summary>
        /// <typeparam name="TTarget">Тип, в который нужно конвертировать</typeparam>
        /// <param name="value">Значение</param>
        /// <exception cref="T:System.NotSupportedException"></exception>
        public static TTarget ConvertTo<TTarget>(this object value) where TTarget : IConvertible
        {
            var rs = default(TTarget);
            if (value.IsNullOrDBNull())
                return rs;
            try
            {
                rs = (TTarget)(value.ConvertTo(typeof(TTarget)));
            }
            catch
            {
                return rs;
            }
            return rs;
        }

        /// <summary>
        /// Конвертировать.
        /// </summary>
        /// <param name="value">Значение</param>
        /// <param name="targetType">Тип</param>
        /// <exception cref="T:System.NotSupportedException"></exception>
        public static object ConvertTo(this object value, Type targetType)
        {
            CommonExt.CheckInvalidOperation(value, "value");
            if (targetType == typeof(decimal))
                return Convert.ToDecimal(value);
            if (targetType == typeof(int))
                return Convert.ToInt32(value);
            if (targetType == typeof(byte))
                return Convert.ToByte(value);
            if (targetType == typeof(sbyte))
                return Convert.ToSByte(value);
            if (targetType == typeof(short))
                return Convert.ToInt16(value);
            if (targetType == typeof(long))
                return Convert.ToInt64(value);
            if (targetType == typeof(uint))
                return Convert.ToUInt32(value);
            if (targetType == typeof(ushort))
                return Convert.ToUInt16(value);
            if (targetType == typeof(ulong))
                return Convert.ToUInt64(value);
            if (targetType == typeof(float))
                return Convert.ToSingle(value);
            if (targetType == typeof(bool))
                return Convert.ToBoolean(value);
            if (targetType == typeof(string))
                return Convert.ToString(value);
            if (targetType == typeof(DateTime))
                return Convert.ToDateTime(value);
            throw new NotSupportedException();
        }
    }
}