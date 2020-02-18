using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum_Marchuk.BLL.DTO;
using Forum_Marchuk.BLL.Infrastructure;
using Forum_Marchuk.BLL.Interfaces;
using Forum_Marchuk.DAL.Entities;
using Forum_Marchuk.DAL.Interfaces;

namespace Forum_Marchuk.BLL.Services
{
    class ThemeService : IThemeService
    {
        IUnitOfWork Database { get; set; }

        public ThemeService(IUnitOfWork UOW)
        {
            Database = UOW;
        }


        public async Task<OperationDetails> CreateNew(ThemeDTO themeDTO)
        {

            Theme theme = await Database.ThemeManager.GetById(themeDTO.Id);
            if (theme == null)
            {
                theme = new Theme
                {
                    ThemeTitle=themeDTO.ThemeTitle,
                    ThemeDesc=themeDTO.ThemeDesc,
                    Id = themeDTO.Id
                };
                await Database.ThemeManager.Create(theme);
                await Database.SaveAsync();
                return new OperationDetails(true, "Тему додано успішно!", "");
            }
            else
            {
                return new OperationDetails(false, "Сталася помилка", "");
            }

        }

        public async Task<OperationDetails> Delete(ThemeDTO themeDTO)
        {
            Theme theme = await Database.ThemeManager.GetById(themeDTO.Id);
            if (theme != null)
            {
                await Database.ThemeManager.Delete(theme);
                await Database.SaveAsync();
                return new OperationDetails(true, "Тема видалено успішно!", "");
            }
            else
            {
                return new OperationDetails(true, "Сталася помилка!", "");
            }
        }

        public async Task<OperationDetails> Edit(ThemeDTO themeDTO)
        {
            Theme theme = await Database.ThemeManager.GetById(themeDTO.Id);
            if (theme != null)
            {
                theme.ThemeTitle = themeDTO.ThemeTitle;
                theme.ThemeDesc = themeDTO.ThemeDesc;
                await Database.SaveAsync();
                return new OperationDetails(true, "Тема відредаговано успішно!", "");
            }
            else
            {
                return new OperationDetails(true, "Сталася помилка!", "");
            }
        }


        public async Task<ThemeDTO> FindThemeDtoById(string id)
        {
            Theme theme = await Database.ThemeManager.GetById(id);
            ThemeDTO dto = new ThemeDTO { Id = theme.Id, ThemeTitle = theme.ThemeTitle, ThemeDesc = theme.ThemeDesc };
            return dto;
        }

        public async Task<ICollection<ThemeDTO>> GetAllThemes()
        {
            IEnumerable<Theme> replies = await Database.ThemeManager.GetAll();

            ICollection<ThemeDTO> list = new List<ThemeDTO>();
            ThemeDTO dTO;
            foreach (Theme item in replies)
            {
                dTO = new ThemeDTO
                {
                    Id = item.Id,
                    ThemeTitle = item.ThemeTitle,
                    ThemeDesc = item.ThemeDesc
                    
                };
                list.Add(dTO);
            }


            return list;
        }


        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
