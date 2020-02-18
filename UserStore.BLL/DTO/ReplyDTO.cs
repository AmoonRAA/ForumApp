using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum_Marchuk.BLL.DTO
{
    public class ReplyDTO
    {
        public string Id { get; set; }
        public string UserPosted { get; set; }
        public string ReplyText { get; set; }

        public string QuestionId { get; set; }
    }
}
