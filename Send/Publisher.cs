using System;
using RabbitMQ.Client;
using System.Text;

namespace Send
{
    public class Publisher
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "DeverDeCasa",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

                    string message = "Estudar RabbitMQ!";
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "",
                                         routingKey: "DeverDeCasa",
                                         basicProperties: null,
                                         body: body);

                    Console.WriteLine("Mensagem enviada: "+ message);
                }

            Console.WriteLine("Presisone [Enter] para sair");
            Console.ReadLine();
                
            }
        }
    }
}
