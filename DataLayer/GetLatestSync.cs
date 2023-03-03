using DatabaseRecords.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Linq;

namespace DatabaseRecords.DataLayer
{
    public class GetLatestSync
    {
        private string _connectionString = "Server=BROOKS\\SQLEXPRESS;Database=FuelPrices;Integrated Security=True";
        public async Task<int> GetLastDate()
        {

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var procedure = "SP_GET_LAST_PRICINGDATE";
                    var results = connection.QuerySingleOrDefault<int>(procedure, commandType: CommandType.StoredProcedure);
                    return results;
                }
            }
            catch (Exception ex)
            {
                return 0;
                throw ex;
            }


        }
    }
}
