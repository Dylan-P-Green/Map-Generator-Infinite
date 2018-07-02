using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Map_Generator_Infinite.Helpers;
using Map_Generator_Infinite.Models.Generators;
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


        private string _mapSeed;

        public string MapSeed
        {
            get
            {
                return _mapSeed;
            }
            set
            {
                _mapSeed = value;
            }
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

        //List of all functioning generators
        private List<Generator> _generatorList = new List<Generator> { new RandomPixelGenerator() };

        //Array of pixels used to generate map
        private PixelRGBA[,] array;

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
                            //Create canvas out of 2D pixels
                            array = PixelManager.GeneratePixelCanvas(1024, 1024);
                            int integerSeed = 0; //Seed used in calculations

                            if (_mapSeed == null) //Has the seed been set?
                            {
                                //If not, generate one
                                Random r = new Random(); //TODO: Check if seeds are genrated different each run
                                integerSeed = r.Next();
                            }
                            else
                            {
                                foreach (char c in _mapSeed)
                                    integerSeed += (int)c; //add together unicode values in string
                            }

                            //Run though each generator and apply it
                            foreach (Generator g in _generatorList)
                            {
                                if (g.IsEnabled) array = g.Apply(array, integerSeed);
                            }

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
