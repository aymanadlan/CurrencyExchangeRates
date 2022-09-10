using PGSAssignment.Data.Base;
using PGSAssignment.Models;

namespace PGSAssignment.Data.Services
{
    public class RatesService : EntityBaseRepository<Rate>,IRatesService
    {
        public RatesService(AppDbContext context) : base(context)
        {
        }
    }
}
