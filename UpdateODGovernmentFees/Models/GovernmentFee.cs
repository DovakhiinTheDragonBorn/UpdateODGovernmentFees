using System.ComponentModel.DataAnnotations;

namespace UpdateODGovernmentFees.Models
{
    public class GovernmentFee
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(250, ErrorMessage = "Error", MinimumLength = 10)]
        public string HowTo { get; set; }
        [Required]
        public string Line { get; set; }
        [Required]
        public string Platform { get; set; }
    }
}