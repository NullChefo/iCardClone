using System;
using iCard.ApplicationServices.Converters;
using iCard.ApplicationServices.DTOs;
using iCard.Data.Repositories;

namespace iCard.ApplicationServices.Services
{
    public class SettingsService
    {
        private SettingsRepository settingsRepository;
        private AccountService accountService;

        public SettingsService()
        {
            settingsRepository = new SettingsRepository();
            accountService = new AccountService();
        }


        public SettingsDTO GetSettings(string username)
        {
            var acc = accountService.GetAccountForUser(username);
            if (acc == null)
            {
                throw new Exception("Such account doesn't exist!");
            }

            var settings = settingsRepository.GetById(acc.SettingsId);
            return SettingsConverter.ToDTO(settings);
        }


        public SettingsDTO UpdateSettings(string username, SettingsDTO dto)
        {
            var acc = accountService.GetAccountForUser(username);
            if (acc == null)
            {
                throw new Exception("Such account doesn't exist!");
            }

            var settings = settingsRepository.GetById(acc.SettingsId);
            var newSettings = SettingsConverter.ToEntity(dto);
            newSettings.Id = settings.Id;

            settingsRepository.Save(newSettings);

            return dto;
        }
    }
}