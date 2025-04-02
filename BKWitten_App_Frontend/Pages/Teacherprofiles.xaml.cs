using BKWitten_App_Frontend.ViewModels;

namespace BKWitten_App_Frontend.Pages;

public partial class Teacherprofiles : ContentPage
{
	public Teacherprofiles()
	{
		InitializeComponent();
        this.BindingContext = new UserViewModel();
    }
}