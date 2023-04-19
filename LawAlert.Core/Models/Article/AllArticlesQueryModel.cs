using LawAlert.Core.Models.Chapter;
using LawAlert.Core.Models.Interest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawAlert.Core.Models.Article
{
    public class AllArticlesQueryModel
    {
        public string ChapterName { get; set; }
        public string LawName { get; set; }

        [DisplayName("Search by Text")]
        public string SearchText { get; init; }
        public int ArticlesPerPage { get; init; } = 3;
        public int CurrentPage { get; init; } = 1;
        public int TotalArticlesCount { get; set; }
        public List<ArticleViewModel> Articles { get; set; }
    }
}
