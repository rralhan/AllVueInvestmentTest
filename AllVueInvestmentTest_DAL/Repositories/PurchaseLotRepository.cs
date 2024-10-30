
using AllVueInvestmentTest_DAL.DTOs;
using System.Data.SqlClient;
using AllVueInvestmentTest_DAL.Interfaces;

namespace AllVueInvestmentTest_DAL.Repositories
{

    public class PurchaseLotRepository : IPurchaseLotRepository
    {
        //Get this from the config connectionString section
        private static string _connectionString = "Demo_ConnStr";

        public List<PurchaseLot> GetPurchaseLots()
        {
            var purchaseLots = new List<PurchaseLot>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT Shares, CostPerShare, PurchaseDate FROM PurchaseLots ORDER BY PurchaseDate";
                using (var command = new SqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        purchaseLots.Add(new PurchaseLot(
                            reader.GetInt32(0),
                            reader.GetDecimal(1),
                            reader.GetDateTime(2)
                        ));
                    }
                }
            }

            return purchaseLots;
        }

        public void InsertPurchaseLot(PurchaseLot lot)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "INSERT INTO PurchaseLots (Shares, CostPerShare, PurchaseDate) VALUES (@Shares, @CostPerShare, @PurchaseDate)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Shares", lot.Shares);
                    command.Parameters.AddWithValue("@CostPerShare", lot.CostPerShare);
                    command.Parameters.AddWithValue("@PurchaseDate", lot.PurchaseDate);
                    command.ExecuteNonQuery();
                }
            }
        }
    }

}