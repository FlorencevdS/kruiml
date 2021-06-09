using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CalculateQuantitiesFunction
{
    public static class CalculateQuantities
    {
        [FunctionName("CalculateQuantities")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            QuantityModel data = JsonConvert.DeserializeObject<QuantityModel>(requestBody);

            List<double> resultQuantities = new List<double>();

            if (data.Quantities != null)
            {
                for (int i = 0; i < data.Quantities.Count; i++)
                {
                    resultQuantities.Add(data.Quantities[i] / data.OldNumberOfServes * data.NewNumberOfServes);
                }
            }

            return new OkObjectResult(resultQuantities);
        }
    }

    class QuantityModel
    {
        public int OldNumberOfServes { get; set; }
        public int NewNumberOfServes { get; set; }
        public List<double> Quantities { get; set; }
    }
}
