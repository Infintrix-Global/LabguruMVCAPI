using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LabGuru.BAL
{
   public class DoctorDetails
    {
        public DoctorDetails()
        {
			DoctorDegrees = new HashSet<DoctorDegree>();

		}
		[Key]
        public int DoctorDetailsID { get; set; }
		public int DoctorTypeID { get; set; }
		public int ClinicID { get; set; }
		public DateTime? RegDate { get; set; }
		[MaxLength(50)]
		public string FirstName { get; set; }
		[MaxLength(50)]
		public string MiddleName { get; set; }
		[MaxLength(50)]
		public string LastName { get; set; }
		[MaxLength(10)]
		public string Gender { get; set; }
		public string Email { get; set; }
		[MaxLength(10)]
		public string BloodGroup { get; set; }
		[MaxLength(50)]
		public string Mobile1 { get; set; }
		[MaxLength(50)]
		public string Mobile2 { get; set; }
		public string Residential_Address { get; set; }
		public string Line1 { get; set; }
		public string Line2 { get; set; }
		public int? CountryID { get; set; }
		public int? StateID { get; set; }
		public int? CityID { get; set; }
		public int? LocationID { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public int? ModifiedBy { get; set; }
		public bool IsActive { get; set; }
		[MaxLength(10)]
		public string OTP { get; set; }
		public bool IsDeleted { get; set; } = false;
		[MaxLength(10)]
		public string AreaPin { get; set; }
		[MaxLength(50)]
		public string UserName { get; set; }
		[MaxLength(50)]
		public string Password { get; set; }
		public DateTime? DOB { get; set; }
		[MaxLength(50)]
		public string RegistrationNo { get; set; }
		[MaxLength(50)]
		public string PanCardNo { get; set; }
		public string PanCardImageUrl { get; set; }
		[MaxLength(50)]
		public string AdharCardNo { get; set; }
		public string AdharCardImageUrl { get; set; }
		public string ProfileImageUrl { get; set; }
		public string RegistrationImageUrl { get; set; }
		public string IdentityPolicyNo { get; set; }
		public string IdentityPolicyImageUrl { get; set; }
		public int RoleID { get; set; }
		public DateTime CreatedDate { get; set; }
		public TimeSpan InTime { get; set; }
		public TimeSpan OutTime { get; set; }
		public bool IsExistUser { get; set; } = false;
		[Required]
		public bool isTermAccept { get; set; } 

		public ICollection<DoctorDegree> DoctorDegrees { get; set; }
	}
}
