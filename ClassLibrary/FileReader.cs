using System.Collections.Generic;
using System.IO;

namespace ClassLibrary
{
    /// <summary>
    /// Класс, предназначенный для чтения файла
    /// </summary>
    public static class FileReader
    {
        /// <summary>
        /// Путь к списку характеристик элементов
        /// </summary>
        private static readonly string path = Directory.GetCurrentDirectory() + "/data_list.txt";

        /// <summary>
        /// Читаем все характеристики элементов из файла
        /// </summary>
        /// <returns>Список атомов с их описанием</returns>
        public static List<Atom> Read()
        {
            List<Atom> data = new List<Atom>();
            if (!File.Exists(path))
                throw new System.Exception("Файл с данными не найден");
            using (StreamReader reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    data.Add(new Atom(reader.ReadLine().Split(";")));
                }
            }
            return data;
        }
    }
}
