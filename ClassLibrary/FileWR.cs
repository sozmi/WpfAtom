using System.Collections.Generic;
using System.IO;

namespace ClassLibrary
{
    /// <summary>
    /// Класс для работы с файлом
    /// </summary>
     public static class FileR
    {
        /// <summary>
        /// Путь к списку анкет
        /// </summary>
        private static readonly string path = Directory.GetCurrentDirectory() + "/data_list.txt";

        /// <summary>
        /// Читаем все анкеты из файла
        /// </summary>
        /// <returns></returns>
        public static List<Atom> Read()
        {
            List<Atom> data = new List<Atom>();
            if (!File.Exists(path))
                throw new System.Exception("Ошибка. Файл с данными отсутствует в директории.");
            using (StreamReader reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    try
                    {
                        data.Add(new Atom(reader.ReadLine().Split(";")));
                    }
                    catch
                    {
                        throw new System.Exception("Ошибка. Неверный формат файла.");
                    }                
                }
            }
            return data;
        }
    }
}
