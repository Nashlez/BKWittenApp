using BKWitten_App_Frontend.Models;
using BKWitten_App_Frontend.ViewModels;
using System.Collections.ObjectModel;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;

namespace BKWitten_App_Frontend.Pages;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
 
        this.BindingContext = new PostViewModel();
    }
}
