using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Confluent.Kafka;

namespace KafkaProducer
{
    class Program
    {
        public static async Task Main()
        {
            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:9092"
            };

            // Create a producer that can be used to send messages to kafka that have no key and a value of type string 
            using var p = new ProducerBuilder<Null, string>(config).Build();
            Console.WriteLine($"Press any key to submit the part.");
            Console.ReadLine();
            var quote = new Quote
            {
                NeededDate = DateTime.Now,
                PartId = "1234321.DB1",
                PartNumber = "PN-1234",
                Quantity = 10,
                RfqId = 1
            };
            //Serialize the Class Object to JSON
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Quote));
            MemoryStream msObj = new MemoryStream();
            js.WriteObject(msObj, quote);
            msObj.Position = 0;
            StreamReader sr = new StreamReader(msObj);
            string json = sr.ReadToEnd();

            var message = new Message<Null, string>
            {
                Value = json
            };
            string topic = "kafka-test-kiran";
            Console.WriteLine($"Sending Part {quote.PartNumber} to topic {topic}");
            // Send the message to our test topic in Kafka
            var dr = await p.ProduceAsync(topic, message);
            Console.WriteLine($"Delivered Part {quote.PartNumber} to topic {dr.Topic}");
            Console.ReadLine();
        }
    }
}
