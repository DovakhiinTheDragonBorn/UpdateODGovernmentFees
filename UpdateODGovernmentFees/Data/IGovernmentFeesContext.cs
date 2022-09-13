using System.Collections.Generic;
using UpdateODGovernmentFees.Models;

namespace UpdateODGovernmentFees.Data
{
    public interface IGovernmentFeesContext
    {
        bool SaveChanges();
        IEnumerable<GovernmentFee> GetAllGovernmentFees();
        GovernmentFee GetGovernmentFeeByID(int ID);
        void CreateGovernmentFee(GovernmentFee gvtFee);
        void UpdateGovernmentFee(GovernmentFee gvtFee);
        void DeleteGovernmentFee(GovernmentFee gvtFee);
    }
}