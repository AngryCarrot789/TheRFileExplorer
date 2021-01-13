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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TheRFramework.Utilities;

namespace TheRFileExplorer.Explorer.Quick
{
    /// <summary>
    /// Interaction logic for QuickAccessItem.xaml
    /// </summary>
    public partial class QuickAccessItem : UserControl
    {
        public QuickAccessItemViewModel Model => DataContext as QuickAccessItemViewModel;

        public QuickAccessItem()
        {
            InitializeComponent();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Model.Navigate();
        }
    }
}
