using System;
using iCard.ApplicationServices.Converters;
using iCard.ApplicationServices.DTOs;
using iCard.Data.Repositories;

namespace iCard.ApplicationServices.Services
{
       public class PlanService
    {
        private PlanRepository planRepository;
        private AccountService accountService;

        public PlanService()
        {
            planRepository = new PlanRepository();
            accountService = new AccountService();
        }


        public PlanDTO GetPlanDetails(string username)
        {
            var acc = accountService.GetAccountForUser(username);
            if (acc == null)
            {
                throw new Exception("such account doesn't exist");
            }
            var plan = planRepository.GetById(acc.PlanId);
            return PlanConverter.ToDTO(plan);
        }

        public PlanDTO UpdatePlan(string username, PlanDTO dto)
        {
            var acc = accountService.GetAccountForUser(username);
            if (acc == null)
            {
                throw new Exception("such account doesn't exist");
            }
            var plan = planRepository.GetById(acc.PlanId);
            var newPlan = PlanConverter.ToEntity(dto);

            newPlan.Id = plan.Id;
            planRepository.Save(newPlan);
            return dto;
        }

        public void ExecuteTransaction(int planId)
        {
            var plan = planRepository.GetById(planId);
            plan.CardTransactions += 1;
            planRepository.Save(plan);

        }
                
        public void RechargeTransactions(string username)
        {
            var acc = accountService.GetAccountForUser(username);
            if (acc == null) 
            {
                throw new Exception("such account doesn't exist");
            }
            var plan = planRepository.GetById(acc.PlanId);
            plan.CardTransactions += 1;
            planRepository.Save(plan);

        }

        public bool CanExchange(int planId, double sum, bool fromCard)
        {
            var plan = planRepository.GetById(planId);
            if (plan.MaxExchange < sum) 
            {
                return false;
            }

            if (fromCard && plan.CardTransactions <= 0) {
                return false;
            }
            return true;
        }
    }

}