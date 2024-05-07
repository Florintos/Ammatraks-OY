using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ammatraks_OY.Model
{
    public class Invoice
    {
        public int ID { get; set; }
        public string IDFormatted => "Invoice #" + ID;
        public DateTime Date { get; set; }
        public DateTime PaymentDate { get; set; }
        public double InvoiceRating
        {
            get
            {
                double rating = 5.0;

                DateTime paymentDate = PaymentDate;
                DateTime currentDate = DateTime.Today;

                int daysPassed = (int)(currentDate - paymentDate).TotalDays;

                for (int i = 0; i < daysPassed; i++)
                {
                    rating -= 0.5;

                    if (rating < 0)
                    {
                        rating = 0;
                        break;
                    }
                }

                return rating;
            }
        }
    }
}
