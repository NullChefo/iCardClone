using iCard.ApplicationServices.DTOs;
using iCard.Data.Entities;

namespace iCard.ApplicationServices.Converters
{
    class SettingsConverter
    {

        public static SettingsDTO ToDTO(Settings entity)
        {
            var dto = new SettingsDTO();
            dto.AppNotifications = entity.AppNotifications;
            dto.AppTheme = entity.AppTheme;
            dto.AutoUpdate = entity.AutoUpdate;
            dto.GamblingBlock = entity.GamblingBlock;
            dto.Name = entity.Name;
            dto.Id = entity.Id;
            return dto;
        }

        public static Settings ToEntity(SettingsDTO dto)
        {
            var entity = new Settings();
            entity.AppNotifications = dto.AppNotifications;
            entity.AppTheme = dto.AppTheme;
            entity.AutoUpdate = dto.AutoUpdate;
            entity.GamblingBlock = dto.GamblingBlock;
            entity.Name = dto.Name;

            return entity;
        }

    }
}