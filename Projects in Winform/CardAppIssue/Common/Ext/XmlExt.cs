using System;
using System.Xml.Linq;

namespace Common
{
    public static class XmlExtension
    {
        /// <summary>
        /// Получить значение XAttribute в виде строки.
        /// </summary>
        /// <param name="att">Объект XAttribute</param>
        /// <returns>Значение XAttribute</returns>
        public static string ToText(this XAttribute att)
        {
            if (ReferenceEquals(att, null))
                return String.Empty;

            return att.Value.ToSafeTrimmedString();
        }
        /// <summary>
        /// Получить значение XAttribute в виде Int32.
        /// </summary>
        /// <param name="att">Объект XAttribute</param>
        /// <returns>Значение XAttribute</returns>
        public static int ToInt32(this XAttribute att)
        {
            var txt = att.ToText();
            return txt.ToInt32();
        }
        /// <summary>
        /// Получить значение XAttribute в виде bool.
        /// </summary>
        /// <param name="att">Объект XAttribute</param>
        /// <returns>Значение XAttribute</returns>
        public static bool ToBool(this XAttribute att)
        {
            var txt = att.ToText();
            return txt.ToBool();
        }
        /// <summary>
        /// Получить значение XAttribute в виде DateTime.
        /// </summary>
        /// <param name="att">Объект XAttribute</param>
        /// <returns>Значение XAttribute</returns>
        public static DateTime ToDateTime(this XAttribute att)
        {
            var txt = att.ToText();
            return txt.ToDateTime();
        }
        /// <summary>
        /// Получить значение XElement в виде строки.
        /// </summary>
        /// <param name="el">Объект XElement</param>
        /// <returns>Значение XElement</returns>
        public static string ToText(this XElement el)
        {
            if (ReferenceEquals(el, null))
                return String.Empty;

            return el.Value.ToSafeTrimmedString();
        }
        /// <summary>
        /// Получить значение XElement в виде Int32.
        /// </summary>
        /// <param name="el">Объект XElement</param>
        /// <returns>Значение XElement</returns>
        public static int ToInt32(this XElement el)
        {
            var txt = el.ToText();
            return txt.ToInt32();
        }
        /// <summary>
        /// Получить значение XElement в виде Bool.
        /// </summary>
        /// <param name="el">Объект XElement</param>
        /// <returns>Значение XElement</returns>
        public static bool ToBool(this XElement el)
        {
            var txt = el.ToText();
            return txt.ToBool();
        }
        /// <summary>
        /// Получить значение XElement в виде DateTime.
        /// </summary>
        /// <param name="el">Объект XElement</param>
        /// <returns>Значение XElement</returns>
        public static DateTime ToDateTime(this XElement el)
        {
            var txt = el.ToText();
            return txt.ToDateTime();
        }
        /// <summary>
        /// Получить значение XElement в виде DateTime.
        /// </summary>
        /// <param name="el">Объект XElement</param>
        /// <param name="format">Формат даты</param>
        /// <returns>Значение XElement</returns>
        public static DateTime ToDateTimeExact(this XElement el, string format)
        {
            var txt = el.ToText();
            return txt.ToDateTimeExact(format);
        }
    }
}