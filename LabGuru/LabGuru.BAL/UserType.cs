using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LabGuru.BAL
{
    public class UserType
    {
        public int UserTypeID { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserTypeName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
