using System;
using System.Windows.Input;
using Map_Generator_Infinite.Helpers;
using Map_Generator_Infinite.Services;
using Map_Generator_Infinite.Views;
using PixelEditorLib;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace Map_Generator_Infinite.ViewModels
{
    public class MainViewModel : Observable
    {
        public MainViewModel()
        {

        }


        private int _xOffset = 0;

        public int XOffset
        {
            get
            {
                return _xOffset;
            }
            set
            {
                _xOffset = value;
            }
        }

        private int _yOffset = 0;

        public int YOffset
        {
            get
            {
                return _yOffset;
            }
            set
            {
                _yOffset = value;
            }
        }

        private ImageSource _mapSource;

        public ImageSource MapSource
        {
            get
            {
                return _mapSource;
            }
            set
            {
                _mapSource = value;
            }
        }

        private ICommand _generateImageCommand;

        public ICommand GenerateImageCommand
        {
            get
            {

                if (_generateImageCommand == null)
                {
                    _generateImageCommand = new RelayCommand(
                        async () =>
                        {
                            PixelRGBA[,] array = PixelManager.GeneratePixelCanvas(1024, 1024);
                            SoftwareBitmapSource source = new SoftwareBitmapSource();
                            await source.SetBitmapAsync(PixelManager.SavePixelArray(array));
                            Set(ref _mapSource, source, "MapSource");
                        });
                }
                return _generateImageCommand;
            }
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
