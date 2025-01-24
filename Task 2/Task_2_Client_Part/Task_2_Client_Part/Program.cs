using System; // Подключаем пространство имен для базовых классов .NET, таких как Console.
using System.Net.Sockets; // Подключаем пространство имен для работы с сокетами и сетевыми соединениями.
using System.Text; // Подключаем пространство имен для работы с текстовыми кодировками, такими как UTF-8.

class MessageClient // Объявляем класс MessageClient, который будет реализовывать логику клиента.
{
    static void Main() // Определяем статический метод Main, который является точкой входа в программу.
    {
        TcpClient client = new TcpClient("127.0.0.1", 5000); // Создаем TcpClient и подключаемся к серверу по IP-адресу 127.0.0.1 и порту 5000.
        NetworkStream stream = client.GetStream(); // Получаем поток для чтения и записи данных.

        Console.WriteLine("Подключено к серверу. Введите сообщения для отправки (введите 'exit' для выхода):");

        while (true) // Бесконечный цикл для ввода сообщений пользователем.
        {
            string message = Console.ReadLine(); // Считываем сообщение от пользователя.
            if (message.ToLower() == "exit") // Если пользователь ввел 'exit', выходим из цикла.
                break;

            byte[] data = Encoding.UTF8.GetBytes(message); // Преобразуем сообщение в массив байтов.
            stream.Write(data, 0, data.Length); // Отправляем сообщение на сервер.

            byte[] buffer = new byte[1024]; // Создаем буфер для получения данных от сервера.
            int bytesRead = stream.Read(buffer, 0, buffer.Length); // Читаем ответ от сервера.
            string response = Encoding.UTF8.GetString(buffer, 0, bytesRead); // Преобразуем ответ в строку.

            Console.WriteLine($"Ответ от сервера:\n{response}"); // Выводим ответ от сервера.
        }

        client.Close(); // Закрываем соединение с сервером.
        Console.WriteLine("Отключено от сервера."); // Выводим сообщение об отключении.
    }
}
