using PGSAssignment.Data.Base;

namespace PGSAssignment.Models
{
    public class Rate : IEntityBase
    {
        public int Id { get; set; }

        public DateTime CurrencyRateDate { get; set; }

        public string FromCurrencyCode { get; set; }
        public string ToCurrencyCode { get; set; }

        public Decimal AverageRate { get; set; }

        public Decimal EndofDayRate { get; set; }

        public DateTime ModifiedDate { get; set; }

    }
}
