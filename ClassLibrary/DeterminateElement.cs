using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary
{
    /// <summary>
    /// Класс для выводов результата
    /// </summary>
    public static class DeterminateElement
    {
        /// <summary>
        /// Класс узла для вывода в DataGrid
        /// </summary>
        public class Element
        {
            /// <summary>
            /// Наименование элемента
            /// </summary>
            public string Элемент { get; set; }
            /// <summary>
            /// Количество совпадений с длинами волн некоторых элементов
            /// </summary>
            public string Количество_совпадений { get; set; }

            /// <summary>
            /// Конструктор, присваивающий название и количество совпадений для элемента
            /// </summary>
            /// <param name="name">Наименование</param>
            /// <param name="count">Количество совпадений</param>
            public Element(string name, string count)
            {
                Элемент = name;
                Количество_совпадений = count;
            }
        }

        /// <summary>
        /// Получение списка элементов, имеющих хотя бы одно совпадение длинн волн с примесью 
        /// </summary>
        /// <param name="value">Строка длин волн примесей</param>
        /// <returns>Список элементов отсортированный по убыванию</returns>
        public static List<Element> GetResult(string value)
        {
            return Compare(value).OrderByDescending(x => x.Количество_совпадений).ToList();
        }

        /// <summary>
        /// Сравнение длин волн элементов с длинами волн примеси
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Список элементов</returns>
        private static List<Element> Compare(string value)
        {
            //создаём элемент примеси
            Atom a = new Atom(new string[] { "Current", value });
            //читаем файл с остальными элементами
            List<Atom> lst = FileReader.Read();

            foreach (Atom el in lst)
            {
                int temp = 0;
                foreach (double cur in a.Value)
                {
                    temp += el.FindOf(cur);
                }
                el.CountMatch = temp;
            }
            return GetAdmixture(lst);
        }

        /// <summary>
        /// Переписываем элементы, где есть хотя бы 1 совпадение в новый список 
        /// </summary>
        /// <param name="lst"></param>
        /// <returns>Список элементов</returns>
        private static List<Element> GetAdmixture(List<Atom> lst)
        {
            List<Element> elem_admixture = new List<Element>();
            foreach (Atom el in lst)
            {
                if (el.CountMatch != 0)
                    elem_admixture.Add(new Element(el.Name, el.CountMatch.ToString()));
            }
            return elem_admixture;
        }
    }
}
