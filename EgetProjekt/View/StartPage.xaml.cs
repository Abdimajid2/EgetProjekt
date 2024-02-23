namespace EgetProjekt.View;

public partial class StartPage : ContentPage
{
	public StartPage(string firstname, decimal weight)
	{
		InitializeComponent();

        BindingContext = new ViewModel.StartPageViewModel();

		 WelcomeLabel.Text = $"Welcome back, {firstname}";
		WeightLabel.Text = $"Your Current Weight is {weight}kg";

    }
}