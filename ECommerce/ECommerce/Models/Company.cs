namespace WebECommerce.Models
{
    using System.Collections.Generic;
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
            MinimumLength = 3)]
        [Index("NameCompany_Index", IsUnique = true)]
        [Display(Name = "Company")]
        public string NameCompany { get; set; }

        [StringLength(30, ErrorMessage = 
            "The field {0} must contain between {2} and {1} characters", 
            MinimumLength = 3)]
        [Required(ErrorMessage = "You must enter the field {0}")]
        public string Address { get; set; }


        [DataType(DataType.PhoneNumber)]
        [StringLength(30, ErrorMessage = 
            "The field {0} must contain between {2} and {1} characters", 
            MinimumLength = 3)]
        [Required(ErrorMessage = "You must enter the field {0}")]
        public string Phone { get; set; }

        [DataType(DataType.PhoneNumber)]
        [StringLength(30, ErrorMessage = 
            "The field {0} must contain between {2} and {1} characters", 
            MinimumLength = 3)]
        [Required(ErrorMessage = "You must enter the field {0}")]
        [Display(Name = "Mòvil 1")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string Mobile01 { get; set; }

        [DataType(DataType.PhoneNumber)]
        [StringLength(30, ErrorMessage =
            "The field {0} must contain between {2} and {1} characters",
            MinimumLength = 3)]
        [Required(ErrorMessage = "You must enter the field {0}")]
        [Display(Name = "Mòvil 2")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string Mobilel02 { get; set; }

        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", 
            ErrorMessage = "Email is not valid.")]
        public string EMail { get; set; }

        [DataType(DataType.Url)]
        [Display(Name = "Web Page")]
        public string WebPage { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Logo { get; set; }

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