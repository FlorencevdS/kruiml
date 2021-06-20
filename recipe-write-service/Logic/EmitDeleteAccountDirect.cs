using RabbitMQ.Client;
using System.Text;

namespace Logic
{
    public class EmitDeleteAccountDirect
    {
        public void EmitDeleteAccount(string id)
        {
            var factory = new ConnectionFactory() { HostName = "rabbitmq" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "deleteAccountQueue",
                                        type: "direct");

                var body = Encoding.UTF8.GetBytes(id);
                channel.BasicPublish(exchange: "deleteAccountQueue",
                                     routingKey: "deleteAccount",
                                     basicProperties: null,
                                     body: body);
            }
        }
    }
}
