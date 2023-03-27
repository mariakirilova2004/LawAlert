using LawAlert.Core.Models.Interest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawAlert.Core.Services.Interest
{
    public interface IInterestService
    {
        List<InterestViewModel> GetInterestViewModels();
    }
}
