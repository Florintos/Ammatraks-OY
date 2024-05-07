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
    /// Interaction logic for AddClientDataWindow.xaml
    /// </summary>
    public partial class AddClientDataWindow : Window
    {
        // Property to expose the new client object
        public Client NewClient { get; private set; }

        public AddClientDataWindow()
        {
            InitializeComponent();
        }

        // Save button click event handler
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve data entered by the user
            int clientID = int.Parse(txtClientID.Text);
            string clientName = txtClientName.Text;
            string clientPhoneNumber = txtClientPhoneNumber.Text;
            string clientEmail = txtClientEmail.Text;

            // Create new Client object
            NewClient = new Client
            {
                ID = clientID,
                Name = clientName,
                PhoneNumber = clientPhoneNumber,
                Email = clientEmail
            };

            // Close the window
            DialogResult = true;
        }
    }
}
