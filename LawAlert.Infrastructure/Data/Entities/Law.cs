using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LawAlert.Infrastructure.Data.DataConstants.Law;


namespace LawAlert.Infrastructure.Data.Entities
{
    public class Law
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(LawMaxLengthName, MinimumLength = LawMinLengthName)]
        public string Name { get; set; }

        [Required]
        [StringLength(LawMaxLengthDetails, MinimumLength = LawMinLengthDetails)]
        public string Details { get; set; }

        [Required]
        public virtual List<Chapter>? Chapters { get; set; } = new List<Chapter>();

        [Required]
        public int InterestId { get; set; }

        [ForeignKey(nameof(InterestId))]
        public Interest? Interest { get; set; }
    }
}
