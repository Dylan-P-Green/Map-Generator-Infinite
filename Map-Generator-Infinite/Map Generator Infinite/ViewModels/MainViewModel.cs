using System;
using System.Windows.Input;
using Map_Generator_Infinite.Helpers;
using Map_Generator_Infinite.Services;
using Map_Generator_Infinite.Views;

namespace Map_Generator_Infinite.ViewModels
{
    public class MainViewModel : Observable
    {
        public MainViewModel()
        {

        }

        private ICommand _navigateToSettingsCommand;

        public ICommand NavigateToSettings
        {
            get
            {
                if (_navigateToSettingsCommand == null)
                {
                    _navigateToSettingsCommand = new RelayCommand(
                        () =>
                        {
                            NavigationService.Navigate(typeof(SettingsPage));
                        });
                }

                return _navigateToSettingsCommand;
            }
        }
    }
}
