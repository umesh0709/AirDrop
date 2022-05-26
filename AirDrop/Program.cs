using AirDropML.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AirDrop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            AllPredictedValues();
        }


        static void AllPredictedValues()
        {
            Dictionary<string, List<float>> dict = new Dictionary<string, List<float>>();

            using (var reader = new StreamReader(@"C:\Users\umesh\source\repos\PricePredication\PricePredication\Data\BitcoinTestData.csv")) {
                var line = reader.ReadLine();


                while (!reader.EndOfStream) {
                    List<float> list = new List<float>();
                    line = reader.ReadLine();
                    var values = line.Split(',');

                    foreach (var v in values) {
                        bool success = float.TryParse(v, out float n);
                        if (success) {
                            list.Add(n);
                        }
                    }

                    dict.Add(values[0], list);

                }
            }

            Dictionary<string, float> predictedValues = new Dictionary<string, float>();



            foreach (var k in dict.Keys) {
                ModelInput sample = new ModelInput() {
                    Open = dict[k][1],
                    High = dict[k][2],
                    Low = dict[k][3],

                };

                var prediction = ConsumeModel.Predict(sample);
                predictedValues.Add(k, prediction.Score);
            }

            List<List<float>> res = new List<List<float>>();

            foreach (var k in dict.Keys) {
                List<float> tmp = new List<float>();
                tmp.Add(dict[k][0]);
                tmp.Add(predictedValues[k]);
                res.Add(tmp);
            }

            /*foreach (var k in dict.Keys)
            {
                Console.WriteLine("Original {0} : Predicted {1}", dict[k][0], predictedValues[k]);
            }*/
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
