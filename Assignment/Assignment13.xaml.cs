using Assignment.MVVM.ViewModels;
using Assignment.Services;

namespace Assignment;

public partial class Assignment13 : ContentPage
{
	public Assignment13()
	{
		InitializeComponent();
		var assignment13Service = new Assignment13Service();
		BindingContext = new Assignment13ViewModel(assignment13Service);
	}
}