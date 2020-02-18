using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum_Marchuk.BLL.DTO;
using Forum_Marchuk.BLL.Infrastructure;

namespace Forum_Marchuk.BLL.Interfaces
{
    public interface IThemeService:IDisposable
    {
        Task<OperationDetails> CreateNew(ThemeDTO themeDTO);
        Task<OperationDetails> Edit(ThemeDTO themeDTO);
        Task<OperationDetails> Delete(ThemeDTO themeDTO);
        Task<ThemeDTO> FindThemeDtoById(string id);
        Task<ICollection<ThemeDTO>> GetAllThemes();
    }
}
