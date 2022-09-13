using System.ComponentModel.DataAnnotations;

namespace UpdateODGovernmentFees.DTOs
{
    public class GovernmentFeeDTO
    {

        [Required]
        [MaxLength(250)]
        public string HowTo { get; set; }
        [Required]
        public string Line { get; set; }
        [Required]
        public string Platform { get; set; }

    }
}