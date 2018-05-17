using System.Text;

namespace System.Collections.Generic
{
    public static class CollectionExt
    {
        /// <summary>
        /// Получить строковое представление для каждого элемента в последовательности и соединить в общую строку.
        /// </summary>
        /// <param name="src">Исходная последовательность элементов</param>
        /// <param name="spliter">Строка, которая вставлятся между каждыми двумя элементами</param>
        public static string ToString(this IEnumerable src, string spliter)
        {
            var array = src as string[];
            if (!ReferenceEquals(array, null))
                return String.Join(spliter, array, 0, array.Length);

            var sb = new StringBuilder(128);
            foreach (object current in src)
            {
                var text = current.ToSafeString(String.Empty);
                if (text.Length != 0)
                {
                    if (sb.Length != 0)
                        sb.Append(spliter);
                    sb.Append(text);
                }
            }
            return sb.ToString();
        }
    }
}