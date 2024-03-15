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
        //if (loggedinuser == null)
        //{
        //    WeightHistoryLabel.Text = $"Here is your weight history {loggedinuser.FirstName}";
        //}
        //else
        //{
        //    WeightHistoryLabel.Text = $"Here is your weight history {user.FirstName}";
        //}
       
        if(loggedinuser != null)
        {
            WeightHistoryLabel.Text = $"Here is your weight history {loggedinuser.FirstName}";
            displayWeightHistory();
        }
        else
        {
            WeightListView.ItemsSource = null;
        }
           
        BindingContext = new ViewModel.WeightHistoryPageViewModel();



    }


    public async Task displayWeightHistory()
    {

        Models.User loggedinuser = Models.User.GetLoggedinUser();



        if (loggedinuser != null)
        {
            var weights = await WeightHistoryPageViewModel.getlatestWeightsAsync();


            if (weights != null && weights.Any())
            {


                WeightListView.ItemsSource = weights;
            }
            else
            {

                WeightListView.ItemsSource = null;
                DisplayAlert("No Weights", "There are no recorded weights,", "ok");


            }
        }
        else
        {
            WeightListView.ItemsSource = null;
        }

    }
}
