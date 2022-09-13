using System;
using System.Collections.Generic;
using System.Linq;
using UpdateODGovernmentFees.Models;

namespace UpdateODGovernmentFees.Data
{
    public class SqlGovernmentFeesRepo : IGovernmentFeesContext
    {
        private readonly GovernmentFeesContext _context;

        public SqlGovernmentFeesRepo(GovernmentFeesContext context)
        {
            _context = context;
        }

        public void CreateGovernmentFee(GovernmentFee cmd)
        {
            if (cmd == null)
                throw new ArgumentNullException();

            else
                _context.Add(cmd);
        }

        public void DeleteGovernmentFee(GovernmentFee cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            else
            {
                _context.Remove(cmd);
            }
        }

        public IEnumerable<GovernmentFee> GetAllGovernmentFees()
        {
            return _context.Commands.ToList();
        }

        public GovernmentFee GetGovernmentFeeByID(int ID)
        {
            return _context.Commands.FirstOrDefault(c => c.ID == ID);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateGovernmentFee(GovernmentFee cmd)
        {
            //Do Nothing
        }
    }
}