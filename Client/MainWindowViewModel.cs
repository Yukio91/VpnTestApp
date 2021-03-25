using vpn.Client.Base;

namespace vpn.Client.ViewModel
{
    public class MainWindowViewModel : NotifyObjectBase
    {
        public MainPageViewModel MainPageViewModel { get; set; }

        public MainWindowViewModel()
        {
            MainPageViewModel = new MainPageViewModel();
        }
    }
}
