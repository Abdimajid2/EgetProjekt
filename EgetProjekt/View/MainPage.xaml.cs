namespace EgetProjekt
{
    public partial class MainPage : ContentPage
    { 

        public MainPage()
        {
            InitializeComponent();
        }
 
        private async void OnCreateAccountClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateAccount());
        }

        private async void OnLogInclicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LogInPage());
        }
    }

}
