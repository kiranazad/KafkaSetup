using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using Confluent.Kafka;

namespace KafkaConsumer
{
    class Program
    {
        static void Main()
        {
            var conf = new ConsumerConfig
            {
                GroupId = "test-group",
                BootstrapServers = "localhost:9092",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using var c = new ConsumerBuilder<Ignore, string>(conf).Build();
            c.Subscribe("kafka-test-kiran");

            var cts = new CancellationTokenSource();
            Console.CancelKeyPress += (_, e) =>
            {
                e.Cancel = true;
                cts.Cancel();
            };

            try
            {
                while (true)
                {
                    // Consume a message from the kafka-test-kiran topic.
                    var cr = c.Consume(cts.Token);

                    //Deserialize the JSON to c# Object
                    using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(cr.Value)))
                    {
                        //Deserialize the Class Object From JSON
                        DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(Quote));
                        Quote quote = (Quote)deserializer.ReadObject(ms);
                        Console.WriteLine("Find Part Information below");
                        Console.WriteLine("Part Id: " + quote.PartId);
                        Console.WriteLine("Part Number: " + quote.PartNumber);
                        Console.WriteLine("Quantity: " + quote.Quantity);
                        Console.WriteLine("RFQ_Id: " + quote.RfqId);
                        Console.WriteLine("Needed Date: " + quote.NeededDate);
                        Console.WriteLine($"Consumed message Part '{quote.PartNumber}' from topic {cr.Topic}");
                    }
                }
            }
            catch (OperationCanceledException)
            {
            }
            finally
            {
                c.Close();
            }
        }
    }
}
