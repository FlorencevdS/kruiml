using RabbitMQ.Client;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class EmitNewRecipeDirect
    {
        public void EmitNewRecipe(Recipe recipe)
        {
            var factory = new ConnectionFactory() { HostName = "rabbitmq" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "newRecipeQueue",
                                        type: "direct");

                var body = Encoding.UTF8.GetBytes(recipe.RecipeId.ToString());
                channel.BasicPublish(exchange: "newRecipeQueue",
                                     routingKey: "newRecipe",
                                     basicProperties: null,
                                     body: body);
            }
        }
    }
}
