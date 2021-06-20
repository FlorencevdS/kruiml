using RabbitMQ.Client;
using Repository.Entities;
using System.Text;

namespace Logic
{
    public class EmitDeleteRecipeDirect
    {
        public void EmitDeleteRecipe(Recipe recipe)
        {
            var factory = new ConnectionFactory() { HostName = "rabbitmq" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "deleteRecipeQueue",
                                        type: "direct");

                var body = Encoding.UTF8.GetBytes(recipe.RecipeId.ToString());
                channel.BasicPublish(exchange: "deleteRecipeQueue",
                                     routingKey: "deleteRecipe",
                                     basicProperties: null,
                                     body: body);
            }
        }
    }
}
