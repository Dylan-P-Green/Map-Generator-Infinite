using System;

using Map_Generator_Infinite.ViewModels;

using Windows.UI.Xaml.Controls;

namespace Map_Generator_Infinite.Views
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; } = new MainViewModel();

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
