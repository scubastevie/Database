using System.IO;
using System.Net.Http;
using System;
using DatabaseRecords;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Reflection.Metadata;
using Microsoft.Extensions.Configuration;
using FuelPriceUpdate;

class Program
{

    private static IConfiguration _iconfiguration;
    static async Task Main(string[] args)
    {
        GetAppSettingsFile();
        FuelPrice fuel = new FuelPrice();
        await fuel.UpdateFuelPrices(ndays: 10);
    }
    static void GetAppSettingsFile()
    {
        var _iconfiguration = new ConfigurationBuilder()
    .SetBasePath(Path.Combine(AppContext.BaseDirectory))
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) // add more configuration files if there is a need
    .Build();
    }

}