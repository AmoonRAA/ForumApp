using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Forum_Marchuk.Models
{
    public class ThemeModel
    {
        [Required]
        public string ThemeTitle { get; set; }
        [Required]
        public string ThemeDesc { get; set; }
        [Required]
        public string Id { get; set; }
    }
}