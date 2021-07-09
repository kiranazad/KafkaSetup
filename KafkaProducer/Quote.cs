using System;
using System.Collections.Generic;
using System.Text;

namespace KafkaProducer
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
