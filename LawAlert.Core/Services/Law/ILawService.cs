using LawAlert.Core.Models.Law;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawAlert.Core.Services.Law
{
    public interface ILawService
    {
        AllLawsQueryModel All(string SearchText, int CurrentPage, int LawsPerPage);
    }
}
