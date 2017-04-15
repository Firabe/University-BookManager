using System.Windows;
using System.Windows.Controls;

namespace BookManager
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void QuitApplication(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       
    }

    

}
