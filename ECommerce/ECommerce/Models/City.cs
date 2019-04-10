namespace WebECommerce.Models
{
    using WebECommerce.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class City
    {
        [Key]
        public int CityId { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [StringLength(30, ErrorMessage =
            "The field {0} can contain maximun {1} and minimum {2} characters",
            MinimumLength = 4)]
        [Display(Name = "Name")]
        public string NameCity { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [Index("CodeCity_Index", IsUnique = true)]
        [Display(Name = "Code Postal")]
        public int CodePostalCity { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Display(Name = "State")]
        public int StateId { get; set; }

        public virtual State State { get; set; }

        public virtual ICollection<Company> Companies { get; set; }
    }
}