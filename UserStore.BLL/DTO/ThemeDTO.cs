using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum_Marchuk.DAL.Entities;

namespace Forum_Marchuk.BLL.DTO
{
    public class ThemeDTO
    {
        
        public string Id { get; set; }
        [Display(Name ="Тема")]
        public string ThemeTitle { get; set; }
        [Display(Name = "Короткий опис")]
        public string ThemeDesc { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
