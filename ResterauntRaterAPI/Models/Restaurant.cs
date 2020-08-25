using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ResterauntRaterAPI.Areas.HelpPage.Models
{
    public class Restaurant
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Rating { get; set; }
        public bool isRecommended
        {
            get
            {
                return (Rating > 3.5);
            }
        }

    }
}