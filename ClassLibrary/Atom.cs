using System;

namespace ClassLibrary
{
    public class Atom
    {
        /// <summary>
        /// Наименование элемента
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Массив значений
        /// </summary>
        public double[] Value { get; set; }
        /// <summary>
        /// Количество совпадений
        /// </summary>
        public int CountMatch { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="data">Наименование элемента</param>
        public Atom(string[] data)
        {
            Name = data[0];
            try
            {
                Value = Array.ConvertAll(data[1].Split("/"), double.Parse);
            }
            catch
            {
                throw new Exception("Неверный формат.");
            }
        }

        /// <summary>
        /// Поиск в элемете значения приближенного к заданному
        /// </summary>
        /// <param name="elem"></param>
        /// <returns></returns>
        public int FindOf(double elem)
        {
            foreach (double el in Value)
                if (elem <= el + 5 && elem >= el - 5) return 1;
            return 0;
        }
    }
}
