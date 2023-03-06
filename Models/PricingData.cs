using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DatabaseRecords.Models
{
    public class PricingData
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public String PriceDate { get; set; }
        public decimal Price { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
