using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary
{
    /// <summary>
    /// Класс рассчитывающий длины волн водорода по формулам
    /// </summary>
    public static class H
    {
        /// <summary>
        /// Постоянная Ридберга
        /// </summary>
        static readonly double R = 1.1 * Math.Pow(10, 7);
        /// <summary>
        /// Константа
        /// </summary>
        static readonly double L = 4 / R;
        /// <summary>
        /// Начальный номер линии
        /// </summary>
        const double K = 3;

        /// <summary>
        /// Получаем массив истинных значений длин волн
        /// видимой серии спектра излучения атома водорода. 
        /// </summary>
        /// <param name="value">Массив длинн волн "загрязненного" водорода</param>
        /// <returns>массив истинных значений длин волн</returns>
        public static double[] Wavelenght(double[] value)
        { 
            return Calculate(value.Min());
        }
        /// <summary>
        /// Вычисление истинных длин волн
        /// </summary>
        /// <param name="min">Минимальное значение длины волны загрязненного водорода</param>
        /// <returns>Массив истинных значений длин волн</returns>
        private static double[] Calculate(double min)
        {
            double wavelenght;
            List<double> lst = new List<double>();
            double k = K;
            do
            {
                wavelenght = (L / (1 - 4 / (k * k))) * Math.Pow(10, 9);
                lst.Add(wavelenght);
                k++;
            } while (min <= wavelenght);
            return lst.ToArray();
        }
    }
}
