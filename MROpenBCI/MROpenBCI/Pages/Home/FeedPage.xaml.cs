using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MROpenBCI.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MROpenBCI.Pages.Home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FeedPage : ContentPage
    {
        public FeedPage()
        {
            BindingContext = new FeedViewModel();
            InitializeComponent();
        }
    }
}