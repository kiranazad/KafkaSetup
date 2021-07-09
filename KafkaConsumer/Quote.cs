using System;

namespace KafkaConsumer
{
    public class Quote
    {
        public int RfqId { get; set; }
        public string PartId { get; set; }
        public string PartNumber { get; set; }
        public int Quantity { get; set; }
        public DateTime NeededDate { get; set; }
    }

}
