
namespace Assignment;

public partial class Assignment8 : ContentPage
{
    public Assignment8()
    {
        InitializeComponent();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        string Name = EntryName.Text;
        string Email = EntryEmail.Text;
        DateTime DateofBirth = DatePicker.Date;
        string Gender = M.IsChecked ? "Male" : "Female";
        bool AgreeToTerms = EntryAgree.IsToggled;
        int Experience = (int)EntryExperience.Value;
        int Dependent = (int)EntryDependent.Value;

        string message = $"Name : {Name}\nEmail : {Email}\n" +
            $"Date of Birth : {DateofBirth:dd/MM/yyyy}\nGender : {Gender}\n" +
            $"Agree to Term : {(AgreeToTerms ? "Yes" : "No")}\n" +
            $"Experience : {Experience} years\nDependents : {Dependent}";

        DisplayAlert("Registration",message,"OK");
    }

    private void EntryAgree_Toggled(object sender, ToggledEventArgs e)
    {
        EntrySwitchValue.Text = e.Value ? "Switch : Yes" : "Switch : No";
    }

    private void EntryExperience_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        EntryExperienceValue.Text = $"Experience : {e.NewValue:F0}";
    }

    private void EntryDependent_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        EntryDependentValue.Text = $"Dependent : {e.NewValue:F0}";
    }

}