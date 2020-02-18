using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum_Marchuk.DAL.Entities
{
    public class Reply
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string UserPosted { get; set; }
        public string ReplyText { get; set; }

        public string QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
