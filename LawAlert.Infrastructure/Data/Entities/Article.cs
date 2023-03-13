using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static LawAlert.Infrastructure.Data.DataConstants.Article;

namespace LawAlert.Infrastructure.Data.Entities
{
    public class Article
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(ArticleMaxLengthDetails, MinimumLength = ArticleMinLengthDetails)]
        public string Details { get; set; }

        [Required]
        public int ChapterId { get; set; }

        [ForeignKey(nameof(ChapterId))]
        public Chapter? Chapter { get; set; }

        [Required]
        public List<Point>? Points { get; set; } = new List<Point>();

        [Required]
        public bool Updated { get; set; }
    }
}