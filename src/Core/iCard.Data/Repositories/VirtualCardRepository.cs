using System.Collections.Generic;
using iCard.Data.Entities;

namespace iCard.Data.Repositories
{
    public class VirtualCardRepository: BaseRepository<VirtualCard>
    {
        public ICollection<VirtualCard> GetByAccountId(int accountId) 
        {
            ICollection<VirtualCard> cards = new List<VirtualCard>();

            foreach (var vc in items) 
            {

                if (accountId == vc.AccountId)
                {

                    cards.Add(vc);
                }
            }

            return cards;
        }
        
    
        public VirtualCard GetByAccountIdAndName(int accountId, string name) 
        {

            foreach (var vc in items) 
            {

                if (accountId == vc.AccountId && name.Equals(vc.Name))
                {

                    return vc;
                }
            }

            return null;
        }
    
    
        public VirtualCard GetByAccountIdAndCardNumber(int accountId, string cardNumber) 
        {

            foreach (var vc in items) 
            {

                if (accountId == vc.AccountId && cardNumber.Equals(vc.CardNumber))
                {

                    return vc;
                }
            }

            return null;
        }
    }
}