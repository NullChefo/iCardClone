using System.Collections.Generic;
using iCard.Data.Entities;

namespace iCard.Data.Repositories
{
    public class TransactionHistoryRepository : BaseRepository<TransactionHistory>
    {
        public ICollection<TransactionHistory> GetByAccountId(int accountId)
        {
            ICollection<TransactionHistory> th = new List<TransactionHistory>();

            foreach (var vc in items)
            {

                if (accountId == vc.AccountId)
                {

                    th.Add(vc);
                }
            }

            return th;
        }
    }
}