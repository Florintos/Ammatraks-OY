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
    /// Interaction logic for ArchivesMenuWindow.xaml
    /// </summary>
    public partial class ArchivesMenuWindow : Window
    {
        private List<Client> clients;

        public ArchivesMenuWindow()
        {
            InitializeComponent();

            // Initialize sample data
            InitializeData();

            // Populate the client listbox
            clientListBox.ItemsSource = clients;

            // Set selection change event handlers
            clientListBox.SelectionChanged += ClientListBox_SelectionChanged;
            projectListBox.SelectionChanged += ProjectListBox_SelectionChanged;
        }

        private void InitializeData()
        {
            // Initialize clients
            clients = new List<Client>
            {
                new Client
                {
                    Name = "Monkey",
                    ID = 11,
                    PhoneNumber = "12345678",
                    Email = "Monkeybusiness@gmail.com",
                    Projects = new List<Project>
                    {
                        new Project
                        {
                            Name = "Monkey business",
                            ID = 21,
                            Invoices = new List<Invoice>
                            {
                                new Invoice {ID = 31, Date = new System.DateTime(2024, 4, 25), PaymentDate = new System.DateTime(2024, 5, 10)},
                                new Invoice {ID = 32, Date = new System.DateTime(2024, 4, 26), PaymentDate = new System.DateTime(2024, 5, 11)}
                            }
                        }
                    }
                }
            };
        }

        private void ClientListBox_SelectionChanged(object sender, RoutedEventArgs e)
        {

            invoiceListBox.ItemsSource = null;

            if (clientListBox.SelectedItem != null)
            {
                var selectedClient = (Client)clientListBox.SelectedItem;
                projectListBox.ItemsSource = selectedClient.Projects;
            }
        }

        // Event handler for project selection change
        private void ProjectListBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (projectListBox.SelectedItem != null)
            {
                var selectedProject = (Project)projectListBox.SelectedItem;
                invoiceListBox.ItemsSource = selectedProject.Invoices;
            }
        }

        private void Return_Button_Click(object sender, RoutedEventArgs e)
        {
            AdminMainWindow adminMenu = new AdminMainWindow();
            adminMenu.Show();
            this.Close();
        }

        // Event handler for Add Client button click
        private void btnAddClient_Click(object sender, RoutedEventArgs e)
        {
            OpenAddClientWindow();
        }

        // Event handler for Add Project button click
        private void btnAddProject_Click(object sender, RoutedEventArgs e)
        {
            if (clientListBox.SelectedItem != null && clientListBox.SelectedItem is Client selectedClient)
            {
                OpenAddProjectWindow(selectedClient);
            }
            else
            {
                MessageBox.Show("Please select a client first.");
            }
        }

        // Event handler for Add Invoice button click
        private void btnAddInvoice_Click(object sender, RoutedEventArgs e)
        {
            if (clientListBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a client first.", "Add Invoice", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (projectListBox.SelectedItem == null)
            {
                Client selectedClient = (Client)clientListBox.SelectedItem;
                if (selectedClient.Projects == null || selectedClient.Projects.Count == 0)
                {
                    MessageBox.Show("There are no projects. Please add a project first.", "Add Invoice", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    MessageBox.Show("Please select a project first.", "Add Invoice", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                // Proceed with adding an invoice
                OpenAddInvoiceWindow((Project)projectListBox.SelectedItem);
            }
        }

        // Method to open AddClientDataWindow
        private void OpenAddClientWindow()
        {
            AddClientDataWindow addClientWindow = new AddClientDataWindow();
            if (addClientWindow.ShowDialog() == true) // ShowDialog() returns true if the user clicks "Save"
            {
                // Retrieve the new client object from the AddClientDataWindow
                Client newClient = addClientWindow.NewClient;

                // Add the new client to the clients list and refresh the ListBox
                if (newClient != null)
                {
                    clients.Add(newClient);
                    clientListBox.ItemsSource = null;
                    clientListBox.ItemsSource = clients;
                }
            }
        }

        // Method to open AddProjectDataWindow
        private void OpenAddProjectWindow(Client selectedClient)
        {
            AddProjectDataWindow addProjectWindow = new AddProjectDataWindow(selectedClient);
            if (addProjectWindow.ShowDialog() == true) // ShowDialog() returns true if the user clicks "Save"
            {
                // Retrieve the new project object from the AddProjectDataWindow
                Project newProject = addProjectWindow.NewProject;

                // Add the new project to the selected client's projects list and refresh the ListBox
                if (newProject != null)
                {
                    selectedClient.Projects ??= new List<Project>(); // Initialize the Projects list if null
                    selectedClient.Projects.Add(newProject);
                    projectListBox.ItemsSource = null;
                    projectListBox.ItemsSource = selectedClient.Projects;
                }
            }
        }

        // Method to open AddInvoiceDataWindow
        private void OpenAddInvoiceWindow(Project selectedProject)
        {
            AddInvoiceDataWindow addInvoiceWindow = new AddInvoiceDataWindow(selectedProject);
            if (addInvoiceWindow.ShowDialog() == true) // ShowDialog() returns true if the user clicks "Save"
            {
                // Retrieve the new invoice object from the AddInvoiceDataWindow
                Invoice newInvoice = addInvoiceWindow.NewInvoice;

                // Add the new invoice to the selected project's invoices list and refresh the ListBox
                if (newInvoice != null)
                {
                    selectedProject.Invoices ??= new List<Invoice>(); // Initialize the Invoices list if null
                    selectedProject.Invoices.Add(newInvoice);
                    invoiceListBox.ItemsSource = null;
                    invoiceListBox.ItemsSource = selectedProject.Invoices;
                }
            }
        }

        private void btnDeleteProject_Click(object sender, RoutedEventArgs e)
        {
            if (projectListBox.SelectedItem != null && projectListBox.SelectedItem is Project selectedProject)
            {
                if (clientListBox.SelectedItem != null && clientListBox.SelectedItem is Client selectedClient)
                {
                    // Remove the selected project from the list of projects associated with the selected client
                    selectedClient.Projects.Remove(selectedProject);
                    // Update the projectListBox to reflect the changes
                    projectListBox.ItemsSource = null;
                    projectListBox.ItemsSource = selectedClient.Projects;
                }
                else
                {
                    MessageBox.Show("Please select a client first.");
                }
            }
            else
            {
                MessageBox.Show("Please select a project to delete.");
            }
        }

        // Delete button click event handler for Invoice
        private void btnDeleteInvoice_Click(object sender, RoutedEventArgs e)
        {
            if (invoiceListBox.SelectedItem != null && invoiceListBox.SelectedItem is Invoice selectedInvoice)
            {
                if (projectListBox.SelectedItem != null && projectListBox.SelectedItem is Project selectedProject)
                {
                    // Show a confirmation dialog
                    MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this invoice? " +
                    "This action is permanent and cannot be undone.", "Delete Invoice", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                    if (result == MessageBoxResult.Yes)
                    {
                        // Remove the selected invoice from the list of invoices associated with the selected project
                        selectedProject.Invoices.Remove(selectedInvoice);
                        // Update the invoiceListBox to reflect the changes
                        invoiceListBox.ItemsSource = null;
                        invoiceListBox.ItemsSource = selectedProject.Invoices;
                    }
                }
                else
                {
                    MessageBox.Show("Please select a project first.");
                }
            }
            else
            {
                MessageBox.Show("Please select an invoice to delete.");
            }
        }

    }
}