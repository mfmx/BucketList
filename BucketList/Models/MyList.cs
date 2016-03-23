using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BucketList.Models
{
    public class MyList
    {
        public MyList()
        {
            this.Checked = false;
        }

        public int ID { get; set; }

        public string Goals { get; set; }

        [DisplayName("Check")]
        public bool Checked { get; set; }

        [DisplayName("Date Accomplished")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? DateAccomplished { get; set; }

        [DisplayName("Date Created")]
        public string DateCreated { get; set; }

        public string UserId { get; set; }

    }
}