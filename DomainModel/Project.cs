using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DomainModel
{
    public class Project
    {
        [Key]
        public int ID_Project { get; set; }
        public string ProjectName { get; set; }
        [DisplayFormat(DataFormatString = "{MMM yyyy}")]
        public DateTime StartDate { get; set; }
        [DisplayFormat(DataFormatString = "{MMM yyyy}")]
        public DateTime? EndDate { get; set; }
        public string ManagerName { get; set; }
    }
}