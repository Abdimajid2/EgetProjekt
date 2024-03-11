using EgetProjekt.Logic;
using EgetProjekt.Models;
using EgetProjekt.ViewModel;

namespace EgetProjekt.View;

public partial class WeightHistoryPage : ContentPage
{
	public WeightHistoryPage(Models.User user)
	{
		InitializeComponent();

        Models.User loggedinuser = Models.User.GetLoggedinUser();
        if(loggedinuser == null)
        {
            WeightHistoryLabel.Text = $"Here is your weight history {user.FirstName}";
        }
        else
        {
            WeightHistoryLabel.Text = $"Here is your weight history {loggedinuser.FirstName}";
        }
       
        displayWeightHistory();

       BindingContext = new ViewModel.WeightHistoryPageViewModel();

         

    }

 
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
