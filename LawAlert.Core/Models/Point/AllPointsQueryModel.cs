using LawAlert.Core.Models.Chapter;
using LawAlert.Core.Models.Interest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawAlert.Core.Models.Point
{
    public class AllPointsQueryModel
    {
        public string ArticleName { get; set; }
        public string ChapterName { get; set; }
        public string LawName { get; set; }

        [DisplayName("Search by Text")]
        public string SearchText { get; init; }
        public int PointsPerPage { get; init; } = 1;
        public int CurrentPage { get; init; } = 1;
        public int TotalPointsCount { get; set; }
        public List<PointViewModel> Points { get; set; }
    }
}
