using LawAlert.Core.Models.Article;
using LawAlert.Core.Models.Point;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawAlert.Core.Services.Point
{
    public interface IPointService
    {
        public AllPointsQueryModel All(string SearchText, int CurrentPage, int PointsPerPage, int id);
    }
}
