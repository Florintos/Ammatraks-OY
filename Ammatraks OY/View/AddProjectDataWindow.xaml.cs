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
    /// Interaction logic for AddProjectDataWindow.xaml
    /// </summary>
    public partial class AddProjectDataWindow : Window
    {
        private readonly Client selectedClient;

        // Property to expose the new project object
        public Project NewProject { get; private set; }

        // Constructor with a parameter to accept the selected client
        public AddProjectDataWindow(Client client)
        {
            InitializeComponent();
            selectedClient = client;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve data entered by the user
            int projectID = int.Parse(txtProjectID.Text);
            string projectName = txtProjectName.Text;
            string projectDescription = txtProjectDescription.Text;
            // Parse worker data or handle worker selection here

            // Create new Project object
            NewProject = new Project
            {
                ID = projectID,
                Name = projectName,
                Description = projectDescription
                // Assign workers to the project
            };

            // Close the window
            DialogResult = true;
        }
    }
}
