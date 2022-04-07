using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LabGuru.BAL
{
   public class Menu
    {
        [Key]
        public int MenuID { get; set; }
        [Required, MaxLength(50)]
        public string MenuName { get; set; }
        [Required, MaxLength(50)]
        public string Path { get; set; }
        public int ParentId { get; set; }
        [Required]
        public int orderno { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public string MenuIcon { get; set; }


    }
}
