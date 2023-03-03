using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using DatabaseRecords.Models;
using System.Threading.Tasks;
using Dapper;

namespace DatabaseRecords.DataLayer
{
    public class SaveRecords
    {
        private string _connectionString = "Server=BROOKS\\SQLEXPRESS;Database=Pricing;Integrated Security=True";
        public async Task SavePricing(PricingData data)
        {
            try
            {
                using (IDbConnection con = new SqlConnection(_connectionString))
                {
                    string insertQuery = @"INSERT INTO [dbo].[pricingdate]([pricing_date], [price], [last_update_Date]) VALUES (@pricing_date, @price, @last_update_Date)";

                    var result = con.Execute(insertQuery, new
                    {
                        data.Date,
                        data.Price,
                        DateTime.Now
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
