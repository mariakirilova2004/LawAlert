using LawAlert.Core.Models.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawAlert.Core.Services.Article
{
    public interface IArticleService
    {
        public AllArticlesQueryModel All(string SearchText, int CurrentPage, int ArticlesPerPage, int id);
    }
}
