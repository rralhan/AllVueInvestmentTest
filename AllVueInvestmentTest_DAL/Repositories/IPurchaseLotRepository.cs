using AllVueInvestmentTest_DAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllVueInvestmentTest_DAL.Interfaces
{
    public interface IPurchaseLotRepository
    {
        List<PurchaseLot> GetPurchaseLots();
        void InsertPurchaseLot(PurchaseLot lot);
    }

}
