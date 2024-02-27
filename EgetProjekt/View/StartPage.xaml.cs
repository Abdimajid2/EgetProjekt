
using EgetProjekt.Models;
using EgetProjekt.ViewModel;

namespace EgetProjekt.View;

public partial class StartPage : ContentPage
{
	// deklarerar en userid
	 private Guid userid;

	public StartPage(string firstname,decimal weight,Guid Id)
	{
		InitializeComponent();

		WelcomeLabel.Text = $"WELCOME {firstname}";
		WeightLabel.Text = $"YOUR CURRENT WEIGHT IS {weight}KG";

		// sätter userid till den id som skickas med sidan
		 userid = Id;
		 
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
			
		   userId = userid,
			NewWeight = enterWeight,
			WeightRecorded = DateTime.Now.Date,
		};

		//uppdaterar till den nya vikten
        WeightLabel.Text = $"YOUR CURRENT WEIGHT IS {weight.NewWeight}KG";
        
		var weightcollection = StartPageViewModel.WeightCollection();

		await weightcollection.InsertOneAsync(weight);

		DisplayAlert("Success", "New weight Recorded", "OK");
 
    }

	 
}