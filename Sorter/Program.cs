using System;
namespace Sorter
{
    class Program
    {
        static void Main()
        {
            // Получить имя из пути Path.GetFileName(path)
            // Путь где запускается exe
            string applicationPath = Directory.GetCurrentDirectory();
            string[] files = Directory.GetFiles(applicationPath);
            foreach (string file in files)
            {
                string fileName = Path.GetFileName(file);
                string[] fileSplitted = fileName.Split('.');
                string fileSuffix = fileSplitted[^1];
                string destinationDir = applicationPath + @"\" + fileSuffix.ToUpper() + @"\" +fileName;

                // Создание папок по рассширениям 
                if (!Directory.Exists(fileSuffix.ToUpper()))
                {
                    try
                    {
                        Directory.CreateDirectory(fileSuffix.ToUpper());
                    }
                    catch
                    {
                        Console.WriteLine("ошибка создания папки");
                    }
                }

            
                // Сортировка файлов по папкам
                if (fileName != Path.GetFileName(Environment.ProcessPath))
                {
                    File.Move(file, destinationDir);
                }
                else
                {
                    Console.WriteLine("Исполняемый файл");
                }

            }


        }
    }
}