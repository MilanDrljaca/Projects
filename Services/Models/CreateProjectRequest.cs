using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Services.Models
{
    public class CreateProjectRequest
    {
        [Required(ErrorMessage = "Ime projekta je obavezno!")]
        [DisplayName("Name")]
        public string ProjectName { get; set; }
        [DisplayName("Id")]
        public int ProjectId { get; set; }
        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }
        [DisplayName("End Date")]
        public DateTime? EndDate { get; set; }
        [DisplayName("Manager")]
        public string ManagerName { get; set; }
    }
}

