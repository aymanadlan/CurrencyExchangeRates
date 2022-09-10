using PGSAssignment.Models;

namespace PGSAssignment.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                if (!context.Rates.Any())
                {
                    context.Rates.AddRange(new List<Rate>()
                    {
                        new Rate()
                        {
                            CurrencyRateDate= DateTime.Now,
                            FromCurrencyCode="AED",
                            ToCurrencyCode="KWD",
                            AverageRate=0.009M,
                            EndofDayRate=1.31M,
                            ModifiedDate= DateTime.Now
                        },
                         new Rate()
                        {
                            CurrencyRateDate= DateTime.Now,
                            FromCurrencyCode="KWD",
                            ToCurrencyCode="BHD",
                            AverageRate=0.15M,
                            EndofDayRate=0.06M,
                            ModifiedDate= DateTime.Now
                        },
                        new Rate()
                        {
                            CurrencyRateDate= DateTime.Now,
                            FromCurrencyCode="EUR",
                            ToCurrencyCode="ZAR",
                            AverageRate=1.31M,
                            EndofDayRate=1.16M,
                            ModifiedDate= DateTime.Now
                        },
                         new Rate()
                        {
                            CurrencyRateDate= DateTime.Now,
                            FromCurrencyCode="ZAR",
                            ToCurrencyCode="JPY",
                            AverageRate=.73M,
                            EndofDayRate=.76M,
                            ModifiedDate= DateTime.Now
                        },
                        new Rate()
                        {
                            CurrencyRateDate= DateTime.Now,
                            FromCurrencyCode="BWP",
                            ToCurrencyCode="MUR",
                            AverageRate= .86M,
                            EndofDayRate=1.12M,
                            ModifiedDate= DateTime.Now
                        },
                        new Rate()
                        {
                            CurrencyRateDate= DateTime.Now,
                            FromCurrencyCode="IQD",
                            ToCurrencyCode="EUR",
                            AverageRate=0,
                            EndofDayRate=0,
                            ModifiedDate= DateTime.Now
                        },
                         new Rate()
                        {
                            CurrencyRateDate= DateTime.Now,
                            FromCurrencyCode="MUR",
                            ToCurrencyCode="ZAR",
                            AverageRate=1.56M,
                            EndofDayRate=1.57M,
                            ModifiedDate= DateTime.Now
                        },
                         new Rate()
                        {
                            CurrencyRateDate= DateTime.Now,
                            FromCurrencyCode="BWP",
                            ToCurrencyCode="BHD",
                            AverageRate= 0.06M,
                            EndofDayRate= 0.04M,
                            ModifiedDate= DateTime.Now
                        },
                         //
                         new Rate()
                        {
                            CurrencyRateDate= DateTime.Now,
                            FromCurrencyCode="BRL",
                            ToCurrencyCode="CNY",
                            AverageRate= 0.06M,
                            EndofDayRate= 0.04M,
                            ModifiedDate= DateTime.Now
                        },
                         new Rate()
                        {
                            CurrencyRateDate= DateTime.Now,
                            FromCurrencyCode="CZK",
                            ToCurrencyCode="BHD",
                            AverageRate= 0.06M,
                            EndofDayRate= 0.04M,
                            ModifiedDate= DateTime.Now
                        },
                        new Rate()
                        {
                            CurrencyRateDate= DateTime.Now,
                            FromCurrencyCode="USD",
                            ToCurrencyCode="BRL",
                            AverageRate= 0.06M,
                            EndofDayRate= 0.04M,
                            ModifiedDate= DateTime.Now
                        },
                        new Rate()
                        {
                            CurrencyRateDate= DateTime.Now,
                            FromCurrencyCode="BWP",
                            ToCurrencyCode="BHD",
                            AverageRate= 0.06M,
                            EndofDayRate= 0.04M,
                            ModifiedDate= DateTime.Now
                        },
                         new Rate()
                        {
                            CurrencyRateDate= DateTime.Now,
                            FromCurrencyCode="AUD",
                            ToCurrencyCode="CAD",
                            AverageRate= 0.06M,
                            EndofDayRate= 0.04M,
                            ModifiedDate= DateTime.Now
                        },
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
