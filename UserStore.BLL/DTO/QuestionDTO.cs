using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum_Marchuk.DAL.Entities;

namespace Forum_Marchuk.BLL.DTO
{
    public class QuestionDTO
    {
        public string Id { get; set; }

        public string QuestionTitlle { get; set; }
        public string QuestionDesc { get; set; }
        public DateTime DatePosted { get; set; }
        public string PostedUser { get; set; }

        public string ThemeId { get; set; }
        public string UserId { get; set; }

    }
}
