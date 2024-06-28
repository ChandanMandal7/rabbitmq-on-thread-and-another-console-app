using System;
using System.Text;
using System.Text.Json;
using RabbitMQ.Client;

namespace rabbitmq.Service
{
    public class employeService : Iemployee
    {
        private readonly ConnectionFactory factory;

        public employeService()
        {
            factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest",
                VirtualHost = "/"
            };
        }

        public void PostEmploye<T>(T employeeModel)
        {
            try
            {
                using var connection = factory.CreateConnection();
                using var channel = connection.CreateModel();

                // Declare queue with consistent properties
                channel.QueueDeclare(
                    queue: "employee",
                    durable: true,
                    exclusive: false,
                    arguments: null
                );

                var jsonString = JsonSerializer.Serialize(employeeModel);
                var body = Encoding.UTF8.GetBytes(jsonString);

                // Publish message to the queue
                channel.BasicPublish(
                    exchange: string.Empty,
                    routingKey: "employee",
                    basicProperties: null,
                    body: body
                );

                Console.WriteLine(" [x] Sent {0}", jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(" [!] Exception: {0}", ex.Message);
            }
        }
    }
}
