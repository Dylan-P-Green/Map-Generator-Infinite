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

        private string oldXOffsetText = "";
        private void XOffsetTextBox_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            int temp;
            if (int.TryParse(sender.Text, out temp) || sender.Text == "")
                oldXOffsetText = sender.Text;
            else
            {
                int pos = sender.SelectionStart - 1;
                sender.Text = oldXOffsetText;
                sender.SelectionStart = pos;
            }
        }

        private string oldYOffsetText = "";
        private void YOffsetTextBox_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            int temp;
            if (int.TryParse(sender.Text, out temp) || sender.Text == "")
                oldYOffsetText = sender.Text;
            else
            {
                int pos = sender.SelectionStart - 1;
                sender.Text = oldYOffsetText;
                sender.SelectionStart = pos;
            }
        }
    }
}
