using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Add_Update_Delete.Models
{
    [Table("Employee")]
    public class EmployeeInfo
    {
        public int ID { get; set; }
        
        [DisplayName("First name")]
        [Required]
        public string FName { get; set; }

        [DisplayName("Last name")]
        [Required]
        public string LName { get; set; }

        public string Department { get; set; }
    }
}