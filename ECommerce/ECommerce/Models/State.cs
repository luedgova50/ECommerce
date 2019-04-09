namespace WebECommerce.Models
{
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
        [Display(Name = "State")]
        public string NameState { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [Index("CodeStateIndex", IsUnique = true)]
        [Display(Name = "Code State")]
        public int CodeState  { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}