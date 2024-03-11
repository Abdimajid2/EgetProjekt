using EgetProjekt.Logic;
using EgetProjekt.Models;
using EgetProjekt.ViewModel;

namespace EgetProjekt.View;

public partial class WeightHistoryPage : ContentPage
{
	public WeightHistoryPage()
	{
		InitializeComponent();

        Models.User loggedinuser = Models.User.GetLoggedinUser();

        Label.Text = $"Here is your weight history {loggedinuser.FirstName}";
        displayWeightHistory();

       BindingContext = new ViewModel.WeightHistoryPageViewModel();

        //WeightHistoryPageViewModel.getlatestWeights();
        //displayweights();

    }

	//private async Task displayweights()
	//{

 //       Models.User loggedinuser = Models.User.GetLoggedinUser();

 //       var weightstask = WeightHistoryPageViewModel.getlatestWeights();
 //       var weights = await weightstask;
 //       foreach (var weight in weights)
 //       {
 //           WeightLabel.Text = $"{weight.NewWeight}kg - Recorded at {weight.WeightRecorded}";
 //       }
 //   }

    private async Task displayWeightHistory()
    {

        Models.User loggedinuser = Models.User.GetLoggedinUser();



        if(loggedinuser != null)
        {
            var weights = await WeightHistoryPageViewModel.getlatestWeightsAsync();
         

                WeightListView.ItemsSource = weights;

        }
    }
}
