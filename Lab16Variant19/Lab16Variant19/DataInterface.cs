using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;

namespace Lab16Variant19
{
    public interface DataInterface
    {
        List<RawDataItem> GetRawData();
        List<SummaryDataItem> GetSummaryData();
        RawDataItem GetMinDiscountItem();
    }
}