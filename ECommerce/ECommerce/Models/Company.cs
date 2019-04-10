namespace ECommerce.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using WebECommerce.Models;

    public class Company
    {
        [Key]
        public int CompanyId { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [StringLength(30, ErrorMessage =
            "The field {0} can contain maximun {1} and minimum {2} characters",
            MinimumLength = 4)]
        [Display(Name = "Company")]
        [Index("Company_Index", IsUnique = true)]
        public string NameCompany { get; set; }

        [StringLength(30, ErrorMessage = 
            "The field {0} must contain between {2} and {1} characters", 
            MinimumLength = 3)]
        [Required(ErrorMessage = "You must enter the field {0}")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [StringLength(30, ErrorMessage = 
            "The field {0} must contain between {2} and {1} characters", 
            MinimumLength = 3)]
        [Required(ErrorMessage = "You must enter the field {0}")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please enter Email")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", 
            ErrorMessage = "Email is not valid.")]
        public string Email { get; set; }
        
        [Display(Name = "Contact Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public int PhoneNumber { get; set; }
        
        [Display(Name = "Contact Mobile Number")]
        [DataType(DataType.PhoneNumber)]
        public int Mobile01 { get; set; }
        
        [Display(Name = "Contact Mobile Number")]
        [DataType(DataType.PhoneNumber)]
        public int Mobile02 { get; set; }

        [DataType(DataType.Url)]
        [Display(Name = "Web Page")]
        public string URL { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Logo { get; set; }

        [StringLength(30, ErrorMessage = 
            "The field {0} must contain between {2} and {1} characters", 
            MinimumLength = 3)]
        [Required(ErrorMessage = "You must enter the field {0}")]
        public string Address { get; set; }

        [NotMapped]
        public string FullName { get { return string.Format("{0} {1}", 
            FirstName, LastName); } }

        [Required(ErrorMessage = "You must enter a {0}")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Display(Name = "State")]
        public int StateId { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Display(Name = "City")]
        public int CityId { get; set; }

        public virtual State State { get; set; }

        public virtual City City { get; set; }


    }
}