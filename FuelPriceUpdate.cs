using DatabaseRecords.DataLayer;
using DatabaseRecords.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FuelPriceUpdate
{
    public class FuelPrice

    {
        private static string APIUrl = "http://api.eia.gov/series/?api_key=ec92aacd6947350dcb894062a4ad2d08&series_id=PET.EMD_EPD2D_PTE_NUS_DPG.W";

        public async Task UpdateFuelPrices(int ndays)
        {
            DateTime datesToSync = DateTime.Now.AddDays(-ndays);
            string lastNDate = datesToSync.ToString("yyyyMMdd");

            GetLatestSync date = new GetLatestSync();
            var lastDbDate = await date.GetLastDate();

            int lastDate = Math.Max(int.Parse(lastNDate), lastDbDate);

            using var client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(APIUrl);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                try
                {
                    var pricingData = JsonConvert.DeserializeObject<Root>(responseBody);
                    var totalDaysCount = pricingData.series.FirstOrDefault().data.Count();

                    for (int x =0; x < totalDaysCount; x++)
                    {
                        var dayData = pricingData.series.FirstOrDefault().data[x];
                        if (Int32.Parse(dayData[0].ToString()) >= lastDate)
                        {
                            var priceToUpdate = new PricingData()
                            {
                                Date = dayData[0],
                                Price = Decimal.Parse(dayData[1]),
                                LastUpdateDate = DateTime.Now
                            };
                            SaveRecords save = new SaveRecords();
                            await save.SavePricing(priceToUpdate);
                        }
                    }

                }
                catch (JsonReaderException)
                {
                    Console.WriteLine("Something went wrong.");
                }
            }
        }

    }
}