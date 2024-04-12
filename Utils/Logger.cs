using System;
using System.IO;
using System.Web;
using System.Web.Configuration;

namespace TestProject.Utils
{
    public static class Logger
    {
        public static void LogException(Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("Logging exception...");

            // Получение пути к файлу лога из Web.config
            string logFilePath = WebConfigurationManager.AppSettings["LogFilePath"];
            // Преобразование относительного пути в абсолютный физический путь
            string logPath = HttpContext.Current.Server.MapPath(logFilePath);

            // Проверка существования папки для лога и создание при необходимости
            string logDirectory = Path.GetDirectoryName(logPath);
            if (!String.IsNullOrEmpty(logDirectory) && !Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }

            // Проверка существования файла лога и его создание, если необходимо
            if (!File.Exists(logPath))
            {
                // Создание файла лога. File.Create возвращает FileStream, поэтому его нужно закрыть после создания файла
                using (var stream = File.Create(logPath)) { }
            }

            // Создание сообщения для лога
            string message = $"Time: {DateTime.Now}\r\nException: {ex}\r\n-----------\r\n";

            // Запись в файл лога
            try
            {
                File.AppendAllText(logPath, message);
            }
            catch (Exception writeEx)
            {
                // Логирование исключения, возникшего при попытке записи в файл лога.
                System.Diagnostics.Debug.WriteLine("An error occurred while writing to the log file: " + writeEx.Message);
            }
        }
    }

}