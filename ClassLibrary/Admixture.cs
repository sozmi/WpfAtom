using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Класс для нахождения длин волн примеси
    /// </summary>
    public static class Admixture
    {
        /// <summary>
        /// Устанавливаем 2 массива длин волн
        /// </summary>
        /// <param name="value">Массив загрязненного водорода</param>
        static void SetValue(string value)
        {
            double[] temp;
            try
            {
                temp = Array.ConvertAll(value.Split("/"), double.Parse);
            }
            catch
            {
                throw new Exception("Неверный формат.");
            }
            mixture = ToNode(temp);
            H = ToNode(ClassLibrary.H.Wavelenght(temp));
        }
        /// <summary>
        /// Перевод массива double в Node
        /// </summary>
        /// <param name="temp">Массив double</param>
        /// <returns>Массив Node</returns>
        static Node[] ToNode(double[] temp)
        {
            Node[] result = new Node[temp.Length];
            for (int i = 0; i < temp.Length; i++)
                result[i] = new Node(temp[i]);
            return result;
        }

        /// <summary>
        /// Класс элемента массива
        /// </summary>
        class Node
        {
            public Node(double value)
            {
                Value = value;
            }

            public double Value { get; set; }
            public Node Suitable { get; set; }
        }
        /// <summary>
        /// Массив длин волн чистого водорода
        /// </summary>
        static Node[] H;
        /// <summary>
        /// Массив длин волн загрязненного
        /// </summary>
        static Node[] mixture;

        /// <summary>
        /// Сравниваем массивы длин волн загрязненного и истинного водорода
        /// </summary>
        /// <returns>Массив значений длин волн примеси</returns>
        static List<double> Compare()
        {
            foreach (Node h in H)
                foreach (Node m in mixture)
                {
                    //если длина волны водорода в пределах погрешности 
                    if (m.Value >= h.Value - 5 && m.Value <= h.Value + 5)
                    {
                        //если длины волн ещё не использовались
                        if (m.Suitable == null && h.Suitable == null)
                        {
                            Swap(h, m);
                        }
                    }
                }
            return SelectionAdmixture();
        }
        /// <summary>
        /// Обмен ссылками друг на друга
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        static void Swap(Node x, Node y)
        {
            x.Suitable = y;
            y.Suitable = x;
        }
        /// <summary>
        /// Выбор длин волн примеси
        /// </summary>
        /// <returns></returns>
        static List<double> SelectionAdmixture()
        {
            List<double> lst = new List<double>();
            foreach (Node el in mixture)
                if (el.Suitable == null) lst.Add(el.Value);
            return lst;
        }

        /// <summary>
        /// Получаем длины волн примеси
        /// </summary>
        /// <returns>Строку длин волн примеси</returns>
        static string GetString()
        {
            string res = "";
            List<double> lst = Compare();
            if (lst.Count == 0) return null;
            foreach (double el in lst)
                res += el + "/";
            return res.Trim('/');
        }

        /// <summary>
        /// Получение списка длин волн
        /// </summary>
        /// <param name="value">Строка со значениями длин волн загрязненного водорода</param>
        /// <returns></returns>
        public static string GetWavelenght(string value)
        {
            return (Comparison(value)) ?? "Не удаётся найти длины волн примеси.";
        }

        /// <summary>
        /// Установка значений длин волн, получение строки примесей
        /// </summary>
        /// <param name="value"></param>
        /// <returns>null-если примесей не найдено, иначе строка занчений</returns>
        static string Comparison(string value)
        {
            SetValue(value);
            return GetString();
        }
    }
}
