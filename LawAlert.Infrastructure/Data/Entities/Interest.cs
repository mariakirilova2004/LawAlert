using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LawAlert.Infrastructure.Data.DataConstants.Interest;


namespace LawAlert.Infrastructure.Data.Entities
{
    public class Interest
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(InterestMaxLengthType, MinimumLength = InterestMinLengthType)]
        public string Type { get; set; }

        [Required]
        [StringLength(InterestMaxLengthDescription, MinimumLength = InterestMinLengthDescription)]
        public string Description { get; set; }
    }
}
