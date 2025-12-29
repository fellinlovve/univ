using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab16Variant19
{
    public class DataStorage : DataInterface
    {
        private List<RawDataItem> rawData = new List<RawDataItem>();
        private List<SummaryDataItem> summaryData = new List<SummaryDataItem>();
        private char delimiter = ',';

        public bool InitData(string filePath)
        {
            try
            {
                rawData.Clear();
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    var parts = line.Split(delimiter);
                    if (parts.Length == 4)
                    {
                        rawData.Add(new RawDataItem
                        {
                            Name = parts[0].Trim(),
                            Group = parts[1].Trim(),
                            Price = double.Parse(parts[2].Trim()),
                            DiscountPercent = double.Parse(parts[3].Trim())
                        });
                    }
                }
                BuildSummary();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void BuildSummary()
        {
            summaryData = rawData
                .GroupBy(item => item.Group)
                .Select(g => new SummaryDataItem
                {
                    Group = g.Key,
                    AvgPriceWithDiscount = g.Average(item => item.PriceWithDiscount)
                })
                .ToList();
        }

        public List<RawDataItem> GetRawData() => rawData;
        public List<SummaryDataItem> GetSummaryData() => summaryData;

        public RawDataItem GetMinDiscountItem()
        {
            if (rawData.Count == 0) return null;
            return rawData.OrderBy(item => item.DiscountPercent).First();
        }
    }
}