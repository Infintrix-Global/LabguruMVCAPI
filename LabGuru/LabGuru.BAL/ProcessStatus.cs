using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LabGuru.BAL
{
    public class ProcessStatus
    {
		[Key]
		public int ProcessStatusID { get; set; }
		
		[Required]
		[MaxLength(30)]
		public string StatusName{ get; set; }
		[Required]
		public bool IsActive { get; set; }
	}
}
