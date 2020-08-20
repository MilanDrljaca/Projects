using DomainModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Services.Models
{
    public class CreateManagerRequest
    {
        [DisplayName("Id")]
        public int ID_Manager { get; set; }

        [Required(ErrorMessage = "Ime menadžera je obavezno!")]
        [DisplayName("Ime")]
        public string ManagerName { get; set; }
        [DisplayName("Aktivan")]
        public int Active { get; set; }
    }
}