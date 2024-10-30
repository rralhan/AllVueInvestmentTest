using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AllVueInvestmentTest_BL.Models
{
    public class TransactionResult
    {
        public int RemainingShares { get; }
        public decimal CostBasisSoldShares { get; }
        public decimal CostBasisRemainingShares { get; }
        public decimal Profit { get; }

        public TransactionResult(int remainingShares, decimal costBasisSoldShares, decimal costBasisRemainingShares, decimal profit)
        {
            RemainingShares = remainingShares;
            CostBasisSoldShares = costBasisSoldShares;
            CostBasisRemainingShares = costBasisRemainingShares;
            Profit = profit;
        }

        // Static method to map from DAL DTO to BLL model
        public static TransactionResult FromDto(AllVueInvestmentTest_DAL.DTOs.TransactionResult dto)
        {
            return new TransactionResult(
                dto.RemainingShares,
                dto.CostBasisSoldShares,
                dto.CostBasisRemainingShares,
                dto.Profit
            );
        }

        // Optional: Convert back to DAL DTO if needed
        public AllVueInvestmentTest_DAL.DTOs.TransactionResult ToDto()
        {
            return new AllVueInvestmentTest_DAL.DTOs.TransactionResult()
            {
                CostBasisRemainingShares = this.CostBasisRemainingShares,
                RemainingShares = this.RemainingShares,
                CostBasisSoldShares = this.CostBasisSoldShares,
                Profit = this.Profit
            };
        }
    }
}


