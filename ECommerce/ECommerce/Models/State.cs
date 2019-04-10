namespace WebECommerce.Models
{
    using WebECommerce.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class State
    {
        [Key]
        public int StateId { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [StringLength(30, ErrorMessage =
            "The field {0} can contain maximun {1} and minimum {2} characters",
            MinimumLength = 3)]
        [Index("NameState_Index", IsUnique = true)]
        [Display(Name = "State")]
        public string NameState { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [Index("CodeState_Index", IsUnique = true)]
        [Display(Name = "Code State")]
        public int CodeState  { get; set; }

        public virtual ICollection<City> Cities { get; set; }

        public virtual ICollection<Company> Companies { get; set; }
    }
}