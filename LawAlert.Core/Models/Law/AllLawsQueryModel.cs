using LawAlert.Core.Models.Interest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawAlert.Core.Models.Law
{
    public class AllLawsQueryModel
    {
        [DisplayName("Search by Text")]
        public string SearchText { get; init; }
        public int LawsPerPage { get; init; } = 10;
        public int CurrentPage { get; init; } = 1;
        public int TotalLawsCount { get; set; }
        public List<LawViewModel> Laws { get; set; }
        public int InterestId { get; set; }
        public List<InterestViewModel> Interests { get; set; }
    }
}
