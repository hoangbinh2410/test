using System;
using test.Services;
using test.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace test
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            //MainPage = new NavigationPage( new Page1());
            //DependencyService.Register<MockDataStore>();
            // MainPage = new Page1();
            //MainPage = new Page2();
            MainPage = new Test3();
            //MainPage = new Test2();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
