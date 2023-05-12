using ProgrammingTest.ViewModel;
using System.Windows;

namespace ProgrammingTest.View
{
    /// <summary>
    /// Interaction logic for DisplayPage.xaml
    /// </summary>
    public partial class DisplayPage : Window
    {
        public DisplayPage()
        {
            this.DataContext = new DisplayPageViewModel();
            InitializeComponent();
        }
    }
}
