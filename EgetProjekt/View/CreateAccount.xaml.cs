using EgetProjekt.DataAccessManager;
using EgetProjekt.View;
using EgetProjekt.ViewModel;
using System.Globalization;

namespace EgetProjekt;

public partial class CreateAccount : ContentPage
{
    public CreateAccount()
    {
        InitializeComponent();
    }

    private async void OnGoBckToMainPage(object sender, EventArgs e)
    {

        await Navigation.PushAsync(new MainPage());
    }

    private async void OnStartPage(object sender, EventArgs e)
    {
        

        var Firstname = EnterFirstName.Text;
        var Lastname = EnterLastName.Text;
        var Email = EnterEmail.Text;
        var Password = EnterPassword.Text;

        decimal weight, height;

        //if(string.IsNullOrEmpty(Firstname) ||
        //  (string.IsNullOrEmpty(Lastname) ||
        //  (string.IsNullOrEmpty(Email) ||
        //  (string.IsNullOrEmpty(Password) ||
        //  (decimal .TryParse(Email, out Email) &&)
        //{

        //}

        decimal.TryParse(EnterWeight.Text, out weight);
        decimal.TryParse((EnterHeight.Text), out height);
        DateTime birthyear;
        DateTime.TryParse(EnterBirthDate.Text, out birthyear);
        Models.User user = new Models.User
        {
            FirstName = Firstname,
            LastName = Lastname,
            Email = Email,
            Password = Password,
            Weight = weight,
            Height = height,
            BirthYear = birthyear
        };

        var usercollection = Connection.UserCollection();

        await usercollection.InsertOneAsync(user);

        await Navigation.PushAsync(new View.StartPage(user.FirstName, user.Weight));
    }

  
}