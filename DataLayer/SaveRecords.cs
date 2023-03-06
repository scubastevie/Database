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
        private string _connectionString = "Server=BROOKS\\SQLEXPRESS;Database=FuelPrices;Integrated Security=True";
        public async Task SavePricing(PricingData data)
        {
            try
            {
                using (IDbConnection con = new SqlConnection(_connectionString))
                {
                    con.Execute("SP_Insert_Price", data, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
