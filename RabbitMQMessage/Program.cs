using RabbitMQ.Client;
using System;
using System.Text;

namespace RabbitMQMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            SignUp();
            Console.ReadLine();

        }
        public static void SignUp()
        {
            Console.Write("Kullanıcı adı giriniz :");
            var factory = new ConnectionFactory()
            {

                HostName = "localhost",
            };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "hello", durable: true, exclusive: false, autoDelete: false, arguments: null);
                    var body = Encoding.UTF8.GetBytes(Console.ReadLine());
                    channel.BasicPublish(exchange: "", routingKey: "hello", basicProperties: null, body: body);


                }
            }
            SignUp();
        }
    }

}
