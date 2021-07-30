﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace test.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Test3 : ContentPage
    {
        public Test3()
        {
            InitializeComponent();
            CreateCommand = new Command<Type>((Type viewType) =>
            {
                View view = (View)Activator.CreateInstance(viewType);
                view.VerticalOptions = LayoutOptions.CenterAndExpand;
                stackLayout.Children.Add(view);
            });

            BindingContext = this;
        }

        public ICommand CreateCommand { private set; get; }
    
    }
}