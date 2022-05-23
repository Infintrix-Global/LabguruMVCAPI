using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LabGuru.BAL
{
    public class MenuRight
    {
        public MenuRight()
        {
            Page_Add = false;
            Page_Delete = false;
            Page_Edit = false;
            Page_View = false;
        }
        [Key]
        public int MenuRightID { get; set; }
        [Required]
        public int MenuID { get; set; }
        [Required, MaxLength(50)]

        // Foreign key
        [Display(Name = "RoleID")]
        public virtual int RoleID { get; set; }

        [ForeignKey("RoleID")]
        public virtual Role Roles { get; set; }

        [Required]
        public bool Page_Add { get; set; }
        [Required]
        public bool Page_Edit { get; set; }
        [Required]
        public bool Page_Delete { get; set; }
        [Required]
        public bool Page_View { get; set; }
    }
}
