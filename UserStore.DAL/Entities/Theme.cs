using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum_Marchuk.DAL.Entities
{
    public class Theme
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string ThemeTitle { get; set; }
        public string ThemeDesc { get; set; }
        public ICollection<Question> Questions { get; set; }
        public Theme()
        {
            Questions = new List<Question>();
        }
          

    }
}
