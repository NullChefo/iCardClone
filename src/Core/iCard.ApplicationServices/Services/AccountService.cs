using iCard.ApplicationServices.Converters;
using iCard.ApplicationServices.DTOs;
using iCard.Data.Entities;
using iCard.Data.Repositories;

namespace iCard.ApplicationServices.Services
{
     public class AccountService
    {
        private AccountRepository repository;
        private UserService userService;
        private SettingsRepository settingsRepository;
        private PlanRepository planRepository;
        private VirtualCardRepository virtualCardRepository;
        private TransactionHistoryRepository transactionsRepository;

        public AccountService() 
        {
            repository = new AccountRepository();
            userService = new UserService();
            settingsRepository = new SettingsRepository();
            planRepository = new PlanRepository();
            virtualCardRepository = new VirtualCardRepository();
            transactionsRepository = new TransactionHistoryRepository();
        }

        public AccountDTO GetAccount(string username)
        {
            var acc = GetAccountForUser(username);
            if (acc == null) 
            {
                return null;
            }
            return AccountConverter.ToDTO(acc);
        }

        public AccountDTO AddAccountToUser(AccountDTO accountDTO, string username) 
        {
            var user = userService.GetEntityByUsername(username);
            user.Account = AccountConverter.ToEntity(accountDTO);
            userService.Save(user);

            return accountDTO;

        }


        public AccountDTO UpdateAccount(AccountDTO accountDTO, string username)
        {
            var user = userService.GetEntityByUsername(username);
            var updatedAcc = AccountConverter.ToEntity(accountDTO);
            if (user.AccountId == null) 
            {
                return null;
            }
            updatedAcc.Id = user.AccountId.Value;
            user.Account = updatedAcc;
            repository.Save(updatedAcc);
            return accountDTO;
        }

        public Account GetAccountForUser(string username)
        {
            var accountId = userService.GetEntityByUsername(username).AccountId;
             
            if (accountId == null) { return null; }
            var account = repository.GetById(accountId.Value);

            if (account.SettingsId > 0) 
            {
                account.Settings = settingsRepository.GetById(account.SettingsId);

            }

            if (account.PlanId > 0)
            {
                account.Plan = planRepository.GetById(account.PlanId);
            }

            var cards = virtualCardRepository.GetByAccountId(account.Id);

            if (cards != null && cards.Count > 0)
            {
                account.VirtualCards = cards;
            }
                       
            
            var th = transactionsRepository.GetByAccountId(account.Id);

            if (th != null && th.Count > 0)
            {
                account.Transactions = th;
            }


            return account;
        }

        public void Save(Account account)
        {

            repository.Save(account);
        }
    }
    
}