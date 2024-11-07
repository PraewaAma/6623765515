using Assignment.MVVM.ViewModels;

namespace Assignment;

public partial class Assignment12 : ContentPage
{
	public Assignment12()
	{
		InitializeComponent();
		BindingContext = new CarsPageViewModels();
	}
}