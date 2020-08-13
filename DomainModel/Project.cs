using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DomainModel
{
    public class Project
    {
        [Key]
        [DisplayName("Id")]
        public int ID_Project { get; set; }
        [DisplayName("Naziv")]
        public string ProjectName { get; set; }
        [DisplayName("Datum početka")]
        public DateTime StartDate { get; set; }
        [DisplayName("Datum završetka")]
        public DateTime? EndDate { get; set; }
        [DisplayName("Menadžer")]
        public string ManagerName { get; set; }
    }
}