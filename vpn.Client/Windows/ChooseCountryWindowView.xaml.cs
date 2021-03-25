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
using vpn.Client.ViewModel;

namespace vpn.Client.Windows
{
    /// <summary>
    /// Interaction logic for ChooseCountryWindowView.xaml
    /// </summary>
    public partial class ChooseCountryWindowView : Window
    {
        //public ChooseCountryWindowView(Func<Action, ChooseCountryViewModel> viewModelFactory)
        //{
        //    DataContext = viewModelFactory(() => { DialogResult = true; });
        //    InitializeComponent();
        //}
        public ChooseCountryWindowView(MainPageViewModel mainPage)
        {
            var viewModel = new ChooseCountryViewModel(mainPage);
            viewModel.CloseWindow += ViewModel_CloseWindow;
            DataContext = viewModel;
            InitializeComponent();
        }

        private void ViewModel_CloseWindow(object sender, EventArgs e)
        {
            DialogResult = true;
            this.Close();
        }
    }
}
