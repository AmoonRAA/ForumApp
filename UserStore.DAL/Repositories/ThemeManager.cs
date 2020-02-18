using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum_Marchuk.DAL.EF;
using Forum_Marchuk.DAL.Entities;
using Forum_Marchuk.DAL.Interfaces;

namespace Forum_Marchuk.DAL.Repositories
{
    class ThemeManager  : Repository<Theme>,IThemeManager
    {
        public ThemeManager(ApplicationContext Context) : base(Context) { }
    }
}
