using LawAlert.Core.Models.Chapter;
using LawAlert.Core.Models.Interest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawAlert.Core.Models.Law
{
    public class AllChaptersQueryModel
    {
        [DisplayName("Search by Text")]
        public string SearchText { get; init; }
        public int ChaptersPerPage { get; init; } = 3;
        public int CurrentPage { get; init; } = 1;
        public int TotalChaptersCount { get; set; }
        public List<ChapterViewModel> Chapters { get; set; }
    }
}
