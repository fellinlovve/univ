using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab16Variant19
{
    public class RawDataItem
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public double Price { get; set; }
        public double DiscountPercent { get; set; }

        public double PriceWithDiscount => Price * (1 - DiscountPercent / 100.0);
    }
}