using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BucketList.Models
{
    public class TopGoal
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Top 10 Goals")]
        public string Top10Goals { get; set; }
    }
}