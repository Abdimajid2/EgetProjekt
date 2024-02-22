namespace EgetProjekt.View;

public partial class StartPageBinding : ContentPage
{
	public StartPageBinding()
	{
		InitializeComponent();
		BindingContext = new ViewModel.StartPageViewModel();
	}
}