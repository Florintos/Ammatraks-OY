using Ammatraks_OY.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Ammatraks_OY.View
{
    /// <summary>
    /// Interaction logic for AddInvoiceDataWindow.xaml
    /// </summary>
    public partial class AddInvoiceDataWindow : Window
    {
        private Project selectedProject;

        public Invoice NewInvoice { get; private set; }

        public AddInvoiceDataWindow(Project project)
        {
            InitializeComponent();
            selectedProject = project;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve data entered by the user
            int invoiceID = int.Parse(txtInvoiceID.Text);
            DateTime invoiceDate = DateTime.Parse(txtInvoiceDate.Text);
            DateTime paymentDate = DateTime.Parse(txtInvoicePayment.Text);

            // Create new Invoice object
            NewInvoice = new Invoice
            {
                ID = invoiceID,
                Date = invoiceDate,
                PaymentDate = paymentDate
            };

            // Close the window
            DialogResult = true;
        }
    }
}
