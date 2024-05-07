using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ammatraks_OY.Model
{
    public class Client
    {
        public string Name { get; set; }

        public int ID { get; set; }

        public string IDFormatted => "#" + ID;

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public List<Project> Projects { get; set; }

        public double ClientRating
        {
            get
            {
                double totalRating = 0.0;
                int invoiceCount = 0;

                if (Projects != null)
                {
                    foreach (var project in Projects)
                    {
                        if (project.Invoices != null)
                        {
                            foreach (var invoice in project.Invoices)
                            {
                                double invoiceRating = invoice.InvoiceRating;
                                totalRating += invoiceRating;
                                invoiceCount++;
                            }
                        }
                    }
                }

                // Compute the average rating by dividing the total rating by the number of invoices.
                // If there are no invoices, return a default rating of 0.0.
                double averageRating = invoiceCount > 0 ? totalRating / invoiceCount : 0.0;

                return averageRating;
            }
        }
    }
}
