﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainModel
{
    public class Manager
    {
        [Key]
      
        public string ManagerName { get; set; }
        public int Active { get; set; }
        public List<Project> Projects { get; set; }


    }
}
