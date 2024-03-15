
using EgetProjekt.DataAccessManager;
using EgetProjekt.Logic;
using EgetProjekt.Models;
using EgetProjekt.ViewModel;

namespace EgetProjekt.View;

public partial class StartPage : ContentPage
{
	 
	public StartPage(Models.User user)
	{
		InitializeComponent();
		Models.User loggedinuser = Models.User.GetLoggedinUser();
		if (loggedinuser == null)
		{
			WelcomeLabel.Text = $"WELCOME {loggedinuser.FirstName}";
		}
		else
		{
            WelcomeLabel.Text = $"WELCOME {user.FirstName}";
        }

		if (loggedinuser != null)
		{


			CollectlatestRecorded();
		}
		 
		 


		GetQuotes();
		
  
	}

    private async void GetNewWeightCliced(object sender, EventArgs e)
    {
		int enterWeight;
		if(!int.TryParse(EnterNewWeight.Text, out enterWeight))
		{
			DisplayAlert("ERROR", "Enter only numbers", "OK");
			return;
		}
        Models.User loggedinuser = Models.User.GetLoggedinUser();
        Models.Weight weight = new Models.Weight
		{
			
		   userId = loggedinuser.id,
			NewWeight = enterWeight,
			WeightRecorded = DateTime.Now,
		};

		//uppdaterar till den nya vikten
        WeightLabel.Text = $"YOUR NEW WEIGHT IS {weight.NewWeight}KG";
        
		var weightcollection = StartPageViewModel.WeightCollection();

		await weightcollection.InsertOneAsync(weight);

		DisplayAlert("Success", "New weight Recorded", "OK");
 
    }

    private async void OnGetWeightHistory(object sender, EventArgs e)
    {
        Models.User user = new Models.User();
		await Navigation.PushAsync(new WeightHistoryPage(user));
    }

	private async void GetQuotes()
	{
		List<Models.QuotesApi> Quotes = await ViewModel.StartPageViewModel.GetQuotes();

		if(Quotes !=null && Quotes.Count > 0)
		{
			Models.QuotesApi Quote = Quotes[0];

			Author.Text = Quote.author;
			quote.Text = Quote.quote;
			
		}
	}

	private async void CollectlatestRecorded()
	{
		var latesweight = await StartPageViewModel.getlatestWeight();

		if (latesweight != null)
		{
			WeightLabel.Text = $"Your current weight is {latesweight.NewWeight}kg";
		}

	}

    private async void OnLogoutButton(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new MainPage());
    }
}