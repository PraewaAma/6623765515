
namespace Assignment;

public partial class Assignment9 : ContentPage
{
	public Assignment9()
	{
		InitializeComponent();
	}

	private string SelectedGender;

	private void OnGenderButton_Clicked(object sender, EventArgs e)
	{
		var button = sender as Button;
		if (button != null)
		{
			SelectedGender = button.Text;
		}
	}

    private void CalulateButton_Clicked(object sender, EventArgs e)
    {
		string Ages = EntryAge.Text;
		string HeightText = EntryHeight.Text;
		string WeightText = EntryWeight.Text;
		
		if(double.TryParse(HeightText, out double HeightinCM) && double.TryParse(WeightText, out double WeightinKg))
		{
			double HeightinM = HeightinCM/100;
			double HeightinMM =  HeightinM * HeightinM;
			double BMI = WeightinKg / HeightinMM;

			// แสดงค่า BMI
			UserBMI.Text = $"{BMI:F2}";

			//BMIProgressBar
			double ProgressBar;
			if (BMI < 18.5)
			{
				ProgressBar = 0.2;
			}
			else if  (BMI >= 18.5 && BMI < 22.9)
			{
				ProgressBar = 0.40;
			}
			else if (BMI >= 22.9 && BMI < 24.9)
			{
				ProgressBar = 0.60;
			}
			else if (BMI >= 24.9 && BMI < 29.9)
			{
				ProgressBar = 0.80;
			}
			else
			{
				ProgressBar = 0.95;
			}
			BMIProgressBar.Progress = ProgressBar;
			
			// แสดงผลว่าผู้ใช้อยู่ในประเภทไหน
			string Category;
			if (BMI < 18.5)
			{
				Category = "Underweight";
			}
			else if  (BMI >= 18.5 && BMI < 22.9)
			{
				Category = "Normal Weight";
			}
			else if (BMI >= 22.9 && BMI < 24.9)
			{
				Category = "Overweight";
			}
			else if (BMI >= 24.9 && BMI < 29.9)
			{
				Category = "Obesity 1";
			}
			else
			{
				Category = "Obesity 2";
			}
			Usertype.Text = Category;

			IdealBMI.Text= $"18.5 - 25";

			// น้ำหนักที่เหมาะสมกับผู้ใช้
			double MinIdealWeight4User = 18.6 * HeightinMM;
			double MaxIdealWeight4User = 22.9 * HeightinMM;

			IdealWeight4User.Text = $"{MinIdealWeight4User:F2} to {MaxIdealWeight4User:F2}";
			
			//BMI Message for User
			string Message;
			if (BMI < 18.5)
			{
				Message = "Being underweight is also a concern, as it may lead to insufficient nutrient intake and fatigue. To address this, ensure adequate food consumption and consider weight training to help increase your BMI to a normal level.";
			}
			else if  (BMI >= 18.5 && BMI < 22.9)
			{
				Message = "The ideal BMI for Thais is between 18.5 and 22.9. Staying within this range minimizes the risk of obesity-related diseases and promotes better health.";
			}
			else if (BMI >= 22.9 && BMI < 24.9)
			{
				Message = "Strive to lower your BMI to reach a standard level. While your current BMI may not indicate obesity, maintaining a healthy weight is crucial for overall well-being.";
			}
			else if (BMI >= 24.9 && BMI < 29.9)
			{
				Message = "Although you may not be classified as severely obese, any level of overweight carries health risks. If there is a family history of diabetes or high blood pressure, the risk becomes even greater.";
			}
			else
			{
				Message = "Being overweight can be dangerous, increasing the risk of serious diseases associated with obesity, such as diabetes and high blood pressure. If your BMI falls into the overweight category, it is essential to monitor fat consumption and exercise regularly.";
			}
			Usertype.Text = Category;
			BMISuggestionMessage.Text = $"{Message}";
		
			UserInformation.Text = $"Information : {SelectedGender} , {Ages} years , {HeightinCM} cm , {WeightinKg} kg";
		}

    }
}
