using System;
using System.Collections.Generic; // Пространство имен для работы с коллекциями, такими как List.
using System.Net; // Пространство имен для работы с сетевыми адресами и протоколами.
using System.Net.Sockets; // Пространство имен для работы с сокетами и сетевыми соединениями.
using System.Text; // Пространство имен для работы с текстовыми кодировками, такими как UTF-8.

class MessageServer // Объявляем класс MessageServer, который будет реализовывать логику сервера.
{
    private static List<string> messages = new List<string>(); // Список для хранения сообщений.

    static void Main() // Определяем статический метод Main, который является точкой входа в программу.
    {
        TcpListener server = new TcpListener(IPAddress.Any, 5000); // Создаем TcpListener, который будет слушать на любом IP-адресе и порту 5000.
        server.Start(); // Запускаем сервер.

        Console.WriteLine("Сервер запущен. Ожидание подключения клиентов...");

        while (true) // Бесконечный цикл для постоянного ожидания подключения клиентов.
        {
            TcpClient client = server.AcceptTcpClient(); // Ожидаем подключения клиента и создаем TcpClient для этого соединения.
            Console.WriteLine("Клиент подключен."); // Выводим сообщение о подключении клиента.

            // Обрабатываем клиента в отдельном потоке, чтобы сервер мог продолжать принимать другие подключения.
            System.Threading.Thread clientThread = new System.Threading.Thread(() => HandleClient(client));
            clientThread.Start(); // Запускаем поток для обработки клиента.
        }
    }

    private static void HandleClient(TcpClient client) // Метод для обработки клиента.
    {
        NetworkStream stream = client.GetStream(); // Получаем поток для чтения и записи данных.
        byte[] buffer = new byte[1024]; // Создаем буфер для хранения полученных данных.

        while (true) // Бесконечный цикл для обработки сообщений от клиента.
        {
            int bytesRead = stream.Read(buffer, 0, buffer.Length); // Читаем данные из потока.
            if (bytesRead == 0) // Если клиент закрыл соединение, выходим из цикла.
                break;

            string message = Encoding.UTF8.GetString(buffer, 0, bytesRead); // Преобразуем полученные байты в строку.
            Console.WriteLine($"Получено сообщение: {message}"); // Выводим полученное сообщение в консоль.

            messages.Add(message); // Добавляем сообщение в список сообщений.

            // Отправляем все сообщения обратно клиенту.
            byte[] response = Encoding.UTF8.GetBytes(string.Join("\n", messages)); // Преобразуем список сообщений в строку.
            stream.Write(response, 0, response.Length); // Отправляем сообщения клиенту.
        }

        client.Close(); // Закрываем соединение с клиентом.
        Console.WriteLine("Клиент отключен."); // Выводим сообщение об отключении клиента.
    }
}