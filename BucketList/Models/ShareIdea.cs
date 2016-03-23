using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace BucketList.Models
{
    public class ShareIdea
    {
        public int Id { get; set; }

        [DisplayName("Goal")]
        public string ShareIdeas { get; set; }

        public string Comments { get; set; }
    }
}