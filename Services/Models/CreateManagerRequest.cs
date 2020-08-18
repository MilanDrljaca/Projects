using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Services.Models
{
   public class CreateManagerRequest
    {
        [DisplayName("Manager")]
        public string ManagerName { get; set; }
        public int Active { get; set; }
    }
}
