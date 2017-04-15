using System.Windows;

namespace BookManager
{
    public partial class BookWindow : Window
    {
        public BookWindow()
        {
            InitializeComponent();
        }

        private void CancelButton(object sender, RoutedEventArgs e)
        {
            // closes the BookWindow upon cancelling. Also works with Cancel = true; in the .xaml
            this.Close();
        }

        private void SaveButton(object sender, RoutedEventArgs e)
        {
            // closes the BookWindow upon saving
            
            this.Close();
        }
    }
}
