namespace GenshinBuilds.MauiClient
{
    public partial class App : Microsoft.Maui.IApplication
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }
    }
}