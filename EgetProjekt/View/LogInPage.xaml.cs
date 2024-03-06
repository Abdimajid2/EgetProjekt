using EgetProjekt.Logic;

namespace EgetProjekt;

public partial class LogInPage : ContentPage
{
    public LogInPage()
    {
        InitializeComponent();
    }

    private async void OnGoBckToMainPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }


    private async void OnLogInbutton(object sender, EventArgs e)
    {

        var email = EnterYourEmail.Text;
        var password = EnterYourPassword.Text;

        // kollar att inmatningsf�ltet inte �r tomt
        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            DisplayAlert("Error", "Please enter both email and password", "OK");
            return;
        }
  
        var user = await LogInValidation.CheckLoginInformation(email, password);
        // g�r vidare till start sidan om email och l�senord finns
        if (user != null)
        {
            await Navigation.PushAsync(new View.StartPage());
           
        }
        // annars f�r man detta pop-up meddelandet
        else
        {
            DisplayAlert("WRONG", "Wrong e-mail or password", "Try Again");
        }
    }
}