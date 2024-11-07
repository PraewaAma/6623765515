using Assignment.MVVM.ViewModels;

namespace Assignment;

public partial class Assignment11 : ContentPage
{
	public Assignment11()
	{
		InitializeComponent();
		BindingContext = new CarsPageViewModels();
	}
}