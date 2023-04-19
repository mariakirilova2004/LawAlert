using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LawAlert.Infrastructure.Data.DataConstants.Point;


namespace LawAlert.Infrastructure.Data.Entities
{
    public class Point
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(PointMaxLengthDescription, MinimumLength = PointMinLengthDescription)]
        public string Description { get; set; }

        [Required]
        public int ArticleId { get; set; }

        [ForeignKey(nameof(ArticleId))]
        public Article? Article { get; set; }
    }
}
