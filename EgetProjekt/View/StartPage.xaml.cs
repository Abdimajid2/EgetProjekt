
using EgetProjekt.Models;
using EgetProjekt.ViewModel;

namespace EgetProjekt.View;

public partial class StartPage : ContentPage
{
	 
	public StartPage(string firstname,decimal weight,Guid Id)
	{
		InitializeComponent();

		WelcomeLabel.Text = $"WELCOME {firstname}";
		WeightLabel.Text = $"YOUR CURRENT WEIGHT IS {weight}KG";

		GetRiddles();
		
  
	}

    private async void GetNewWeightCliced(object sender, EventArgs e)
    {
		int enterWeight;
		if(!int.TryParse(EnterNewWeight.Text, out enterWeight))
		{
			DisplayAlert("ERROR", "Enter only numbers", "OK");
			return;
		}

		Models.Weight weight = new Models.Weight
		{
			
		   userId = Id,
			NewWeight = enterWeight,
			WeightRecorded = DateTime.Now.Date,
		};

		//uppdaterar till den nya vikten
        WeightLabel.Text = $"YOUR CURRENT WEIGHT IS {weight.NewWeight}KG";
        
		var weightcollection = StartPageViewModel.WeightCollection();

		await weightcollection.InsertOneAsync(weight);

		DisplayAlert("Success", "New weight Recorded", "OK");
 
    }

    private async void OnGetWeightHistory(object sender, EventArgs e)
    {
		var weightdata = StartPageViewModel.WeightCollection();

		Models.User user = new Models.User();

		

		await Navigation.PushAsync(new View.WeightHistoryPage(user.id));
    }

	private async void GetRiddles()
	{
		List<Models.QuotesApi> Quotes = await ViewModel.StartPageViewModel.GetQuotes();

		if(Quotes !=null && Quotes.Count > 0)
		{
			Models.QuotesApi Quote = Quotes[0];

			Author.Text = Quote.author;
			quote.Text = Quote.quote;
			
		}
	}
}