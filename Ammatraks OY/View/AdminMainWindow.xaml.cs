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
    /// Interaction logic for AdminMainWindow.xaml
    /// </summary>
    public partial class AdminMainWindow : Window
    {
        public AdminMainWindow()
        {
            InitializeComponent();
        }

        private void LogOut_Button_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        private void Archives_Button_Click(object sender, RoutedEventArgs e)
        {
            ArchivesMenuWindow archives = new ArchivesMenuWindow();
            archives.Show();
            this.Close();
        }

        private void Workers_Button_Click(object sender, RoutedEventArgs e)
        {
            WorkerMenuWindow workerMenu = new WorkerMenuWindow();
            workerMenu.Show();
            this.Close();
        }

    }
}
