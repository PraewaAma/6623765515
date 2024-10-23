using Assignment.Classes;
using AuthenticationServices;

namespace Assignment;

public partial class Assignment10 : ContentPage
{
	Cars CarNo1;
	Cars CarNo2;
	Cars CarNo3;
	bool Finished = false;
	public Assignment10()
	{
		InitializeComponent();

		CarNo1 = new Cars("Aston Marin","Vantage",325,78,1000,12.2);
		CarNo2 = new Cars ("Porsche","Panerama",302,90,1000,11.7);
		CarNo3 = new Cars ("McLaren","750s",332,72,1000,11.2);
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		if (!this.Finished)
		{
			var ScreenWidth = Application.Current.MainPage.Width;
			this.CarsNo1Run(ScreenWidth);
			this.CarsNo2Run(ScreenWidth);
			this.CarsNo3Run(ScreenWidth);
			this.InfoCars.Text = "1st Car"+ "\n" + CarNo1.ShowInfoCar() + "\n" + "2nd Car"+ "\n" + CarNo2.ShowInfoCar() + "\n" + "3rd Car"+ "\n" + CarNo3.ShowInfoCar();
			this.Finished = true;
		}
		else
		{
			ImageCarNo1.TranslateTo(0,0,0,Easing.Linear);
			ImageCarNo2.TranslateTo(0,0,0,Easing.Linear);
			ImageCarNo3.TranslateTo(0,0,0,Easing.Linear);
			this.Finished = false;
		}
    }
	
	private void CarsNo1Run (double distance)
	{
		var TimeUsed = CarNo1.TimeUsedforDrive(distance);
		ImageCarNo1.TranslateTo(distance-100,0,TimeUsed*500,Easing.Linear);
	}

	private void CarsNo2Run (double distance)
	{
		var TimeUsed = CarNo2.TimeUsedforDrive(distance);
		ImageCarNo2.TranslateTo(distance-100,0,TimeUsed*500,Easing.Linear);
	}

	private void CarsNo3Run (double distance)
	{
		var TimeUsed = CarNo3.TimeUsedforDrive(distance);
		ImageCarNo3.TranslateTo(distance-100,0,TimeUsed*500,Easing.Linear);
	}
}