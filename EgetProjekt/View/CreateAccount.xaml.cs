using EgetProjekt.DataAccessManager;
using EgetProjekt.View;
using EgetProjekt.ViewModel;
using System.Globalization;
using System.Text.RegularExpressions;

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

        int weight, height;       
        if (string.IsNullOrEmpty(Firstname) ||
          string.IsNullOrEmpty(Lastname) ||
          string.IsNullOrEmpty(Email) ||
          string.IsNullOrEmpty(Password) ||
          !int.TryParse(EnterHeight.Text, out height) ||
          !int.TryParse(EnterWeight.Text, out weight))
        {
            DisplayAlert("Error", "Please enter all the information", "OK");
            return;
        }

        DateTime birthyear;
        if (!DateTime.TryParseExact(EnterBirthDate.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out birthyear))
        {
            DisplayAlert("ERROR", "Please write birth in right format","OK");
            return;
        }     
        birthyear = birthyear.Date;
        Models.User user = new Models.User
        {
            id = Guid.NewGuid(),
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

        await Navigation.PushAsync(new View.StartPage(user.FirstName, user.Weight,user.id));
    }

  
}