using LawAlert.Core.Models.Chapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawAlert.Core.Services.Chapter
{
    public interface IChapterService
    {
        AllChaptersQueryModel All(string SearchText, int CurrentPage, int ChaptersPerPage, int id);
    }
}
