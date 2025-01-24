using System;
using System.Net; // Пространство имен для работы с сетевыми адресами
using System.Net.Sockets; // Пространство имен для работы с сокетами
using System.Text; // Пространство имен для работы с кодировками строк
using System.Threading; // Пространство имен для работы с потоками

class TimeServer
{
    static void Main()
    {
        // Указываем порт, на котором будет работать сервер
        int port = 11000;
        // Создаем UDP-сокет для отправки данных
        using (UdpClient udpServer = new UdpClient(port))
        {
            Console.WriteLine($"Сервер запущен на порту {port}. Ожидание клиентов...");

            while (true) // Бесконечный цикл для постоянной работы сервера
            {
                // Получаем текущее время
                string currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                // Преобразуем строку времени в байтовый массив
                byte[] data = Encoding.UTF8.GetBytes(currentTime);

                // Отправляем данные всем клиентам в локальной сети
                udpServer.Send(data, data.Length, "255.255.255.255", port);
                // Выводим в консоль текущее время, которое отправляем
                Console.WriteLine($"Отправлено время: {currentTime}");

                // Ждем 1 секунду перед следующей отправкой
                Thread.Sleep(1000);
            }
        }
    }
}