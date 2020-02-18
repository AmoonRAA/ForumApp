using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Forum_Marchuk.DAL.Entities
{
   public class Question
    {
       
        public string Id { get; set; }

        public string QuestionTitlle { get; set; }
        public string QuestionDesc { get; set; }
        public DateTime DatePosted { get; set; }

        
        public string PostedUser { get; set; }
        
        public string ThemeId { get; set; }
        public virtual Theme Theme { get; set; }

        public string ClientId { get; set; }
        public virtual ClientProfile Client { get; set; }


    }
}
