﻿using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Services.Models
{
    public class CreateProjectRequest
    {
        [Required(ErrorMessage = "Ime projekta je obavezno!")]
        public string ProjectName { get; set; }
        public int ProjectId { get; set; }
        [DisplayFormat(DataFormatString = "{MMM yyyy}")]
        public DateTime StartDate { get; set; }
        [DisplayFormat(DataFormatString = "{MMM yyyy}")]
        public DateTime? EndDate { get; set; }
        public string ManagerName { get; set; }
    }
}