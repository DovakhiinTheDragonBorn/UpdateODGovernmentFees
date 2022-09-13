using UpdateODGovernmentFees.Models;
using Microsoft.EntityFrameworkCore;

namespace UpdateODGovernmentFees.Data
{
    public class GovernmentFeesContext : DbContext
    {
        public GovernmentFeesContext(DbContextOptions<GovernmentFeesContext> opt) : base(opt)
        {

        }
        public DbSet<GovernmentFee> Commands { get; set; }
    }
}