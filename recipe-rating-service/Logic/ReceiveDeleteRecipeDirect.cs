using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Logic
{
    public class ReceiveDeleteRecipeDirect : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public ReceiveDeleteRecipeDirect(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var factory = new ConnectionFactory() { HostName = "rabbitmq" };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            channel.ExchangeDeclare(exchange: "deleteRecipeQueue",
                                    type: "direct");
            var queueName = channel.QueueDeclare().QueueName;

            channel.QueueBind(queue: queueName,
                              exchange: "deleteRecipeQueue",
                              routingKey: "deleteRecipe");

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var routingKey = ea.RoutingKey;

                using var scope = _serviceScopeFactory.CreateScope();
                IRatingLogic ratingLogic = scope.ServiceProvider.GetRequiredService<RatingLogic>();
                ratingLogic.DeleteRecipeId(Int32.Parse(message.ToString()));

            };
            channel.BasicConsume(queue: queueName,
                                 autoAck: true,
                                 consumer: consumer);

            return Task.CompletedTask;
        }
    }
}
